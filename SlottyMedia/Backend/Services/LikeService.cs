using SlottyMedia.Backend.Exceptions.Services.LikeExceptions;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Database;
using SlottyMedia.Database.Daos;
using SlottyMedia.Database.Exceptions;
using SlottyMedia.LoggingProvider;
using Supabase.Postgrest;

namespace SlottyMedia.Backend.Services;

/// <summary>
///     The service responsible for handling likes.
/// </summary>
public class LikeService : ILikeService
{
    private static readonly Logging<LikeService> Logger = new();
    private readonly IDatabaseActions _databaseActions;


    /// <summary>
    ///     The constructor for the LikeService.
    /// </summary>
    /// <param name="databaseActions"></param>
    public LikeService(IDatabaseActions databaseActions)
    {
        Logger.LogInfo("LikeService initialized");
        _databaseActions = databaseActions;
    }

    ///<inheritdoc />
    public async Task<bool> InsertLike(Guid userId, Guid postId)
    {
        try
        {
            Logger.LogDebug($"Inserting like for user {userId} and post {postId}");
            var like = new UserLikePostRelationDao(userId, postId);
            await _databaseActions.Insert(like);
            return true;
        }
        catch (DatabaseIudActionException ex)
        {
            throw new LikeIudException(
                $"An error occurred while inserting the like. Parameters: UserID {userId}, PostID {postId}", ex);
        }
        catch (GeneralDatabaseException ex)
        {
            throw new LikeGeneralException(
                $"An error occurred while inserting the like Parameters: UserID {userId}, PostID {postId}", ex);
        }
        catch (Exception ex)
        {
            throw new LikeGeneralException(
                $"An error occurred while inserting the like Parameters: UserID {userId}, PostID {postId}", ex);
        }
    }

    /// <inheritdoc />
    public async Task<bool> DeleteLike(Guid userId, Guid postId)
    {
        try
        {
            var like = new UserLikePostRelationDao(userId, postId);
            var result = await _databaseActions.Delete(like);
            return result;
        }
        catch (DatabaseIudActionException ex)
        {
            throw new LikeIudException(
                $"An error occurred while deleting the like. Parameters: UserID {userId}, PostID {postId}", ex);
        }
        catch (GeneralDatabaseException ex)
        {
            throw new LikeGeneralException(
                $"An error occurred while deleting the like. Parameters: UserID {userId}, PostID {postId}", ex);
        }
        catch (Exception ex)
        {
            throw new LikeGeneralException(
                $"An error occurred while deleting the like. Parameters: UserID {userId}, PostID {postId}", ex);
        }
    }

    /// <inheritdoc />
    public async Task<List<Guid>> GetLikesForPost(Guid postId)
    {
        try
        {
            var likes = await _databaseActions.GetEntitiesWithSelectorById<UserLikePostRelationDao>(
                x => new object[] { x.UserId! },
                new List<(string, Constants.Operator, string)>
                {
                    ("PostId", Constants.Operator.Equals, postId.ToString())
                },
                0, 0
            );
            var userIds = new List<Guid>();
            foreach (var like in likes)
                if (like.UserId is not null)
                    userIds.Add(like.UserId ?? Guid.Empty);
            return userIds;
        }
        catch (DatabaseMissingItemException ex)
        {
            throw new LikeNotFoundException($"An error occurred while reading the likes. Parameters: PostID {postId}",
                ex);
        }
        catch (GeneralDatabaseException ex)
        {
            throw new LikeGeneralException($"An error occurred while reading the likes. Parameters: PostID {postId}",
                ex);
        }
        catch (Exception ex)
        {
            throw new LikeGeneralException($"An error occurred while reading the likes. Parameters: PostID {postId}",
                ex);
        }
    }
}
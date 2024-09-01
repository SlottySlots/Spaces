using SlottyMedia.Backend.Exceptions.Services.LikeExceptions;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Database.Daos;
using SlottyMedia.Database.Exceptions;
using SlottyMedia.Database.Repository.UserLikePostRelationRepo;
using SlottyMedia.LoggingProvider;

namespace SlottyMedia.Backend.Services;

/// <summary>
///     The service responsible for handling likes.
/// </summary>
public class LikeService : ILikeService
{
    private static readonly Logging<LikeService> Logger = new();
    private readonly IUserLikePostRelationRepostitory _likeRepository;


    /// <summary>
    ///     The constructor for the LikeService.
    /// </summary>
    /// <param name="likeRepository"></param>
    public LikeService(IUserLikePostRelationRepostitory likeRepository)
    {
        Logger.LogInfo("LikeService initialized");
        _likeRepository = likeRepository;
    }

    ///<inheritdoc />
    public async Task<bool> InsertLike(Guid userId, Guid postId)
    {
        try
        {
            Logger.LogDebug($"Inserting like for user {userId} and post {postId}");
            var like = new UserLikePostRelationDao(userId, postId);
            await _likeRepository.AddElement(like);
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
            var like = await _likeRepository.GetLikeByUserIdAndPostId(userId, postId);
            await _likeRepository.DeleteElement(like);
            return true;
        }
        catch (DatabaseMissingItemException ex)
        {
            throw new LikeNotFoundException(
                $"An error occurred while deleting the like. Parameters: UserID {userId}, PostID {postId}", ex);
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
            var likes = await _likeRepository.GetLikesForPost(Guid.Empty, postId
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
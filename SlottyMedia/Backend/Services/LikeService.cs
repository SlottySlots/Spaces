using SlottyMedia.Backend.Exceptions.Services.PostExceptions;
using SlottyMedia.Backend.Exceptions.Services.UserExceptions;
using SlottyMedia.Database;
using SlottyMedia.Database.Daos;
using SlottyMedia.Database.Exceptions;
using Supabase.Postgrest;

namespace SlottyMedia.Backend.Services;

/// <summary>
///     The service responsible for handling likes.
/// </summary>
public class LikeService
{
    private readonly IDatabaseActions _databaseActions;

    /// <summary>
    ///     The constructor for the LikeService.
    /// </summary>
    /// <param name="databaseActions"></param>
    public LikeService(IDatabaseActions databaseActions)
    {
        _databaseActions = databaseActions;
    }

    /// <summary>
    ///     Inserts a like for a given user and post.
    /// </summary>
    /// <param name="userId">The ID of the user.</param>
    /// <param name="postId">The ID of the post.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating success.</returns>
    public async Task<bool> InsertLike(Guid userId, Guid postId)
    {
        try
        {
            var like = new UserLikePostRelationDao(userId, postId);
            var result = await _databaseActions.Insert(like);
            return true;
        }
        catch (DatabaseIudActionException ex)
        {
            throw new LikeIudException("An error occurred while inserting the like", ex);
        }
        catch (GeneralDatabaseException ex)
        {
            throw new LikeGeneralException("An error occurred while inserting the like", ex);
        }
        catch (Exception ex)
        {
            throw new LikeGeneralException("An error occurred while inserting the like", ex);
        }
    }

    /// <summary>
    ///     Deletes a like for a given user and post.
    /// </summary>
    /// <param name="userId">The ID of the user.</param>
    /// <param name="postId">The ID of the post.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating success.</returns>
    public async Task<bool> DeleteLike(Guid userId, Guid postId)
    {
        try
        {
            var like = new UserLikePostRelationDao(userId, postId);
            var result = await _databaseActions.Delete(like);
            return true;
        }
        catch (DatabaseIudActionException ex)
        {
            throw new LikeIudException("An error occurred while deleting the like", ex);
        }
        catch (GeneralDatabaseException ex)
        {
            throw new LikeGeneralException("An error occurred while deleting the like", ex);
        }
        catch (Exception ex)
        {
            throw new LikeGeneralException("An error occurred while deleting the like", ex);
        }
    }

    /// <summary>
    ///     Retrieves a list of user IDs who liked a given post.
    /// </summary>
    /// <param name="postId">The ID of the post.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of user IDs.</returns>
    public async Task<List<Guid>> GetLikesForPost(Guid postId)
    {
        try
        {
            var likes = await _databaseActions.GetEntitiesWithSelectorById<UserLikePostRelationDao>(
                x => new object[] { x.UserId },
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
            throw new LikeNotFoundException("An error occurred while reading the likes", ex);
        }
        catch (GeneralDatabaseException ex)
        {
            throw new LikeGeneralException("An error occurred while reading the likes", ex);
        }
        catch (Exception ex)
        {
            throw new LikeGeneralException("An error occurred while reading the likes", ex);
        }
    }
}
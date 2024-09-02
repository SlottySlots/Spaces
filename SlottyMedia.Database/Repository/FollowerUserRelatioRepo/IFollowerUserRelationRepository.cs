using SlottyMedia.Database.Daos;
using SlottyMedia.Database.Exceptions;

namespace SlottyMedia.Database.Repository.FollowerUserRelatioRepo;

/// <summary>
///     Interface for the Follower User Relation Repository.
/// </summary>
public interface IFollowerUserRelationRepository : IDatabaseRepository<FollowerUserRelationDao>
{
    /// <summary>
    ///     Gets the count of friends for a specific user.
    /// </summary>
    /// <param name="userId">The unique identifier of the user.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the count of friends.</returns>
    /// <exception cref="DatabaseMissingItemException">Thrown when the entity is not found in the database.</exception>
    /// <exception cref="GeneralDatabaseException">Thrown when an unexpected error occurs.</exception>
    public Task<int> GetCountOfUserFriends(Guid userId);

    /// <summary>
    ///     Gets the list of friends for a specific user.
    /// </summary>
    /// <param name="userId">The unique identifier of the user.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the list of friends.</returns>
    /// <exception cref="DatabaseMissingItemException">Thrown when the entity is not found in the database.</exception>
    /// <exception cref="GeneralDatabaseException">Thrown when an unexpected error occurs.</exception>
    public Task<List<FollowerUserRelationDao>> GetFriends(Guid userId);

    
    /// <summary>
    ///     Checks if a user is followed by another user.
    /// </summary>
    /// <param name="userId">The unique identifier of the user.</param>
    /// <param name="followedUserId">The unique identifier of the followed user.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the follower user relation.</returns>
    /// <exception cref="DatabaseMissingItemException">Thrown when the entity is not found in the database.</exception>
    /// <exception cref="GeneralDatabaseException">Thrown when an unexpected error occurs.</exception>
    public Task<FollowerUserRelationDao> CheckIfUserIsFollowed(Guid userId, Guid followedUserId);
}
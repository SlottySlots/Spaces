using SlottyMedia.Database.Daos;

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
    public Task<int> GetCountOfUserFriends(Guid userId);

    /// <summary>
    ///     Gets the list of friends for a specific user.
    /// </summary>
    /// <param name="userId">The unique identifier of the user.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the list of friends.</returns>
    public Task<List<FollowerUserRelationDao>> GetFriends(Guid userId);
    
    public Task<FollowerUserRelationDao> CheckIfUserIsFollowed(Guid userId, Guid followedUserId);

}
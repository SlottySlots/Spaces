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

    /// <summary>
    /// Gets a list of FollowerUserRelationDaos by userId
    /// </summary>
    /// <param name="userId">
    /// UserId to retrieve its follows
    /// </param>
    /// <returns>
    /// List of FollowerUserRelationDaos matching the userid
    /// </returns>
    public Task<List<FollowerUserRelationDao>> GetFollowsOfUserById(Guid userId);

    /// <summary>
    /// Method used to follow a user by dao
    /// </summary>
    /// <param name="userFollows">
    /// The user that tries to follow another
    /// </param>
    /// <param name="userToFollow">
    /// The user that the user tries to follow
    /// </param>
    /// <returns>
    /// Task
    /// </returns>
    public Task FollowUserByDao(UserDao userFollows, UserDao userToFollow);
}
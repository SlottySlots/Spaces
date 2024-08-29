using SlottyMedia.Database.Daos;

namespace SlottyMedia.Database.Repository.UserLikePostRelationRepo;

/// <summary>
///     Interface for the User Like Post Relation Repository.
/// </summary>
public interface IUserLikePostRelationRepostitory : IDatabaseRepository<UserLikePostRelationDao>
{
    /// <summary>
    ///     Gets the likes for a specific post by a specific user.
    /// </summary>
    /// <param name="userId">The unique identifier of the user.</param>
    /// <param name="postId">The unique identifier of the post.</param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains a list of user like post
    ///     relations.
    /// </returns>
    public Task<List<UserLikePostRelationDao>> GetLikesForPost(Guid userId, Guid postId);
}
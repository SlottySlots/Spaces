using SlottyMedia.Database.Daos;
using SlottyMedia.Database.Exceptions;

namespace SlottyMedia.Database.Repository.UserLikePostRelationRepo;

/// <summary>
///     Interface for the User Like Post Relation Repository.
/// </summary>
public interface IUserLikePostRelationRepostitory : IDatabaseRepository<UserLikePostRelationDao>
{
    /// <summary>
    ///     Gets the likes for a specific post.
    /// </summary>
    /// <param name="postId">The unique identifier of the post.</param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains a list of user like post
    ///     relations.
    /// </returns>
    /// <exception cref="DatabaseMissingItemException">Thrown when the entity is not found in the database.</exception>
    /// <exception cref="GeneralDatabaseException">Thrown when an unexpected error occurs.</exception>
    public Task<List<UserLikePostRelationDao>> GetLikesForPost(Guid postId);

    /// <summary>
    ///     Gets the like for a specific post by a specific user.
    /// </summary>
    /// <param name="userId">The unique identifier of the user.</param>
    /// <param name="postId">The unique identifier of the post.</param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains the user like post relation.
    /// </returns>
    /// <exception cref="DatabaseMissingItemException">Thrown when the entity is not found in the database.</exception>
    /// <exception cref="GeneralDatabaseException">Thrown when an unexpected error occurs.</exception>
    public Task<UserLikePostRelationDao> GetLikeByUserIdAndPostId(Guid userId, Guid postId);
}
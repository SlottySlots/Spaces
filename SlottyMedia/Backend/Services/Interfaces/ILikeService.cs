namespace SlottyMedia.Backend.Services.Interfaces;

/// <summary>
///     Interface for LikeService which handles operations related to likes on posts.
/// </summary>
public interface ILikeService
{
    /// <summary>
    ///     Inserts a like for a given post by a user.
    /// </summary>
    /// <param name="userId">The ID of the user who likes the post.</param>
    /// <param name="postId">The ID of the post to be liked.</param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains a boolean indicating whether the
    ///     like was successfully inserted.
    /// </returns>
    Task<bool> InsertLike(Guid userId, Guid postId);

    /// <summary>
    ///     Deletes a like for a given post by a user.
    /// </summary>
    /// <param name="userId">The ID of the user who unlikes the post.</param>
    /// <param name="postId">The ID of the post to be unliked.</param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains a boolean indicating whether the
    ///     like was successfully deleted.
    /// </returns>
    Task<bool> DeleteLike(Guid userId, Guid postId);

    /// <summary>
    ///     Retrieves a list of user IDs who liked a given post.
    /// </summary>
    /// <param name="postId">The ID of the post for which to retrieve likes.</param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains a list of user IDs who liked the
    ///     post.
    /// </returns>
    Task<List<Guid>> GetLikesForPost(Guid postId);
}
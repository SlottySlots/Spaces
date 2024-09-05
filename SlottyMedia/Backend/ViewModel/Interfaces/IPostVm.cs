using SlottyMedia.Backend.Dtos;

namespace SlottyMedia.Backend.ViewModel.Interfaces;

/// <summary>
///     The interface for post view model implementation.
/// </summary>
public interface IPostVm
{
    /// <summary>
    ///     Retrieves the owner of a post by user ID.
    /// </summary>
    /// <param name="userId">The ID of the user.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the user DTO.</returns>
    Task<UserDto> GetOwner(Guid userId);

    /// <summary>
    ///     Retrieves the count of comments for a post.
    /// </summary>
    /// <param name="postId">The ID of the post.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the count of comments.</returns>
    Task<int> GetCommentsCount(Guid postId);

    /// <summary>
    ///     Retrieves user information by user ID.
    /// </summary>
    /// <param name="userId">The ID of the user.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the user information DTO.</returns>
    Task<UserInformationDto> GetUserInformation(Guid userId);

    /// <summary>
    ///     Retrieves the list of likes for a post.
    /// </summary>
    /// <param name="postId">The ID of the post.</param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains the list of user IDs who liked the
    ///     post.
    /// </returns>
    Task<List<Guid>?> GetLikes(Guid postId);

    /// <summary>
    ///     Adds a like to a post by a user.
    /// </summary>
    /// <param name="postId">The ID of the post.</param>
    /// <param name="userId">The ID of the user.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task AddLike(Guid postId, Guid userId);

    /// <summary>
    ///     Removes a like from a post by a user.
    /// </summary>
    /// <param name="postId">The ID of the post.</param>
    /// <param name="userId">The ID of the user.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task RemoveLike(Guid postId, Guid userId);
}
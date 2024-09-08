using SlottyMedia.Backend.Dtos;

namespace SlottyMedia.Backend.ViewModel.Interfaces;

/// <summary>
///     The interface for post view model implementation.
/// </summary>
public interface IPostVm
{
    /// <summary>
    ///     Gets the count of comments on the post.
    /// </summary>
    int CommentCount { get; }

    /// <summary>
    ///     Gets a value indicating whether the post was initially liked by the user.
    /// </summary>
    bool InitLiked { get; }

    /// <summary>
    ///     Gets a value indicating whether the post view model is currently loading.
    /// </summary>
    bool IsLoading { get; }

    /// <summary>
    ///     Gets the count of likes on the post.
    /// </summary>
    int LikeCount { get; }

    /// <summary>
    ///     Gets the user information associated with the post.
    /// </summary>
    UserInformationDto UserInformation { get; }

    /// <summary>
    ///     Initializes the post view model.
    /// </summary>
    /// <param name="postId">The ID of the post.</param>
    /// <param name="userId">The ID of the user.</param>
    /// <param name="currentUserId">The ID of the user who is logged in</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task Initialize(Guid postId, Guid userId, Guid currentUserId);

    /// <summary>
    ///     Likes a post by a user.
    /// </summary>
    /// <param name="postId">The ID of the post.</param>
    /// <param name="userId">The ID of the user.</param>
    /// <param name="wasUnliked">If the post was unliked or not</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task LikePost(Guid postId, Guid userId, bool wasUnliked);

    /// <summary>
    ///     Retrieves user information.
    /// </summary>
    /// <param name="userId">The ID of the user.</param>
    /// <param name="firstRender">Indicates if this is the first render.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task GetUserInformation(Guid userId, bool firstRender);
}
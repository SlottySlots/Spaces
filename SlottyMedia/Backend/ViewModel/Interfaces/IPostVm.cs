using SlottyMedia.Backend.Dtos;

namespace SlottyMedia.Backend.ViewModel.Interfaces;

/// <summary>
///     The interface for post view model implementation.
/// </summary>
public interface IPostVm
{
    /// <summary>
    ///     The user ID of the authentication principal
    /// </summary>
    Guid? AuthPrincipalId { get; }

    /// <summary>
    ///     Gets a value indicating whether the post was liked by the user.
    /// </summary>
    bool IsPostLiked { get; }

    /// <summary>
    ///     Gets a value indicating whether the post view model is currently loading.
    /// </summary>
    bool IsLoading { get; }
    
    /// <summary>
    ///     The post's corresponding DTO
    /// </summary>
    PostDto? PostDto { get; }
    
    /// <summary>
    ///     Gets the count of comments on the post.
    /// </summary>
    int CommentCount { get; }

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
    /// <param name="onStateChanged">
    ///     An event that is triggered whenever the internal state changes.
    ///     This is intended to re-render the component!
    /// </param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task Initialize(Guid postId, Action onStateChanged);

    /// <summary>
    ///     Likes a post by a user.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task LikeThisPost();

    /// <summary>
    ///     Navigates to the post's dedicated page (<c>/post/POST-ID</c>)
    /// </summary>
    void GoToPostPage();

    /// <summary>
    ///     Navigates to the post's owner's profile page (<c>/profile/USER-ID</c>)
    /// </summary>
    void GoToProfilePage();
}
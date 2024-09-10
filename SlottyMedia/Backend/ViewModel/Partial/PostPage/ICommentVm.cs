using SlottyMedia.Backend.Dtos;

namespace SlottyMedia.Backend.ViewModel.Partial.PostPage;

/// <summary>
///     Interface for the Comment ViewModel.
/// </summary>
public interface ICommentVm
{
    /// <summary>
    ///     Whether the necessary comment-related data is still being loaded.
    /// </summary>
    bool IsLoading { get; }

    /// <summary>
    ///     The comment that should be rendered.
    /// </summary>
    CommentDto? Dto { get; }

    /// <summary>
    ///     User-related information about the comment's creator.
    /// </summary>
    UserInformationDto? UserInfo { get; }

    /// <summary>
    ///     Initializes this view model with the provided comment ID.
    ///     This loads all comment-related information.
    /// </summary>
    /// <param name="commentId">The ID of the comment that should be loaded</param>
    Task Initialize(Guid commentId);

    /// <summary>
    ///     Navigates to the comment creator's profile page.
    /// </summary>
    void GoToCreatorProfile();
}
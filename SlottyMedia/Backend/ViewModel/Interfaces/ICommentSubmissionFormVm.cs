using SlottyMedia.Backend.Dtos;
using SlottyMedia.Components.Partial.PostPage;

namespace SlottyMedia.Backend.ViewModel.Interfaces;

/// <summary>
///     This ViewModel represents the state of the <see cref="CommentSubmissionForm" /> component.
/// </summary>
public interface ICommentSubmissionFormVm
{
    /// <summary>The post's textual content</summary>
    string? Text { get; set; }

    /// <summary>An optional error message related to the post's textual content</summary>
    string? TextErrorMessage { get; }

    /// <summary>An optional error message that is caused by some internal server error</summary>
    string? ServerErrorMessage { get; }

    /// <summary>
    ///     Attempts to submit the form. If successful, the post was created.
    ///     Otherwise, displays an appropriate error message regarding the submission's
    ///     failure.
    /// </summary>
    /// <param name="postId">The ID of the post to submit the comment for</param>
    Task SubmitForm(Guid postId);

    
    /// <summary>
    ///     Initializes the ViewModel with the specified user ID.
    /// </summary>
    /// <param name="userId">The ID of the user to load information for.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public Task Initialize(Guid? userId);
    
    /// <summary>
    ///     The user information data transfer object to be rendered.
    /// </summary>
    UserInformationDto UserInformation { get; set; }

    /// <summary>
    ///     Gets a value indicating whether the data is still loading.
    /// </summary>
    bool IsLoading { get; set; }
}
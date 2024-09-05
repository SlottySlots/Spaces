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
}
namespace SlottyMedia.Backend.ViewModel.Interfaces;


/// <summary>
/// This ViewModel represents a form that is used to create a post.
/// It contains fields for the post's textual data and fields that
/// represent corresponding errors.
/// </summary>
public interface IPostSubmissionFormVm
{
    /// <summary>The post's textual content</summary>
    string? Text { get; set; }
    
    /// <summary>An optional error message related to the post's textual content</summary>
    string? TextErrorMessage { get; set; }
    
    /// <summary>An optional error message that is caused by some internal server error</summary>
    string? ServerErrorMessage { get; set; }

    /// <summary>
    /// Attempts to submit the form. If successful, the post was created.
    /// Otherwise, displays an appropriate error message regarding the submission's
    /// failure.
    /// </summary>
    Task SubmitForm();
}
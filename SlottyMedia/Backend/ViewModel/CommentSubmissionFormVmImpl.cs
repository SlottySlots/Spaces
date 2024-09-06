using Microsoft.AspNetCore.Components;
using Microsoft.IdentityModel.Tokens;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Backend.ViewModel.Interfaces;

namespace SlottyMedia.Backend.ViewModel;

/// <inheritdoc />
public class CommentSubmissionFormVmImpl : ICommentSubmissionFormVm
{
    private readonly IAuthService _authService;
    private readonly ICommentService _commentService;
    private readonly NavigationManager _navigationManager;

    /// <summary>Instantiates this class</summary>
    public CommentSubmissionFormVmImpl(IAuthService authService, ICommentService commentService,
        NavigationManager navigationManager)
    {
        _authService = authService;
        _commentService = commentService;
        _navigationManager = navigationManager;
    }

    /// <inheritdoc />
    public string? Text { get; set; }

    /// <inheritdoc />
    public string? TextErrorMessage { get; private set; }

    /// <inheritdoc />
    public string? ServerErrorMessage { get; private set; }

    /// <inheritdoc />
    public async Task SubmitForm(Guid postId)
    {
        // reset all error messages when form is (re-)submitted
        _resetErrorMessages();

        // if no user is logged in (for whichever reason): display error
        // This case should never happen. The comment submission form should only
        // be accessible to authenticated users!
        // This case is handled nonetheless for safety reasons.
        if (!_authService.IsAuthenticated())
        {
            ServerErrorMessage = "You need to log in to submit a post";
            return;
        }

        // display error when fields are empty
        if (Text.IsNullOrEmpty())
        {
            TextErrorMessage = "Must provide some text in order to submit comment";
            return;
        }

        // attempt to submit post
        try
        {
            var userId = _authService.GetCurrentSession()!.User!.Id;
            await _commentService.InsertComment(new Guid(userId!), postId, Text!);
        }
        catch
        {
            ServerErrorMessage = "An unknown error occurred. Try again later.";
            return;
        }

        // if no errors occurred: reload page
        _navigationManager.Refresh(true);
    }

    private void _resetErrorMessages()
    {
        TextErrorMessage = null;
        ServerErrorMessage = null;
    }
}
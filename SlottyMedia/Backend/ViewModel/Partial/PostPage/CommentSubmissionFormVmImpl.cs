using Microsoft.AspNetCore.Components;
using Microsoft.IdentityModel.Tokens;
using SlottyMedia.Backend.Dtos;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.LoggingProvider;

namespace SlottyMedia.Backend.ViewModel.Partial.PostPage;

/// <inheritdoc />
public class CommentSubmissionFormVmImpl : ICommentSubmissionFormVm
{
    private readonly IAuthService _authService;
    private readonly ICommentService _commentService;
    private readonly Logging<CommentSubmissionFormVmImpl> _logger = new();
    private readonly NavigationManager _navigationManager;
    private readonly IUserService _userService;

    /// <summary>Instantiates this class</summary>
    public CommentSubmissionFormVmImpl(IAuthService authService, ICommentService commentService,
        NavigationManager navigationManager, IUserService userService)
    {
        _authService = authService;
        _commentService = commentService;
        _navigationManager = navigationManager;
        _userService = userService;
    }

    /// <inheritdoc />
    public string? Text { get; set; }

    /// <inheritdoc />
    public string? TextErrorMessage { get; private set; }

    /// <inheritdoc />
    public string? ServerErrorMessage { get; private set; }

    /// <inheritdoc />
    public UserInformationDto UserInformation { get; set; } = new(true);

    /// <inheritdoc />
    public bool IsLoading { get; set; }

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

    /// <inheritdoc />
    public async Task Initialize(Guid? userId)
    {
        if (userId is not null && UserInformation.Username == "Username is loading..")
            try
            {
                IsLoading = true;
                var userInfo = await _userService.GetUserInfo(userId.Value, false, false);
                if (userInfo is not null) UserInformation = userInfo;
                IsLoading = false;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Failed to load user information");
            }
    }

    private void _resetErrorMessages()
    {
        TextErrorMessage = null;
        ServerErrorMessage = null;
    }
}
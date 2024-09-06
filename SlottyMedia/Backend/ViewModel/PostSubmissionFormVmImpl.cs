using Microsoft.AspNetCore.Components;
using Microsoft.IdentityModel.Tokens;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Backend.ViewModel.Interfaces;
using SlottyMedia.Database.Pagination;
using SlottyMedia.LoggingProvider;

namespace SlottyMedia.Backend.ViewModel;

/// <inheritdoc />
public class PostSubmissionFormVmImpl : IPostSubmissionFormVm
{
    private static readonly Logging<PostSubmissionFormVmImpl> Logger = new();

    private readonly IAuthService _authService;
    private readonly IForumService _forumService;
    private readonly NavigationManager _navigationManager;
    private readonly IPostService _postService;
    private readonly ISearchService _searchService;

    /// <summary>
    ///     Ctor used for dep inject
    /// </summary>
    public PostSubmissionFormVmImpl(
        IAuthService authService,
        IPostService postService,
        IForumService forumService,
        ISearchService searchService,
        NavigationManager navigationManager)
    {
        _authService = authService;
        _postService = postService;
        _forumService = forumService;
        _searchService = searchService;
        _navigationManager = navigationManager;
    }

    /// <inheritdoc />
    public string? Text { get; set; }

    /// <inheritdoc />
    public string? TextErrorMessage { get; set; }

    /// <inheritdoc />
    public string? SpacePrompt { get; set; }

    /// <inheritdoc />
    public string? SpaceName { get; set; }

    /// <inheritdoc />
    public List<string> SearchedSpaces { get; set; } = [];

    /// <inheritdoc />
    public string? SpaceErrorMessage { get; set; }

    /// <inheritdoc />
    public string? ServerErrorMessage { get; set; }

    /// <inheritdoc />
    public async Task HandleSpacePromptChange(ChangeEventArgs e, EventCallback<string?> promptValueChanged)
    {
        Logger.LogDebug($"User is searching for space in post submission form. Prompt: '{e.Value}'");
        if (e.Value is not null)
        {
            var newValue = e.Value.ToString();
            SpacePrompt = newValue;
            await promptValueChanged.InvokeAsync(newValue);
            var searchResults = await _searchService
                .SearchByForumTopicContaining(newValue ?? "", PageRequest.OfSize(10));
            SearchedSpaces = searchResults.Select(space => space.Topic).ToList();
        }
    }

    /// <inheritdoc />
    public void HandleSpaceSelection(string spaceName)
    {
        SpaceName = spaceName;
        SpacePrompt = null;
    }

    /// <inheritdoc />
    public void HandleSpaceDeselection()
    {
        SpaceName = null;
    }

    /// <inheritdoc />
    public async Task SubmitForm()
    {
        // reset all error messages when form is (re-)submitted
        _resetErrorMessages();

        // if no user is logged in (for whichever reason): display error
        // This case should never happen. The post submission form should only
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
            TextErrorMessage = "Must provide some text in order to submit post";
            return;
        }

        if (SpaceName.IsNullOrEmpty())
        {
            SpaceErrorMessage = "Must provide a space for the post";
            return;
        }

        // attempt to submit post
        try
        {
            var forum = await _forumService.GetForumByName(SpaceName!);
            var userId = _authService.GetCurrentSession()!.User!.Id;
            await _postService.InsertPost(Text!, new Guid(userId!), forum.ForumId);
        }
        catch
        {
            ServerErrorMessage = "An unknown error occurred. Try again later.";
            return;
        }

        // if no errors occurred: redirect to index page
        _navigationManager.NavigateTo("/", true);
    }

    private void _resetErrorMessages()
    {
        TextErrorMessage = null;
        SpaceErrorMessage = null;
        ServerErrorMessage = null;
    }
}
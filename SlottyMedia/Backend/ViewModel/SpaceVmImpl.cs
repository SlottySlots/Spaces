using SlottyMedia.Backend.Dtos;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Backend.ViewModel.Interfaces;
using SlottyMedia.Database.Pagination;
using SlottyMedia.LoggingProvider;

namespace SlottyMedia.Backend.ViewModel;

/// <summary>
///     Implements ISpaceVm to manage the state of the Space Page.
/// </summary>
public class SpaceVmImpl : ISpaceVm
{
    private static readonly Logging<SpaceVmImpl> _logger = new();
    private readonly IAuthService _authService;
    private readonly IForumService _forumService;
    private readonly IPostService _postService;

    //public string CreatedBy { get; private set; }

    /// <summary>
    ///     Initializes the ViewModel with the necessary services.
    /// </summary>
    public SpaceVmImpl(IForumService forumService, IPostService postService, IAuthService authService)
    {
        _forumService = forumService ?? throw new ArgumentNullException(nameof(forumService));
        _postService = postService ?? throw new ArgumentNullException(nameof(postService));
        _authService = authService ?? throw new ArgumentNullException(nameof(authService));
    }

    /// <summary>
    ///     A boolean flag indicating whether the posts on the page are being loaded.
    /// </summary>
    public bool IsLoadingPosts { get; private set; }

    /// <summary>
    ///     A boolean flag indicating whether the entire page is being loaded.
    /// </summary>
    public bool IsLoadingPage { get; private set; }

    /// <summary>
    ///     The ID of the authenticated user (the currently logged-in user).
    /// </summary>
    public Guid? AuthPrincipalId { get; private set; }

    /// <summary>
    ///     Holds the details of the current space (ForumDto).
    /// </summary>
    public ForumDto? Space { get; private set; }

    /// <summary>
    ///     Contains the paginated posts belonging to the space.
    /// </summary>
    public IPage<PostDto> Posts { get; private set; } = PageImpl<PostDto>.Empty();


    /// <summary>
    ///     Loads the details of a specific space based on the provided forum ID.
    ///     This method also loads the posts for the space and sets the loading states accordingly.
    ///     <param name="forumId">The space to load information from.</param>
    /// </summary>
    public async Task Initialize(Guid forumId)
    {
        try
        {
            IsLoadingPage = true;
            _logger.LogInfo("Space Page: Loading necessary space-related information...");
            var authPrincipalIdStr = _authService.GetCurrentSession()?.User?.Id;
            AuthPrincipalId = authPrincipalIdStr is null ? null : new Guid(authPrincipalIdStr);
            Space = await _forumService.GetForumById(forumId);
            if (Space == null)
            {
                _logger.LogError($"Space Page: No forum found with ID '{forumId}'");
                return;
            }

            _logger.LogInfo("Space Page: Successfully loaded all space-related information");
            await LoadPosts(0);
            _logger.LogInfo("Space Page: Successfully loaded posts for space.");
        }
        catch (Exception ex)
        {
            _logger.LogError($"Space Page: An error occurred while initializing the space page: {ex.Message}");
        }

        finally
        {
            IsLoadingPage = false;
        }
    }

    /// <summary>
    ///     Loads the posts for the space. This method is called when loading a specific page of posts.
    /// </summary>
    /// <param name="pageNumber">The page number to load posts from.</param>
    public async Task LoadPosts(int pageNumber)
    {
        try
        {
            IsLoadingPosts = true;
            if (Space == null)
            {
                _logger.LogError("Space Page: Cannot load posts because space is not initialized.");
                return;
            }

            _logger.LogInfo($"Space Page: Loading posts for space '{Space.Topic}'. Loading page {pageNumber}...");

            Posts = await _postService.GetPostsByForumId(Space.ForumId, PageRequest.Of(pageNumber, 10));

            _logger.LogInfo($"Space Page: Successfully loaded page {pageNumber}, which contains {Posts.Count()} posts");
        }
        catch (Exception ex)
        {
            _logger.LogError(
                $"Space Page: Error while loading posts for page {pageNumber} in space '{Space?.Topic}': {ex.Message}");
        }
        finally
        {
            IsLoadingPosts = false;
        }
    }
}
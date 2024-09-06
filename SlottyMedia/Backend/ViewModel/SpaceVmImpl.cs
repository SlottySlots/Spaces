using SlottyMedia.Backend.Dtos;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Backend.ViewModel.Interfaces;
using SlottyMedia.Database.Pagination;
using SlottyMedia.LoggingProvider;

namespace SlottyMedia.Backend.ViewModel;

/// <summary>
/// Implements ISpaceVm to manage the state of the Space Page.
/// </summary>
public class SpaceVmImpl : ISpaceVm
{
    private static readonly Logging<SpaceVmImpl> _logger = new();
    private readonly IForumService _forumService;
    private readonly IPostService _postService;
    private readonly IAuthService _authService;
    
    //public string CreatedBy { get; private set; }

    /// <summary>
    /// Initializes the ViewModel with the necessary services.
    /// </summary>
    public SpaceVmImpl(IForumService forumService, IPostService postService, IAuthService authService)
    {
        _forumService = forumService ?? throw new ArgumentNullException(nameof(forumService));
        _postService = postService ?? throw new ArgumentNullException(nameof(postService));
        _authService = authService?? throw new ArgumentNullException(nameof(authService));
    }
    
    /// <inheritdoc />
    public bool IsLoadingPosts { get; private set; }
    
    /// <inheritdoc />
    public bool IsLoadingPage { get; private set; }
    
    /// <inheritdoc />
    public Guid? AuthPrincipalId { get; private set; }

    /// <inheritdoc />
    public ForumDto? Space { get; private set; }

    /// <inheritdoc />
    public IPage<PostDto> Posts { get; private set; } = PageImpl<PostDto>.Empty();
    
    
    /// <inheritdoc />
    public async Task Initialize(Guid forumId)
    {
        IsLoadingPage = true;
        _logger.LogInfo("Space Page: Loading necessary space-related information...");
        var authPrincipalIdStr = _authService.GetCurrentSession()?.User?.Id;
        AuthPrincipalId = authPrincipalIdStr is null ? null : new Guid(authPrincipalIdStr);
        Space = await _forumService.GetForumById(forumId);
        _logger.LogInfo("Space Page: Successfully loaded all space-related information");
        IsLoadingPage = false;
        await LoadPosts(0);
    }
    
    /// <inheritdoc />
    public async Task LoadPosts(int pageNumber)
    {
        IsLoadingPosts = true;
        _logger.LogInfo($"Space Page: Loading posts for space '{Space!.Topic}'. Loading page {pageNumber}...");
        Posts = await _postService.GetPostsByForumId(
            Space.ForumId,
            PageRequest.Of(pageNumber, 10));
        _logger.LogInfo($"Space Page: Successfully loaded page {pageNumber}, which contains {Posts.Count()} posts");
        IsLoadingPosts = false;
    }
    
    
    
}
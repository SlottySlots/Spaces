using SlottyMedia.Backend.Dtos;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Backend.ViewModel.Interfaces;
using SlottyMedia.Database.Pagination;
using SlottyMedia.LoggingProvider;

namespace SlottyMedia.Backend.ViewModel;

/// <inheritdoc />
public class HomePageVmImpl : IHomePageVm
{
    private static readonly Logging<HomePageVmImpl> Logger = new();
    private readonly IAuthService _authService;

    private readonly IPostService _postService;

    /// <summary>Instantiates this class</summary>
    public HomePageVmImpl(IPostService postService, IAuthService authService)
    {
        _postService = postService;
        _authService = authService;
    }

    /// <inheritdoc />
    public Guid? AuthPrincipalId { get; private set; }

    /// <inheritdoc />
    public bool IsLoadingPage { get; private set; }

    /// <inheritdoc />
    public IPage<PostDto> Page { get; private set; } = PageImpl<PostDto>.Empty();

    /// <inheritdoc />
    public async Task Initialize()
    {
        AuthPrincipalId = _authService.GetAuthPrincipalId();
        await LoadPage(0);
    }

    /// <inheritdoc />
    public async Task LoadPage(int pageNumber)
    {
        Logger.LogInfo($"Home page: Loading posts on page {pageNumber}");
        IsLoadingPage = true;
        Page = await _postService.GetAllPosts(PageRequest.Of(pageNumber, 10));
        IsLoadingPage = false;
    }
}
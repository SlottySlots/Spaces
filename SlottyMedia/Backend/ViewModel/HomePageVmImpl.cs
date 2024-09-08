using SlottyMedia.Backend.Dtos;
using SlottyMedia.Backend.Services;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Backend.ViewModel.Interfaces;
using SlottyMedia.Database.Pagination;
using SlottyMedia.LoggingProvider;

namespace SlottyMedia.Backend.ViewModel;

/// <inheritdoc />
public class HomePageVmImpl : IHomePageVm
{
    private static readonly Logging<HomePageVmImpl> Logger = new();

    private readonly IPostService _postService;
    private readonly IAuthService _authService;

    /// <summary>Instantiates this class</summary>
    public HomePageVmImpl(IPostService postService, IAuthService authService)
    {
        _postService = postService;
        _authService = authService;
    }

    /// <inheritdoc />
    public bool IsLoadingPage { get; private set; }

    /// <inheritdoc />
    public IPage<PostDto> Page { get; private set; } = PageImpl<PostDto>.Empty();
    
    /// <inheritdoc />
    public Guid CurrentUserId { get; private set; }
    
    /// <inheritdoc />
    public bool IsAuthenticated { get; private set; }

    /// <inheritdoc />
    public async Task Initialize()
    {
        CurrentUserId = Guid.Parse(_authService.GetCurrentSession()!.User!.Id!);
        await LoadPage(0);
    }

    /// <inheritdoc />
    public async Task LoadPage(int pageNumber)
    {
        Logger.LogInfo($"Home page: Loading posts on page {pageNumber}");
        IsLoadingPage = true;
        Page = await _postService.GetAllPosts(PageRequest.Of(pageNumber, 10));
        IsAuthenticated = _authService.IsAuthenticated();
        IsLoadingPage = false;
    }
}
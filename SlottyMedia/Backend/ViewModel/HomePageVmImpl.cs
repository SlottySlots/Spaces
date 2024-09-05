using SlottyMedia.Backend.Dtos;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Backend.ViewModel.Interfaces;

namespace SlottyMedia.Backend.ViewModel;

/// <inheritdoc />
public class HomePageVmImpl : IHomePageVm
{
    private readonly IPostService _postService;

    private int _currentPostPage;

    /// <summary>Instantiates this class</summary>
    public HomePageVmImpl(IPostService postService)
    {
        _postService = postService;
    }

    /// <inheritdoc />
    public bool IsLoadingPage { get; private set; }

    /// <inheritdoc />
    public bool IsLoadingPosts { get; private set; }

    /// <inheritdoc />
    public List<PostDto> Posts { get; private set; } = [];

    /// <inheritdoc />
    public int TotalNumberOfPosts { get; private set; }

    /// <inheritdoc />
    public async Task Initialize()
    {
        IsLoadingPage = true;
        Posts = [];
        _currentPostPage = 0;
        TotalNumberOfPosts = await _postService.CountAllPosts();
        IsLoadingPage = false;
        await LoadMorePosts();
    }

    /// <inheritdoc />
    public async Task LoadMorePosts()
    {
        IsLoadingPosts = true;
        _currentPostPage++;
        var results = await _postService.GetAllPosts(_currentPostPage);
        foreach (var post in results)
            Posts.Add(post);
        IsLoadingPage = false;
    }
}
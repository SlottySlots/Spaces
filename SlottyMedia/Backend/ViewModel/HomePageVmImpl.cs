using SlottyMedia.Backend.Dtos;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Backend.ViewModel.Interfaces;

namespace SlottyMedia.Backend.ViewModel;

/// <inheritdoc />
public class HomePageVmImpl : IHomePageVm
{
    private readonly IPostService _postService;

    /// <summary>
    ///     Ctor used for dep inject
    /// </summary>
    public HomePageVmImpl(IPostService postService)
    {
        _postService = postService;
    }

    /// <inheritdoc />
    public List<PostDto> Posts { get; set; } = new();

    /// <inheritdoc />
    public async Task FetchPosts()
    {
        Posts.Clear();
        Posts = await _postService.GetAllPosts(1);
    }
}
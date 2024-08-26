using SlottyMedia.Backend.Dtos;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Backend.ViewModel.Interfaces;

namespace SlottyMedia.Backend.ViewModel;

public class HomePageVmImpl : IHomePageVm
{
    private readonly IPostService _postService;

    public HomePageVmImpl(IPostService postService)
    {
        _postService = postService;
    }

    public List<PostDto> Posts { get; set; } = new();

    public async Task FetchPosts()
    {
        Posts.Clear();
        Posts = await _postService.GetAllPosts(1);
    }
}
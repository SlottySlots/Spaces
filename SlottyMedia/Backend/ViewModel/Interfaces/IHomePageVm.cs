using SlottyMedia.Backend.Dtos;

namespace SlottyMedia.Backend.ViewModel.Interfaces;

public interface IHomePageVm
{
    List<PostDto> Posts { get; set; }

    Task FetchPosts();
}
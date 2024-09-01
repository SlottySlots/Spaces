using SlottyMedia.Backend.Dtos;

namespace SlottyMedia.Backend.ViewModel.Interfaces;

/// <summary>
/// Interface for homepage viewmodel
/// </summary>
public interface IHomePageVm
{
    /// <summary>
    /// Represents all posts shown on a homepage
    /// </summary>
    List<PostDto> Posts { get; set; }

    /// <summary>
    /// Fetches all posts shown on the homepage of a user
    /// </summary>
    /// <returns>
    /// Task
    /// </returns>
    Task FetchPosts();
}
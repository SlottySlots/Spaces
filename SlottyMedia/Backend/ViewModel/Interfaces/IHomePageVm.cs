using SlottyMedia.Backend.Dtos;
using SlottyMedia.Components.Pages;

namespace SlottyMedia.Backend.ViewModel.Interfaces;

/// <summary>
///     This ViewModel represents the state of the <see cref="Home" /> page.
/// </summary>
public interface IHomePageVm
{
    /// <summary>Indicates whether the page is loading (for the first time)</summary>
    bool IsLoadingPage { get; }

    /// <summary>Indicates whether more posts are currently being loaded</summary>
    bool IsLoadingPosts { get; }

    /// <summary>The posts that will be showcased</summary>
    List<PostDto> Posts { get; }

    /// <summary>The total number of existing posts. Used to enable the user to load more posts on demand.</summary>
    int TotalNumberOfPosts { get; }

    /// <summary>
    ///     Initializes this ViewModel, which counts the total number of existing posts and loads the first few
    ///     posts into the view.
    /// </summary>
    Task Initialize();

    /// <summary>
    ///     Loads more posts to the view. Does nothing if all posts have already been fetched.
    /// </summary>
    Task LoadMorePosts();
}
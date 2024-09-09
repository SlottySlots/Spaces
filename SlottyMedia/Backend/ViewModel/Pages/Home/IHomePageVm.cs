using SlottyMedia.Backend.Dtos;
using SlottyMedia.Components.Pages;
using SlottyMedia.Database.Pagination;

namespace SlottyMedia.Backend.ViewModel.Pages.Home;

/// <summary>
///     This ViewModel represents the state of the <see cref="Home" /> page.
/// </summary>
public interface IHomePageVm
{
    /// <summary>
    ///     The ID of the currently logged in user.
    /// </summary>
    public Guid? AuthPrincipalId { get; }
    
    /// <summary>Indicates whether the page is loading (for the first time)</summary>
    bool IsLoadingPage { get; }

    /// <summary>The posts that will be showcased</summary>
    IPage<PostDto> Page { get; }

    /// <summary>
    ///     Initializes this ViewModel, which counts the total number of existing posts and loads the first few
    ///     posts into the view.
    /// </summary>
    Task Initialize();

    /// <summary>
    ///     Loads more posts to the view. Does nothing if all posts have already been fetched.
    /// </summary>
    Task LoadPage(int pageNumber);
}
using SlottyMedia.Backend.Dtos;
using SlottyMedia.Components.Pages;
using SlottyMedia.Database.Pagination;

namespace SlottyMedia.Backend.ViewModel.Interfaces;

    
/// <summary>
///     This ViewModel represents the state of the Space Page.
/// </summary>
public interface ISpaceVm
{
    /// <summary>
    ///     Whether the whole page is being loaded
    /// </summary>
    public bool IsLoadingPage { get; }
    
    
    /// <summary>
    ///     Whether the posts on the page are being loaded
    /// </summary>
    public bool IsLoadingPosts { get; }
    
    /// <summary>
    ///     The authentication principal's user ID (i.e. the user that's logged in)
    /// </summary>
    public Guid? AuthPrincipalId { get; }
    
    /// <summary>
    ///     Fetches the details of a specific space based on its id
    ///     and populates the <see cref="Space" /> property.
    /// </summary>
    /// <param name="id">The id of the space to load information for.</param>
    public Task LoadSpaceDetails(Guid id);
    
    /// <summary>
    ///     The posts that are currently being rendered
    /// </summary>
    public IPage<PostDto> Posts { get; }

    /// <summary>
    ///     Initialized the page's state. This fetches all space-related information and loads
    ///     the first posts for the visited space. Also initializes the <see cref="AuthPrincipalId" />
    ///     if one is present.
    /// </summary>
    /// <param name="forumId">The ID of the space whose page should be visited</param>
    public Task Initialize(Guid forumId);
    
    string Topic { get; }
    int PostCount { get; }
    DateTime CreatedAt { get; }
  
    /// <summary>
    ///     Loads more <see cref="Posts" /> for the visited space by changing the current
    ///     page (as in pagination).
    /// </summary>
    /// <param name="pageNumber">The page number</param>
    public Task LoadPosts(int pageNumber);
}
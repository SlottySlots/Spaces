using SlottyMedia.Backend.Dtos;
using SlottyMedia.Components.Pages;
using SlottyMedia.Database.Pagination;

namespace SlottyMedia.Backend.ViewModel.Pages.Profile;

/// <summary>
///     This ViewModel represents the <see cref="Profile" /> page.
/// </summary>
public interface IProfilePageVm
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
    ///     Whether the authentication principal is following the user whose profile is being visited
    /// </summary>
    public bool IsUserFollowed { get; }

    /// <summary>
    ///     Whether the visited profile is actually the authentication principal's profile
    ///     (i.e. if this is your own profile page).
    /// </summary>
    public bool IsOwnProfilePage { get; }

    /// <summary>
    ///     The authentication principal's user ID (i.e. the user that's logged in)
    /// </summary>
    public Guid? AuthPrincipalId { get; }

    /// <summary>
    ///     Information about the user whose profile is being visited
    /// </summary>
    public UserInformationDto? UserInfo { get; }

    /// <summary>
    ///     The posts that are currently being rendered
    /// </summary>
    public IPage<PostDto> Posts { get; }

    /// <summary>
    ///     Initialized the page's state. This fetches all user-related information and loads
    ///     the first posts for the visited user. Also initializes the <see cref="AuthPrincipalId" />
    ///     if one is present.
    /// </summary>
    /// <param name="userId">The ID of the user whose profile should be visited</param>
    public Task Initialize(Guid userId);

    /// <summary>
    ///     Has the authentication principal follow the visited profile. Does
    ///     nothing if no authentication principal is present.
    /// </summary>
    public Task FollowThisUser();

    /// <summary>
    ///     Has the authentication principal unfollow the visited profile. Does
    ///     nothing if no authentication principal is present.
    /// </summary>
    public Task UnfollowThisUser();

    /// <summary>
    ///     Loads more <see cref="Posts" /> for the visited profile by changing the current
    ///     page (as in pagination).
    /// </summary>
    /// <param name="pageNumber">The page number</param>
    public Task LoadPosts(int pageNumber);

    /// <summary>
    ///     An event that is triggered when the avatar is clicked.
    ///     It should update the profile picture if the user is on their own
    ///     profile page.
    /// </summary>
    /// <param name="imgB64">The new profile page as a base 64 string</param>
    public Task OnAvatarClick(string imgB64);

    /// <summary>
    ///     An event that is triggered when the user updates their own description.
    /// </summary>
    /// <param name="description">The new description</param>
    public Task OnDescriptionUpdate(string description);
}
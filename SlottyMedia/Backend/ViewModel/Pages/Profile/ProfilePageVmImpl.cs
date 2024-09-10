using SlottyMedia.Backend.Dtos;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Database.Pagination;
using SlottyMedia.LoggingProvider;

namespace SlottyMedia.Backend.ViewModel.Pages.Profile;

/// <summary>
///     Viewmodel used for the profile page /profile?id=..
/// </summary>
public class ProfilePageVmImpl : IProfilePageVm
{
    private readonly IAuthService _authService;
    private readonly Logging<ProfilePageVmImpl> _logger = new();
    private readonly IPostService _postService;
    private readonly IUserService _userService;

    /// <summary>
    ///     Ctor for dep inject
    /// </summary>
    public ProfilePageVmImpl(IUserService userService, IPostService postService, IAuthService authService)
    {
        _userService = userService;
        _postService = postService;
        _authService = authService;
    }

    /// <inheritdoc />
    public bool IsLoadingPage { get; private set; }

    /// <inheritdoc />
    public bool IsLoadingPosts { get; private set; }

    /// <inheritdoc />
    public bool IsUserFollowed { get; private set; }

    /// <inheritdoc />
    public bool IsOwnProfilePage { get; private set; }

    /// <inheritdoc />
    public Guid? AuthPrincipalId { get; private set; }

    /// <inheritdoc />
    public UserInformationDto? UserInfo { get; private set; }

    /// <inheritdoc />
    public IPage<PostDto> Posts { get; private set; } = PageImpl<PostDto>.Empty();

    /// <inheritdoc />
    public async Task Initialize(Guid userId)
    {
        IsLoadingPage = true;
        _logger.LogInfo("Profile Page: Loading necessary user-related information...");
        var authPrincipalIdStr = _authService.GetCurrentSession()?.User?.Id;
        AuthPrincipalId = authPrincipalIdStr is null ? null : Guid.Parse(authPrincipalIdStr);
        IsOwnProfilePage = AuthPrincipalId == userId;
        await _loadUserInfo(userId);
        await _loadIsUserFollowed();
        _logger.LogInfo("Profile Page: Successfully loaded all user-related information");
        IsLoadingPage = false;
        await LoadPosts(0);
    }

    /// <inheritdoc />
    public async Task LoadPosts(int pageNumber)
    {
        IsLoadingPosts = true;
        _logger.LogInfo($"Profile Page: Loading posts for user '{UserInfo!.Username}'. Loading page {pageNumber}...");
        Posts = await _postService.GetPostsByUserId(
            UserInfo.UserId!.Value,
            PageRequest.Of(pageNumber, 10));
        _logger.LogInfo($"Profile Page: Successfully loaded page {pageNumber}, which contains {Posts.Count()} posts");
        IsLoadingPosts = false;
    }

    /// <inheritdoc />
    public async Task FollowThisUser()
    {
        if (AuthPrincipalId is not null && UserInfo!.UserId is not null)
        {
            _logger.LogInfo($"Attempting to follow user '{UserInfo!.Username}'...");
            await _userService.FollowUserById(AuthPrincipalId.Value, UserInfo.UserId.Value);
            IsUserFollowed = true;
            _logger.LogInfo($"Successfully followed user '{UserInfo!.Username}'");
        }
    }

    /// <inheritdoc />
    public async Task UnfollowThisUser()
    {
        if (AuthPrincipalId is not null && UserInfo!.UserId is not null)
        {
            _logger.LogInfo($"Attempting to un-follow user '{UserInfo!.Username}'...");
            await _userService.UnfollowUserById(AuthPrincipalId.Value, UserInfo.UserId.Value);
            IsUserFollowed = false;
            _logger.LogInfo($"Successfully un-followed user '{UserInfo!.Username}'");
        }
    }

    /// <inheritdoc />
    public async Task OnAvatarClick(string imgB64)
    {
        if (!IsOwnProfilePage)
            return;
        var user = await _userService.GetUserDaoById(AuthPrincipalId!.Value);
        user.ProfilePic = imgB64;
        await _userService.UpdateUser(user);
    }

    /// <inheritdoc />
    public async Task OnDescriptionUpdate(string description)
    {
        if (!IsOwnProfilePage)
            return;
        var user = await _userService.GetUserDaoById(AuthPrincipalId!.Value);
        user.Description = description;
        await _userService.UpdateUser(user);
    }

    private async Task _loadUserInfo(Guid userId)
    {
        _logger.LogDebug($"Profile Page: Fetching user information for user with ID '{userId}'");
        UserInfo = await _userService.GetUserInfo(userId);
    }

    private async Task _loadIsUserFollowed()
    {
        if (AuthPrincipalId is null)
        {
            IsUserFollowed = false;
            return;
        }

        IsUserFollowed = await _userService.UserFollowRelation(UserInfo!.UserId!.Value, AuthPrincipalId!.Value);
    }
}
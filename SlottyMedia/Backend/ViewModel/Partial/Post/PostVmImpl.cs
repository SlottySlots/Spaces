using Microsoft.AspNetCore.Components;
using SlottyMedia.Backend.Dtos;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.LoggingProvider;

namespace SlottyMedia.Backend.ViewModel.Partial.Post;

/// <summary>
///     ViewModel for Post
/// </summary>
public class PostVmImpl : IPostVm
{
    private static readonly Logging<PostVmImpl> Logger = new();

    private readonly IPostService _postService;
    private readonly ICommentService _commentService;
    private readonly ILikeService _likeService;
    private readonly IUserService _userService;
    private readonly IAuthService _authService;
    private readonly NavigationManager _navigationManager;

    private Action? _onStateChanged;

    /// <summary>
    ///     The constructor for PostVmImpl
    /// </summary>
    public PostVmImpl(
        IPostService postService,
        IUserService userService,
        ILikeService likeService,
        ICommentService commentService,
        IAuthService authService,
        NavigationManager navigationManager)
    {
        _postService = postService;
        _userService = userService;
        _likeService = likeService;
        _commentService = commentService;
        _authService = authService;
        _navigationManager = navigationManager;
    }

    /// <inheritdoc />
    public Guid? AuthPrincipalId { get; private set; }

    /// <inheritdoc />
    public bool IsPostLiked { get; private set; }

    /// <inheritdoc />
    public bool IsLoading { get; private set; }

    /// <inheritdoc />
    public PostDto? PostDto { get; private set; }

    /// <inheritdoc />
    public int CommentCount { get; private set; }

    /// <inheritdoc />
    public int LikeCount { get; private set; }

    /// <inheritdoc />
    public UserInformationDto UserInformation { get; private set; } = new(true);

    /// <inheritdoc />
    public async Task Initialize(Guid postId, Action onStateChanged)
    {
        IsLoading = true;
        Logger.LogInfo("PostVmImpl: Loading necessary post-related information...");

        _onStateChanged = onStateChanged;
        PostDto = await _postService.GetPostById(postId);
        AuthPrincipalId = _authService.GetAuthPrincipalId();
        CommentCount = await _commentService.CountCommentsInPost(postId);
        
        var likes = await _likeService.GetLikesForPost(postId);
        LikeCount = likes.Count;
        if (AuthPrincipalId is not null)
            IsPostLiked = likes.Contains(AuthPrincipalId!.Value);

        UserInformation = (await _userService.GetUserInfo(PostDto!.UserId, false, false))!;
                
        Logger.LogInfo("PostVmImpl: Successfully loaded all post-related information");
        IsLoading = false;
    }

    /// <inheritdoc />
    public async Task LikeThisPost()
    {
        Logger.LogInfo("Attempting to (un)like post...");
        if (AuthPrincipalId is null)
        {
            Logger.LogError($"An unauthenticated user attempted to like a post. Aborting liking operation...");
            return;
        }
        if (IsPostLiked)
        {
            await _likeService.DeleteLike(AuthPrincipalId!.Value, PostDto!.PostId);
            LikeCount--;
            IsPostLiked = false;
        }
        else
        {
            await _likeService.InsertLike(AuthPrincipalId!.Value, PostDto!.PostId);
            LikeCount++;
            IsPostLiked = true;
        }
        _onStateChanged?.Invoke();
        Logger.LogInfo("Successfully (un)liked post");
    }

    /// <inheritdoc />
    public void GoToPostPage()
    {
        _navigationManager.NavigateTo($"/post/{PostDto!.PostId}");
    }
    
    /// <inheritdoc />
    public void GoToProfilePage()
    {
        _navigationManager.NavigateTo($"/profile/{PostDto!.UserId}");
    }
}
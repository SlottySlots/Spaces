using SlottyMedia.Backend.Dtos;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Backend.ViewModel.Interfaces;
using SlottyMedia.LoggingProvider;

namespace SlottyMedia.Backend.ViewModel;

/// <summary>
///     ViewModel for Post
/// </summary>
public class PostVmImpl : IPostVm
{
    private readonly ICommentService _commentService;
    private readonly ILikeService _likeService;
    private readonly Logging<PostVmImpl> _logger = new();
    private readonly IUserService _userService;

    /// <summary>
    ///     The constructor for PostVmImpl
    /// </summary>
    /// <param name="userService"></param>
    /// <param name="likeService"></param>
    /// <param name="commentService"></param>
    public PostVmImpl(IUserService userService, ILikeService likeService, ICommentService commentService)
    {
        _userService = userService;
        _likeService = likeService;
        _commentService = commentService;
    }

    /// <inheritdoc />
    public int CommentCount { get; private set; }

    /// <inheritdoc />
    public bool InitLiked { get; private set; }

    /// <inheritdoc />
    public bool IsLoading { get; private set; }

    /// <inheritdoc />
    public int LikeCount { get; private set; }

    /// <inheritdoc />
    public UserInformationDto UserInformation { get; private set; } = new(true);

    /// <inheritdoc />
    public async Task Initialize(Guid postId, Guid userId)
    {
        IsLoading = true;
        _logger.LogInfo("PostVmImpl: Loading necessary post-related information...");
        await GetCommentsCount(postId);
        //  await GetUserInformation(userId);
        await GetLikes(postId, userId);
        _logger.LogInfo("PostVmImpl: Successfully loaded all post-related information");
        IsLoading = false;
    }

    /// <inheritdoc />
    public async Task LikePost(Guid postId, Guid userId)
    {
        try
        {
            if (InitLiked)
            {
                await RemoveLike(postId, userId);
                LikeCount--;
                InitLiked = false;
            }
            else
            {
                await AddLike(postId, userId);
                LikeCount++;
                InitLiked = true;
            }
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"An error occurred while liking postId {postId} by userId {userId}");
        }
    }

    /// <inheritdoc />
    public async Task GetUserInformation(Guid userId, bool firstRender)
    {
        try
        {
            UserInformation = await _userService.GetUserInfo(userId, false, false) ?? new UserInformationDto();
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"An error occurred while retrieving user information for userId {userId}");
        }
    }

    /// <summary>
    ///     Adds a like to a post by a user.
    /// </summary>
    /// <param name="postId">The ID of the post.</param>
    /// <param name="userId">The ID of the user.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    private async Task AddLike(Guid postId, Guid userId)
    {
        try
        {
            await _likeService.InsertLike(userId, postId);
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"An error occurred while adding like to postId {postId} by userId {userId}");
        }
    }

    /// <summary>
    ///     Removes a like from a post by a user.
    /// </summary>
    /// <param name="postId">The ID of the post.</param>
    /// <param name="userId">The ID of the user.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    private async Task RemoveLike(Guid postId, Guid userId)
    {
        try
        {
            await _likeService.DeleteLike(userId, postId);
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"An error occurred while removing like from postId {postId} by userId {userId}");
        }
    }

    /// <summary>
    ///     Retrieves the count of comments for a post.
    /// </summary>
    /// <param name="postId">The ID of the post.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the count of comments.</returns>
    private async Task GetCommentsCount(Guid postId)
    {
        try
        {
            CommentCount = await _commentService.CountCommentsInPost(postId);
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"An error occurred while counting comments for postId {postId}");
        }
    }

    /// <summary>
    ///     Retrieves the list of likes for a post.
    /// </summary>
    /// <param name="postId">The ID of the post.</param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains the list of user IDs who liked the
    ///     post.
    /// </returns>
    private async Task GetLikes(Guid postId, Guid userId)
    {
        try
        {
            var result = await _likeService.GetLikesForPost(postId);

            LikeCount = result.Count;
            InitLiked = result.Contains(userId);
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"An error occurred while retrieving likes for postId {postId}");
        }
    }
}
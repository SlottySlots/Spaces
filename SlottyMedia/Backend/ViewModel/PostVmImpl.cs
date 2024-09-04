using SlottyMedia.Backend.Dtos;
using SlottyMedia.Backend.Services;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Backend.ViewModel.Interfaces;
using SlottyMedia.LoggingProvider;

namespace SlottyMedia.Backend.ViewModel;

/// <summary>
/// ViewModel for Post
/// </summary>
public class PostVmImpl : IPostVm
{
    private readonly ICommentService _commentService;
    private readonly ILikeService _likeService;
    private readonly Logging<PostVmImpl> _logger = new();
    private readonly IUserService _userService;

    /// <summary>
    /// The constructor for PostVmImpl
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
    public async Task<UserDto> GetOwner(Guid userId)
    {
        try
        {
            return await _userService.GetUserDtoById(userId);
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"An error occurred while retrieving owner with userId {userId}");
            return new UserDto();
        }
    }

    /// <inheritdoc />
    public async Task<int> GetCommentsCount(Guid postId)
    {
        try
        {
            return await _commentService.CountCommentsInPost(postId);
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"An error occurred while counting comments for postId {postId}");
            return 0;
        }
    }

    /// <inheritdoc />
    public async Task<UserInformationDto> GetUserInformation(Guid userId)
    {
        try
        {
            return await _userService.GetUserInfo(userId) ?? new UserInformationDto();
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"An error occurred while retrieving user information for userId {userId}");
            return new UserInformationDto();
        }
    }

    /// <inheritdoc />
    public async Task<List<Guid>?> GetLikes(Guid postId)
    {
        try
        {
            return await _likeService.GetLikesForPost(postId);
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"An error occurred while retrieving likes for postId {postId}");
            return null;
        }
    }

    /// <inheritdoc />
    public async Task AddLike(Guid postId, Guid userId)
    {
        try
        {
            await _likeService.InsertLike(postId, userId);
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"An error occurred while adding like to postId {postId} by userId {userId}");
        }
    }

    /// <inheritdoc />
    public async Task RemoveLike(Guid postId, Guid userId)
    {
        try
        {
            await _likeService.DeleteLike(postId, userId);
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"An error occurred while removing like from postId {postId} by userId {userId}");
        }
    }
}
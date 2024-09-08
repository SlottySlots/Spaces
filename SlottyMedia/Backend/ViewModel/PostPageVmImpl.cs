using SlottyMedia.Backend.Dtos;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Backend.ViewModel.Interfaces;
using SlottyMedia.Database.Pagination;
using SlottyMedia.LoggingProvider;

namespace SlottyMedia.Backend.ViewModel;

/// <inheritdoc />
public class PostPageVmImpl : IPostPageVm
{
    private static readonly Logging<PostPageVmImpl> _logger = new();
    private readonly IAuthService _authService;
    private readonly ICommentService _commentService;

    private readonly IPostService _postService;

    /// <summary>Instantiates this VM</summary>
    public PostPageVmImpl(IPostService postService, ICommentService commentService, IAuthService authService)
    {
        _postService = postService;
        _commentService = commentService;
        _authService = authService;
    }

    /// <inheritdoc />
    public bool IsLoadingPage { get; private set; }

    /// <inheritdoc />
    public bool IsLoadingComments { get; private set; }

    /// <inheritdoc />
    public PostDto? Post { get; private set; }

    /// <inheritdoc />
    public IPage<CommentDto> Comments { get; private set; } = PageImpl<CommentDto>.Empty();

    /// <inheritdoc />
    public Guid CurrentUserId { get; private set; }

    /// <inheritdoc />
    public bool IsAuthenticated { get; private set; }

    /// <inheritdoc />
    public async Task Initialize(Guid postId)
    {
        _logger.LogInfo($"Loading page for post wih ID {postId}");
        IsLoadingPage = true;
        Post = await _postService.GetPostById(postId);
        if (Post is null)
            _logger.LogWarn($"Attempting to load page for a nonexistent post ID: {postId}");
        else
            await LoadCommentsPage(0);
        CurrentUserId = Guid.Parse(_authService.GetCurrentSession()!.User!.Id!);
        IsAuthenticated = _authService.IsAuthenticated();
        IsLoadingPage = false;
    }

    /// <inheritdoc />
    public async Task LoadCommentsPage(int pageNumber)
    {
        if (IsLoadingComments)
            return;
        if (Post is null)
        {
            _logger.LogWarn("Attempted to load comments for nonexistent post");
            return;
        }

        _logger.LogInfo($"Loading comments for post with ID {Post?.PostId}");
        IsLoadingComments = true;
        Comments = await _commentService.GetCommentsInPost(Post!.PostId, PageRequest.Of(pageNumber, 5));
        _logger.LogInfo($"Fetched {Comments.Count()} comments for post with ID {Post!.PostId}");
        IsLoadingComments = false;
    }
}
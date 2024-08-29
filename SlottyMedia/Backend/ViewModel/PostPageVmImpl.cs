using SlottyMedia.Backend.Dtos;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Backend.ViewModel.Interfaces;
using SlottyMedia.LoggingProvider;

namespace SlottyMedia.Backend.ViewModel;


/// <inheritdoc />
public class PostPageVmImpl : IPostPageVm
{
    private static Logging<PostPageVmImpl> _logger = new();
    
    private readonly IPostService _postService;
    private readonly ICommentService _commentService;
    private int _currentCommentPage;

    /// <summary>Instantiates this VM</summary>
    public PostPageVmImpl(IPostService postService, ICommentService commentService)
    {
        _postService = postService;
        _commentService = commentService;
    }

    /// <inheritdoc />
    public bool IsLoadingPage { get; private set; }
    
    /// <inheritdoc />
    public bool IsLoadingComments { get; private set; }

    /// <inheritdoc />
    public PostDto? Post { get; private set; }

    /// <inheritdoc />
    public List<CommentDto> Comments { get; private set; } = [];
    
    /// <inheritdoc />
    public async Task LoadPage(Guid postId)
    {
        _logger.LogInfo($"Loading page for post wih ID {postId}");
        IsLoadingPage = true;
        _currentCommentPage = 0;
        Comments = [];
        Post = await _postService.GetPostById(postId);
        if (Post is null)
            _logger.LogWarn($"Attempting to load page for a nonexistent post ID: {postId}");
        else
            await LoadMoreComments();
        IsLoadingPage = false;
    }

    /// <inheritdoc />
    public async Task LoadMoreComments()
    {
        if (Post is null)
        {
            _logger.LogWarn($"Attempted to load comments for nonexistent post");
            return;
        }
        _logger.LogInfo($"Loading comments for post with ID {Post?.PostId} (already fetched {5 * _currentCommentPage} comments)");
        IsLoadingComments = true;
        _currentCommentPage++;
        var results = await _commentService.GetCommentsInPost(Post!.PostId, _currentCommentPage, 5);
        _logger.LogInfo($"Fetched {results.Count} additional comments for post with ID {Post!.PostId}");
        foreach (var comment in results)
            Comments.Add(comment);
        IsLoadingComments = false;
    }
}
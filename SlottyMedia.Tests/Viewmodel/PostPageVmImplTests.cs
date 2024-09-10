using Moq;
using SlottyMedia.Backend.Dtos;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Backend.ViewModel;
using SlottyMedia.Database.Pagination;
using Supabase.Gotrue;

namespace SlottyMedia.Tests.Viewmodel;

/// <summary>
///     Unit tests for the PostPageVmImpl class.
/// </summary>
[TestFixture]
public class PostPageVmImplTests
{
    /// <summary>
    ///     Sets up the test environment by initializing mocks and the PostPageVmImpl instance.
    /// </summary>
    [SetUp]
    public void SetUp()
    {
        _mockPostService = new Mock<IPostService>();
        _mockCommentService = new Mock<ICommentService>();
        _authService = new Mock<IAuthService>();
        _postPageVmImpl = new PostPageVmImpl(_mockPostService.Object, _mockCommentService.Object, _authService.Object);
    }

    private Mock<IPostService> _mockPostService;
    private Mock<ICommentService> _mockCommentService;
    private PostPageVmImpl _postPageVmImpl;
    private Mock<IAuthService> _authService;

    /// <summary>
    ///     Tests that Initialize method sets the Post and loads the first page of comments.
    /// </summary>
    [Test]
    public async Task Initialize_SetsPostAndLoadsFirstCommentsPage()
    {
        var postId = Guid.NewGuid();
        var post = new PostDto { PostId = postId };
        var comments = new PageImpl<CommentDto>(
            new List<CommentDto> { new() },
            0, // PageNumber
            5, // PageSize
            1, // TotalPages
            pageNumber => Task.FromResult<IPage<CommentDto>>(null!) // Callback
        );
        _mockPostService.Setup(s => s.GetPostById(postId)).ReturnsAsync(post);
        _mockCommentService.Setup(s => s.GetCommentsInPost(postId, It.IsAny<PageRequest>())).ReturnsAsync(comments);
        _authService.Setup(s => s.IsAuthenticated()).Returns(true);
        _authService.Setup(s => s.GetCurrentSession())
            .Returns(new Session { User = new User { Id = Guid.NewGuid().ToString() } });

        await _postPageVmImpl.Initialize(postId);

        Assert.That(_postPageVmImpl.IsLoadingPage, Is.False);
        Assert.That(_postPageVmImpl.Post, Is.EqualTo(post));
        Assert.That(_postPageVmImpl.Comments.Content.Count, Is.EqualTo(1));
    }

    /// <summary>
    ///     Tests that Initialize method sets the Post property to null when the post is not found.
    /// </summary>
    [Test]
    public async Task Initialize_SetsPostToNullWhenPostNotFound()
    {
        var postId = Guid.NewGuid();
        _mockPostService.Setup(s => s.GetPostById(postId)).ReturnsAsync((PostDto?)null);
        _authService.Setup(s => s.GetCurrentSession())
            .Returns(new Session { User = new User { Id = Guid.NewGuid().ToString() } });

        await _postPageVmImpl.Initialize(postId);

        Assert.That(_postPageVmImpl.IsLoadingPage, Is.False);
        Assert.That(_postPageVmImpl.Post, Is.Null);
    }

    /// <summary>
    ///     Tests that LoadCommentsPage method adds comments to the Comments list.
    /// </summary>
    [Test]
    public async Task LoadCommentsPage_AddsCommentsToList()
    {
        var postId = Guid.NewGuid();
        var post = new PostDto { PostId = postId };
        var comments = new PageImpl<CommentDto>(
            new List<CommentDto> { new() },
            0, // PageNumber
            5, // PageSize
            1, // TotalPages
            pageNumber => Task.FromResult<IPage<CommentDto>>(null!) // Callback
        );
        _mockPostService.Setup(s => s.GetPostById(postId)).ReturnsAsync(post);
        _mockCommentService.Setup(s => s.GetCommentsInPost(postId, It.IsAny<PageRequest>())).ReturnsAsync(comments);
        _authService.Setup(s => s.GetCurrentSession())
            .Returns(new Session { User = new User { Id = Guid.NewGuid().ToString() } });

        await _postPageVmImpl.Initialize(postId);

        var moreComments = new PageImpl<CommentDto>(
            new List<CommentDto> { new() },
            1, // PageNumber
            5, // PageSize
            1, // TotalPages
            pageNumber => Task.FromResult<IPage<CommentDto>>(null!) // Callback
        );
        _mockCommentService.Setup(s => s.GetCommentsInPost(postId, It.IsAny<PageRequest>())).ReturnsAsync(moreComments);

        await _postPageVmImpl.LoadCommentsPage(1);

        Assert.That(_postPageVmImpl.Comments.Content.Count, Is.EqualTo(1));
    }

    /// <summary>
    ///     Tests that LoadCommentsPage method does not load comments when the Post property is null.
    /// </summary>
    [Test]
    public async Task LoadCommentsPage_DoesNotLoadWhenPostIsNull()
    {
        await _postPageVmImpl.LoadCommentsPage(1);

        _mockCommentService.Verify(s => s.GetCommentsInPost(It.IsAny<Guid>(), It.IsAny<PageRequest>()), Times.Never);
    }
}
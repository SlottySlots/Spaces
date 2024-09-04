using Moq;
using SlottyMedia.Backend.Dtos;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Backend.ViewModel;

namespace SlottyMedia.Tests.Viewmodel;

/// <summary>
/// Unit tests for the PostPageVmImpl class.
/// </summary>
[TestFixture]
public class PostPageVmImplTests
{
    private Mock<IPostService> _mockPostService;
    private Mock<ICommentService> _mockCommentService;
    private PostPageVmImpl _postPageVmImpl;

    /// <summary>
    /// Sets up the test environment by initializing mocks and the PostPageVmImpl instance.
    /// </summary>
    [SetUp]
    public void SetUp()
    {
        _mockPostService = new Mock<IPostService>();
        _mockCommentService = new Mock<ICommentService>();
        _postPageVmImpl = new PostPageVmImpl(_mockPostService.Object, _mockCommentService.Object);
    }

    /// <summary>
    /// Tests that LoadPage method sets the Post and Comments properties.
    /// </summary>
    [Test]
    public async Task LoadPage_SetsPostAndComments()
    {
        var postId = Guid.NewGuid();
        var post = new PostDto { PostId = postId };
        var comments = new List<CommentDto> { new CommentDto(), new CommentDto() };
        _mockPostService.Setup(s => s.GetPostById(postId)).ReturnsAsync(post);
        _mockCommentService.Setup(s => s.CountCommentsInPost(postId)).ReturnsAsync(2);
        _mockCommentService.Setup(s => s.GetCommentsInPost(postId, 1, 5)).ReturnsAsync(comments);

        await _postPageVmImpl.LoadPage(postId);

        Assert.That(_postPageVmImpl.Post, Is.EqualTo(post));
        Assert.That(_postPageVmImpl.Comments, Is.EqualTo(comments));
        Assert.That(_postPageVmImpl.TotalNumberOfComments, Is.EqualTo(2));
    }

    /// <summary>
    /// Tests that LoadPage method sets the Post property to null when the post is not found.
    /// </summary>
    [Test]
    public async Task LoadPage_SetsPostToNullWhenPostNotFound()
    {
        var postId = Guid.NewGuid();
        _mockPostService.Setup(s => s.GetPostById(postId)).ReturnsAsync((PostDto?)null);

        await _postPageVmImpl.LoadPage(postId);

        Assert.That(_postPageVmImpl.Post, Is.Null);
    }

    /// <summary>
    /// Tests that LoadMoreComments method adds comments to the Comments list.
    /// </summary>
    [Test]
    public async Task LoadMoreComments_AddsCommentsToList()
    {
        var postId = Guid.NewGuid();
        var post = new PostDto { PostId = postId };
        var comments = new List<CommentDto> { new CommentDto(), new CommentDto() };
        _mockPostService.Setup(s => s.GetPostById(postId)).ReturnsAsync(post);
        _mockCommentService.Setup(s => s.GetCommentsInPost(postId, 1, 5)).ReturnsAsync(comments);
        await _postPageVmImpl.LoadPage(postId);

        var moreComments = new List<CommentDto> { new CommentDto() };
        _mockCommentService.Setup(s => s.GetCommentsInPost(postId, 2, 5)).ReturnsAsync(moreComments);

        await _postPageVmImpl.LoadMoreComments();

        Assert.That(_postPageVmImpl.Comments.Count, Is.EqualTo(3));
    }

    /// <summary>
    /// Tests that LoadMoreComments method does not load comments when the Post property is null.
    /// </summary>
    [Test]
    public async Task LoadMoreComments_DoesNotLoadWhenPostIsNull()
    {
        await _postPageVmImpl.LoadMoreComments();

        _mockCommentService.Verify(s => s.GetCommentsInPost(It.IsAny<Guid>(), It.IsAny<int>(), It.IsAny<int>()), Times.Never);
    }
}
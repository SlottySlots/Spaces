using System.Diagnostics;
using Moq;
using SlottyMedia.Backend.Dtos;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Backend.ViewModel;

namespace SlottyMedia.Tests.Viewmodel;

/// <summary>
/// Unit tests for the PostVmImpl class.
/// </summary>
[TestFixture]
public class PostVmImplTests
{
    private Mock<ICommentService> _mockCommentService;
    private Mock<ILikeService> _mockLikeService;
    private Mock<IUserService> _mockUserService;
    private PostVmImpl _postVm;

    /// <summary>
    /// Sets up the test environment before each test.
    /// </summary>
    [SetUp]
    public void SetUp()
    {
        _mockCommentService = new Mock<ICommentService>();
        _mockLikeService = new Mock<ILikeService>();
        _mockUserService = new Mock<IUserService>();
        _postVm = new PostVmImpl(_mockUserService.Object, _mockLikeService.Object, _mockCommentService.Object);
    }

    /// <summary>
    /// Tests that Initialize method loads all post-related information.
    /// </summary>
    [Test]
    public async Task Initialize_LoadsAllPostRelatedInformation()
    {
        var postId = Guid.NewGuid();
        var userId = Guid.NewGuid();
        _mockCommentService.Setup(s => s.CountCommentsInPost(postId)).ReturnsAsync(5);
        _mockLikeService.Setup(s => s.GetLikesForPost(postId)).ReturnsAsync(new List<Guid> { userId });

        await _postVm.Initialize(postId, userId, Guid.NewGuid());

        Assert.That(_postVm.IsLoading, Is.False);
        Assert.That(_postVm.CommentCount, Is.EqualTo(5));
        Assert.That(_postVm.LikeCount, Is.EqualTo(1));
        Assert.That(_postVm.InitLiked, Is.True);
    }

    /// <summary>
    /// Tests that LikePost method adds a like when the post was not previously liked.
    /// </summary>
    [Test]
    public async Task LikePost_AddsLikeWhenNotPreviouslyLiked()
    {
        var postId = Guid.NewGuid();
        var userId = Guid.NewGuid();
        _mockLikeService.Setup(s => s.InsertLike(userId, postId)).ReturnsAsync(true);

        await _postVm.LikePost(postId, userId, false);

        Assert.That(_postVm.LikeCount, Is.EqualTo(1));
        Assert.That(_postVm.InitLiked, Is.True);
    }

    /// <summary>
    /// Tests that LikePost method removes a like when the post was previously liked.
    /// </summary>
    [Test]
    public async Task LikePost_RemovesLikeWhenPreviouslyLiked()
    {
        var postId = Guid.NewGuid();
        var userId = Guid.NewGuid();
        _mockLikeService.Setup(s => s.DeleteLike(userId, postId)).ReturnsAsync(true);

        await _postVm.LikePost(postId, userId, true);

        Assert.That(_postVm.LikeCount, Is.EqualTo(-1));
        Assert.That(_postVm.InitLiked, Is.False);
    }

    /// <summary>
    /// Tests that GetUserInformation method sets the user information.
    /// </summary>
    [Test]
    public async Task GetUserInformation_SetsUserInformation()
    {
        var userId = Guid.NewGuid();
        var userInfo = new UserInformationDto();
        _mockUserService.Setup(s => s.GetUserInfo(userId, false, false)).ReturnsAsync(userInfo);

        await _postVm.GetUserInformation(userId, false);

        Assert.That(_postVm.UserInformation, Is.EqualTo(userInfo));
    }

    /// <summary>
    /// Tests that GetCommentsCount method sets the comment count.
    /// </summary>
    [Test]
    public async Task GetCommentsCount_SetsCommentCount()
    {
        var postId = Guid.NewGuid();
        _mockCommentService.Setup(s => s.CountCommentsInPost(postId)).ReturnsAsync(10);

        await _postVm.Initialize(postId, Guid.NewGuid(), Guid.NewGuid());

        Assert.That(_postVm.CommentCount, Is.EqualTo(10));
    }

    /// <summary>
    /// Tests that GetLikes method sets the like count and initializes the liked state.
    /// </summary>
    [Test]
    public async Task GetLikes_SetsLikeCountAndInitLiked()
    {
        var postId = Guid.NewGuid();
        var userId = Guid.NewGuid();
        var likes = new List<Guid> { userId };
        _mockLikeService.Setup(s => s.GetLikesForPost(postId)).ReturnsAsync(likes);

        await _postVm.Initialize(postId, userId, Guid.NewGuid());

        Assert.That(_postVm.LikeCount, Is.EqualTo(1));
        Assert.That(_postVm.InitLiked, Is.True);
    }
}
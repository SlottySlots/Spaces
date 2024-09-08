using System.Diagnostics;
using Moq;
using SlottyMedia.Backend.Dtos;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Backend.ViewModel;

namespace SlottyMedia.Tests.Viewmodel;

[TestFixture]
public class PostVmImplTests
{
    private Mock<ICommentService> _mockCommentService;
    private Mock<ILikeService> _mockLikeService;
    private Mock<IUserService> _mockUserService;
    private PostVmImpl _postVm;

    [SetUp]
    public void SetUp()
    {
        _mockCommentService = new Mock<ICommentService>();
        _mockLikeService = new Mock<ILikeService>();
        _mockUserService = new Mock<IUserService>();
        _postVm = new PostVmImpl(_mockUserService.Object, _mockLikeService.Object, _mockCommentService.Object);
    }

    [Test]
    public async Task Initialize_LoadsAllPostRelatedInformation()
    {
        var postId = Guid.NewGuid();
        var userId = Guid.NewGuid();
        _mockCommentService.Setup(s => s.CountCommentsInPost(postId)).ReturnsAsync(5);
        _mockLikeService.Setup(s => s.GetLikesForPost(postId)).ReturnsAsync(new List<Guid> { userId });

        await _postVm.Initialize(postId, userId);

        Assert.That(_postVm.IsLoading, Is.False);
        Assert.That(_postVm.CommentCount, Is.EqualTo(5));
        Assert.That(_postVm.LikeCount, Is.EqualTo(1));
        Assert.That(_postVm.InitLiked, Is.True);
    }

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

    [Test]
    public async Task GetUserInformation_SetsUserInformation()
    {
        var userId = Guid.NewGuid();
        var userInfo = new UserInformationDto();
        _mockUserService.Setup(s => s.GetUserInfo(userId, false, false)).ReturnsAsync(userInfo);

        await _postVm.GetUserInformation(userId, false);

        Assert.That(_postVm.UserInformation, Is.EqualTo(userInfo));
    }

    [Test]
    public async Task GetCommentsCount_SetsCommentCount()
    {
        var postId = Guid.NewGuid();
        _mockCommentService.Setup(s => s.CountCommentsInPost(postId)).ReturnsAsync(10);

        await _postVm.Initialize(postId, Guid.NewGuid());

        Assert.That(_postVm.CommentCount, Is.EqualTo(10));
    }

    [Test]
    public async Task GetLikes_SetsLikeCountAndInitLiked()
    {
        var postId = Guid.NewGuid();
        var userId = Guid.NewGuid();
        var likes = new List<Guid> { userId };
        _mockLikeService.Setup(s => s.GetLikesForPost(postId)).ReturnsAsync(likes);

        await _postVm.Initialize(postId, userId);

        Assert.That(_postVm.LikeCount, Is.EqualTo(1));
        Assert.That(_postVm.InitLiked, Is.True);
    }
}
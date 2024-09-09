using Microsoft.AspNetCore.Components;
using Moq;
using SlottyMedia.Backend.Dtos;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Backend.ViewModel.Partial.Post;

namespace SlottyMedia.Tests.Viewmodel;

/// <summary>
/// Unit tests for the PostVmImpl class.
/// </summary>
[TestFixture]
public class PostVmImplTests
{
    private Mock<IPostService> _mockPostService;
    private Mock<ICommentService> _mockCommentService;
    private Mock<ILikeService> _mockLikeService;
    private Mock<IUserService> _mockUserService;
    private Mock<IAuthService> _mockAuthService;
    private Mock<NavigationManager> _mockNavigationManager;
    
    private PostVmImpl _postVm;

    /// <summary>
    /// Sets up the test environment before each test.
    /// </summary>
    [SetUp]
    public void SetUp()
    {
        _mockPostService = new Mock<IPostService>();
        _mockCommentService = new Mock<ICommentService>();
        _mockLikeService = new Mock<ILikeService>();
        _mockUserService = new Mock<IUserService>();
        _mockAuthService = new Mock<IAuthService>();
        _mockNavigationManager = new Mock<NavigationManager>();
        
        _postVm = new PostVmImpl(
            _mockPostService.Object,
            _mockUserService.Object,
            _mockLikeService.Object,
            _mockCommentService.Object,
            _mockAuthService.Object,
            _mockNavigationManager.Object);
    }

    /// <summary>
    /// Tests that Initialize method loads all post-related information.
    /// </summary>
    [Test]
    public async Task Initialize_LoadsAllPostRelatedInformation()
    {
        var postId = Guid.NewGuid();
        var postOwnerId = Guid.NewGuid();
        var authPrincipalId = Guid.NewGuid();
        
        var postDto = new PostDto()
        {
            PostId = postId,
            UserId = postOwnerId
        };

        _mockPostService.Setup(s => s.GetPostById(postId)).ReturnsAsync(postDto);
        _mockCommentService.Setup(s => s.CountCommentsInPost(postId)).ReturnsAsync(5);
        _mockLikeService.Setup(s => s.GetLikesForPost(postId)).ReturnsAsync([authPrincipalId]);
        _mockAuthService.Setup(s => s.GetAuthPrincipalId()).Returns(authPrincipalId);

        await _postVm.Initialize(postId, () => {});

        Assert.Multiple(() =>
        {
            Assert.That(_postVm.IsLoading, Is.False);
            Assert.That(_postVm.CommentCount, Is.EqualTo(5));
            Assert.That(_postVm.LikeCount, Is.EqualTo(1));
            Assert.That(_postVm.IsPostLiked, Is.True);
        });
    }

    /// <summary>
    /// Tests that LikePost method adds a like when the post was not previously liked.
    /// </summary>
    [Test]
    public async Task LikeThisPost_WhenPostNotLiked_ShouldLikePost()
    {
        var postId = Guid.NewGuid();
        var postOwnerId = Guid.NewGuid();
        var authPrincipalId = Guid.NewGuid();
        
        var postDto = new PostDto()
        {
            PostId = postId,
            UserId = postOwnerId
        };

        _mockPostService.Setup(s => s.GetPostById(postId)).ReturnsAsync(postDto);
        _mockCommentService.Setup(s => s.CountCommentsInPost(postId)).ReturnsAsync(5);
        _mockLikeService.Setup(s => s.GetLikesForPost(postId)).ReturnsAsync([]);
        _mockAuthService.Setup(s => s.GetAuthPrincipalId()).Returns(authPrincipalId);
        _mockLikeService.Setup(s => s.InsertLike(authPrincipalId, postId)).ReturnsAsync(true);

        await _postVm.Initialize(postId, () => {});
        await _postVm.LikeThisPost();

        Assert.That(_postVm.IsPostLiked, Is.True);
    }

    /// <summary>
    /// Tests that LikePost method removes a like when the post was previously liked.
    /// </summary>
    [Test]
    public async Task LikeThisPost_WhenPostLiked_ShouldUnlikePost()
    {
        var postId = Guid.NewGuid();
        var postOwnerId = Guid.NewGuid();
        var authPrincipalId = Guid.NewGuid();
        
        var postDto = new PostDto()
        {
            PostId = postId,
            UserId = postOwnerId
        };

        _mockPostService.Setup(s => s.GetPostById(postId)).ReturnsAsync(postDto);
        _mockCommentService.Setup(s => s.CountCommentsInPost(postId)).ReturnsAsync(5);
        _mockLikeService.Setup(s => s.GetLikesForPost(postId)).ReturnsAsync([authPrincipalId]);
        _mockAuthService.Setup(s => s.GetAuthPrincipalId()).Returns(authPrincipalId);
        _mockLikeService.Setup(s => s.DeleteLike(authPrincipalId, postId)).ReturnsAsync(true);

        await _postVm.Initialize(postId, () => {});
        await _postVm.LikeThisPost();

        Assert.That(_postVm.IsPostLiked, Is.False);
    }
}
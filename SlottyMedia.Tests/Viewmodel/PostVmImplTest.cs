using Moq;
using SlottyMedia.Backend.Dtos;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Backend.ViewModel;

namespace SlottyMedia.Tests.Viewmodel;

/// <summary>
///     Unit tests for the PostVmImpl class.
/// </summary>
[TestFixture]
public class PostVmImplTests
{
    /// <summary>
    ///     Sets up the test environment by initializing mocks and the PostVmImpl instance.
    /// </summary>
    [SetUp]
    public void SetUp()
    {
        _mockUserService = new Mock<IUserService>();
        _mockLikeService = new Mock<ILikeService>();
        _mockCommentService = new Mock<ICommentService>();
        _postVmImpl = new PostVmImpl(_mockUserService.Object, _mockLikeService.Object, _mockCommentService.Object);
    }

    private Mock<IUserService> _mockUserService;
    private Mock<ILikeService> _mockLikeService;
    private Mock<ICommentService> _mockCommentService;
    private PostVmImpl _postVmImpl;

    /// <summary>
    ///     Tests that GetOwner method returns the expected UserDto.
    /// </summary>
    [Test]
    public async Task GetOwner_ReturnsUserDto()
    {
        var userId = Guid.NewGuid();
        var expectedUser = new UserDto { UserId = userId };
        _mockUserService.Setup(s => s.GetUserDtoById(userId)).ReturnsAsync(expectedUser);

        var result = await _postVmImpl.GetOwner(userId);

        Assert.That(result, Is.EqualTo(expectedUser));
    }

    /// <summary>
    ///     Tests that GetCommentsCount method returns the expected count of comments.
    /// </summary>
    [Test]
    public async Task GetCommentsCount_ReturnsCount()
    {
        var postId = Guid.NewGuid();
        var expectedCount = 5;
        _mockCommentService.Setup(s => s.CountCommentsInPost(postId)).ReturnsAsync(expectedCount);

        var result = await _postVmImpl.GetCommentsCount(postId);

        Assert.That(result, Is.EqualTo(expectedCount));
    }

    /// <summary>
    ///     Tests that GetUserInformation method returns the expected UserInformationDto.
    /// </summary>
    [Test]
    public async Task GetUserInformation_ReturnsUserInformationDto()
    {
        var userId = Guid.NewGuid();
        var expectedUserInfo = new UserInformationDto { UserId = userId };
        _mockUserService.Setup(s => s.GetUserInfo(userId, false, false)).ReturnsAsync(expectedUserInfo);

        var result = await _postVmImpl.GetUserInformation(userId);

        Assert.That(result, Is.EqualTo(expectedUserInfo));
    }

    /// <summary>
    ///     Tests that GetLikes method returns the expected list of Guids.
    /// </summary>
    [Test]
    public async Task GetLikes_ReturnsListOfGuids()
    {
        var postId = Guid.NewGuid();
        var expectedLikes = new List<Guid> { Guid.NewGuid(), Guid.NewGuid() };
        _mockLikeService.Setup(s => s.GetLikesForPost(postId)).ReturnsAsync(expectedLikes);

        var result = await _postVmImpl.GetLikes(postId);

        Assert.That(result, Is.EqualTo(expectedLikes));
    }

    /// <summary>
    ///     Tests that AddLike method calls InsertLike on the ILikeService mock.
    /// </summary>
    [Test]
    public async Task AddLike_CallsInsertLike()
    {
        var postId = Guid.NewGuid();
        var userId = Guid.NewGuid();

        await _postVmImpl.AddLike(postId, userId);

        _mockLikeService.Verify(s => s.InsertLike(postId, userId), Times.Once);
    }

    /// <summary>
    ///     Tests that RemoveLike method calls DeleteLike on the ILikeService mock.
    /// </summary>
    [Test]
    public async Task RemoveLike_CallsDeleteLike()
    {
        var postId = Guid.NewGuid();
        var userId = Guid.NewGuid();

        await _postVmImpl.RemoveLike(postId, userId);

        _mockLikeService.Verify(s => s.DeleteLike(postId, userId), Times.Once);
    }
}
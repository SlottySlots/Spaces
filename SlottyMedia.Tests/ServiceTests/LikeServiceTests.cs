using System.Linq.Expressions;
using Moq;
using SlottyMedia.Backend.Exceptions.Services.LikeExceptions;
using SlottyMedia.Backend.Services;
using SlottyMedia.Database.Daos;
using SlottyMedia.Database.Exceptions;
using SlottyMedia.Database.Repository.UserLikePostRelationRepo;
using Supabase.Postgrest;

namespace SlottyMedia.Tests.ServiceTests;

/// <summary>
///     Unit tests for the LikeService class.
/// </summary>
[TestFixture]
public class LikeServiceTests
{
    private Mock<IUserLikePostRelationRepostitory> _mockLikeRepository;
    private LikeService _likeService;

    /// <summary>
    ///     Sets up the test environment before each test.
    /// </summary>
    [SetUp]
    public void Setup()
    {
        _mockLikeRepository = new Mock<IUserLikePostRelationRepostitory>();
        _likeService = new LikeService(_mockLikeRepository.Object);
    }

    /// <summary>
    ///     Cleans up the test environment after each test.
    /// </summary>
    [TearDown]
    public void TearDown()
    {
        _mockLikeRepository.Reset();
    }

    [Test]
    public async Task InsertLike_ShouldReturnTrue_WhenLikeIsInsertedSuccessfully()
    {
        var userId = Guid.NewGuid();
        var postId = Guid.NewGuid();
        _mockLikeRepository.Setup(x => x.AddElement(It.IsAny<UserLikePostRelationDao>())).Returns(Task.CompletedTask);

        var result = await _likeService.InsertLike(userId, postId);

        Assert.That(result, Is.True);
        _mockLikeRepository.Verify(x => x.AddElement(It.IsAny<UserLikePostRelationDao>()), Times.Once);
    }

    [Test]
    public void InsertLike_ShouldThrowLikeIudException_WhenDatabaseIudActionExceptionIsThrown()
    {
        var userId = Guid.NewGuid();
        var postId = Guid.NewGuid();
        _mockLikeRepository.Setup(x => x.AddElement(It.IsAny<UserLikePostRelationDao>()))
            .ThrowsAsync(new DatabaseIudActionException());

        Assert.ThrowsAsync<LikeIudException>(async () => await _likeService.InsertLike(userId, postId));
    }

    [Test]
    public void InsertLike_ShouldThrowLikeGeneralException_WhenGeneralDatabaseExceptionIsThrown()
    {
        var userId = Guid.NewGuid();
        var postId = Guid.NewGuid();
        _mockLikeRepository.Setup(x => x.AddElement(It.IsAny<UserLikePostRelationDao>()))
            .ThrowsAsync(new GeneralDatabaseException());

        Assert.ThrowsAsync<LikeGeneralException>(async () => await _likeService.InsertLike(userId, postId));
    }

    [Test]
    public async Task DeleteLike_ShouldReturnTrue_WhenLikeIsDeletedSuccessfully()
    {
        var userId = Guid.NewGuid();
        var postId = Guid.NewGuid();
        _mockLikeRepository.Setup(x => x.DeleteElement(It.IsAny<UserLikePostRelationDao>())).Returns(Task.CompletedTask);

        var result = await _likeService.DeleteLike(userId, postId);

        Assert.That(result, Is.True);
        _mockLikeRepository.Verify(x => x.DeleteElement(It.IsAny<UserLikePostRelationDao>()), Times.Once);
    }

    [Test]
    public void DeleteLike_ShouldThrowLikeIudException_WhenDatabaseIudActionExceptionIsThrown()
    {
        var userId = Guid.NewGuid();
        var postId = Guid.NewGuid();
        _mockLikeRepository.Setup(x => x.DeleteElement(It.IsAny<UserLikePostRelationDao>()))
            .ThrowsAsync(new DatabaseIudActionException());

        Assert.ThrowsAsync<LikeIudException>(async () => await _likeService.DeleteLike(userId, postId));
    }

    [Test]
    public void DeleteLike_ShouldThrowLikeGeneralException_WhenGeneralDatabaseExceptionIsThrown()
    {
        var userId = Guid.NewGuid();
        var postId = Guid.NewGuid();
        _mockLikeRepository.Setup(x => x.DeleteElement(It.IsAny<UserLikePostRelationDao>()))
            .ThrowsAsync(new GeneralDatabaseException());

        Assert.ThrowsAsync<LikeGeneralException>(async () => await _likeService.DeleteLike(userId, postId));
    }

    [Test]
    public async Task GetLikesForPost_ShouldReturnUserIds_WhenLikesAreFound()
    {
        var postId = Guid.NewGuid();
        var userId = Guid.NewGuid();
        var likes = new List<UserLikePostRelationDao> { new(userId, postId) };
        _mockLikeRepository.Setup(x => x.GetLikesForPost(It.IsAny<Guid>(), It.IsAny<Guid>())).ReturnsAsync(likes);

        var result = await _likeService.GetLikesForPost(postId);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Count, Is.EqualTo(1));
        Assert.That(result[0], Is.EqualTo(userId));
    }

    [Test]
    public void GetLikesForPost_ShouldThrowLikeNotFoundException_WhenDatabaseMissingItemExceptionIsThrown()
    {
        var postId = Guid.NewGuid();
        _mockLikeRepository.Setup(x => x.GetLikesForPost(It.IsAny<Guid>(), It.IsAny<Guid>()))
            .ThrowsAsync(new DatabaseMissingItemException());

        Assert.ThrowsAsync<LikeNotFoundException>(async () => await _likeService.GetLikesForPost(postId));
    }

    [Test]
    public void GetLikesForPost_ShouldThrowLikeGeneralException_WhenGeneralDatabaseExceptionIsThrown()
    {
        var postId = Guid.NewGuid();
        _mockLikeRepository.Setup(x => x.GetLikesForPost(It.IsAny<Guid>(), It.IsAny<Guid>()))
            .ThrowsAsync(new GeneralDatabaseException());

        Assert.ThrowsAsync<LikeGeneralException>(async () => await _likeService.GetLikesForPost(postId));
    }
}
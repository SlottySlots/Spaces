using System.Linq.Expressions;
using Moq;
using SlottyMedia.Backend.Exceptions.Services.PostExceptions;
using SlottyMedia.Backend.Exceptions.Services.UserExceptions;
using SlottyMedia.Backend.Services;
using SlottyMedia.Database;
using SlottyMedia.Database.Daos;
using SlottyMedia.Database.Exceptions;
using Supabase.Postgrest;

namespace SlottyMedia.Tests.ServiceTests;

/// <summary>
///     Unit tests for the LikeService class.
/// </summary>
[TestFixture]
public class LikeServiceTests
{
    /// <summary>
    ///     Sets up the test environment before each test.
    /// </summary>
    [SetUp]
    public void Setup()
    {
        // Initialize the mock database actions
        _mockDatabaseActions = new Mock<IDatabaseActions>();
        // Initialize the LikeService with the mock database actions
        _likeService = new LikeService(_mockDatabaseActions.Object);
    }

    /// <summary>
    ///     Cleans up the test environment after each test.
    /// </summary>
    [TearDown]
    public void TearDown()
    {
        // Reset the mock database actions after each test
        _mockDatabaseActions.Reset();
    }

    private Mock<IDatabaseActions> _mockDatabaseActions;
    private LikeService _likeService;

    /// <summary>
    ///     Tests that InsertLike returns true when the like is inserted successfully.
    /// </summary>
    [Test]
    public async Task InsertLike_ShouldReturnTrue_WhenLikeIsInsertedSuccessfully()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var postId = Guid.NewGuid();
        // Setup the mock to return a new UserLikePostRelationDao when Insert is called
        _mockDatabaseActions.Setup(x => x.Insert(It.IsAny<UserLikePostRelationDao>()))
            .ReturnsAsync(new UserLikePostRelationDao(userId, postId));

        // Act
        var result = await _likeService.InsertLike(userId, postId);

        // Assert
        Assert.That(result, Is.True);
        // Verify that Insert was called once
        _mockDatabaseActions.Verify(x => x.Insert(It.IsAny<UserLikePostRelationDao>()), Times.Once);
    }

    /// <summary>
    ///     Tests that InsertLike throws LikeIudException when a DatabaseIudActionException is thrown.
    /// </summary>
    [Test]
    public void InsertLike_ShouldThrowLikeIudException_WhenDatabaseIudActionExceptionIsThrown()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var postId = Guid.NewGuid();
        // Setup the mock to throw DatabaseIudActionException when Insert is called
        _mockDatabaseActions.Setup(x => x.Insert(It.IsAny<UserLikePostRelationDao>()))
            .ThrowsAsync(new DatabaseIudActionException());

        // Act & Assert
        Assert.That(async () => await _likeService.InsertLike(userId, postId), Throws.TypeOf<LikeIudException>());
    }

    /// <summary>
    ///     Tests that InsertLike throws LikeGeneralException when a GeneralDatabaseException is thrown.
    /// </summary>
    [Test]
    public void InsertLike_ShouldThrowLikeGeneralException_WhenGeneralDatabaseExceptionIsThrown()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var postId = Guid.NewGuid();
        // Setup the mock to throw GeneralDatabaseException when Insert is called
        _mockDatabaseActions.Setup(x => x.Insert(It.IsAny<UserLikePostRelationDao>()))
            .ThrowsAsync(new GeneralDatabaseException());

        // Act & Assert
        Assert.That(async () => await _likeService.InsertLike(userId, postId), Throws.TypeOf<LikeGeneralException>());
    }

    /// <summary>
    ///     Tests that DeleteLike returns true when the like is deleted successfully.
    /// </summary>
    [Test]
    public async Task DeleteLike_ShouldReturnTrue_WhenLikeIsDeletedSuccessfully()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var postId = Guid.NewGuid();
        // Setup the mock to return true when Delete is called
        _mockDatabaseActions.Setup(x => x.Delete(It.IsAny<UserLikePostRelationDao>())).ReturnsAsync(true);

        // Act
        var result = await _likeService.DeleteLike(userId, postId);

        // Assert
        Assert.That(result, Is.True);
        // Verify that Delete was called once
        _mockDatabaseActions.Verify(x => x.Delete(It.IsAny<UserLikePostRelationDao>()), Times.Once);
    }

    /// <summary>
    ///     Tests that DeleteLike throws LikeIudException when a DatabaseIudActionException is thrown.
    /// </summary>
    [Test]
    public void DeleteLike_ShouldThrowLikeIudException_WhenDatabaseIudActionExceptionIsThrown()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var postId = Guid.NewGuid();
        // Setup the mock to throw DatabaseIudActionException when Delete is called
        _mockDatabaseActions.Setup(x => x.Delete(It.IsAny<UserLikePostRelationDao>()))
            .ThrowsAsync(new DatabaseIudActionException());

        // Act & Assert
        Assert.That(async () => await _likeService.DeleteLike(userId, postId), Throws.TypeOf<LikeIudException>());
    }

    /// <summary>
    ///     Tests that DeleteLike throws LikeGeneralException when a GeneralDatabaseException is thrown.
    /// </summary>
    [Test]
    public void DeleteLike_ShouldThrowLikeGeneralException_WhenGeneralDatabaseExceptionIsThrown()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var postId = Guid.NewGuid();
        // Setup the mock to throw GeneralDatabaseException when Delete is called
        _mockDatabaseActions.Setup(x => x.Delete(It.IsAny<UserLikePostRelationDao>()))
            .ThrowsAsync(new GeneralDatabaseException());

        // Act & Assert
        Assert.That(async () => await _likeService.DeleteLike(userId, postId), Throws.TypeOf<LikeGeneralException>());
    }

    /// <summary>
    ///     Tests that GetLikesForPost returns a list of user IDs when likes are found.
    /// </summary>
    [Test]
    public async Task GetLikesForPost_ShouldReturnUserIds_WhenLikesAreFound()
    {
        // Arrange
        var postId = Guid.NewGuid();
        var userId = Guid.NewGuid();
        var likes = new List<UserLikePostRelationDao> { new(userId, postId) };
        // Setup the mock to return a list of UserLikePostRelationDao when GetEntitiesWithSelectorById is called
        _mockDatabaseActions.Setup(x => x.GetEntitiesWithSelectorById(
            It.IsAny<Expression<Func<UserLikePostRelationDao, object[]>>>(),
            It.IsAny<List<(string, Constants.Operator, string)>>(),
            It.IsAny<int>(),
            It.IsAny<int>(),
            It.IsAny<(string, Constants.Ordering, Constants.NullPosition)[]>())).ReturnsAsync(likes);

        // Act
        var result = await _likeService.GetLikesForPost(postId);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Count, Is.EqualTo(1));
        Assert.That(result[0], Is.EqualTo(userId));
    }

    /// <summary>
    ///     Tests that GetLikesForPost throws LikeNotFoundException when a DatabaseMissingItemException is thrown.
    /// </summary>
    [Test]
    public void GetLikesForPost_ShouldThrowLikeNotFoundException_WhenDatabaseMissingItemExceptionIsThrown()
    {
        // Arrange
        var postId = Guid.NewGuid();
        // Setup the mock to throw DatabaseMissingItemException when GetEntitiesWithSelectorById is called
        _mockDatabaseActions.Setup(x => x.GetEntitiesWithSelectorById(
                It.IsAny<Expression<Func<UserLikePostRelationDao, object[]>>>(),
                It.IsAny<List<(string, Constants.Operator, string)>>(),
                It.IsAny<int>(),
                It.IsAny<int>(),
                It.IsAny<(string, Constants.Ordering, Constants.NullPosition)[]>()))
            .ThrowsAsync(new DatabaseMissingItemException());

        // Act & Assert
        Assert.That(async () => await _likeService.GetLikesForPost(postId), Throws.TypeOf<LikeNotFoundException>());
    }

    /// <summary>
    ///     Tests that GetLikesForPost throws LikeGeneralException when a GeneralDatabaseException is thrown.
    /// </summary>
    [Test]
    public void GetLikesForPost_ShouldThrowLikeGeneralException_WhenGeneralDatabaseExceptionIsThrown()
    {
        // Arrange
        var postId = Guid.NewGuid();
        // Setup the mock to throw GeneralDatabaseException when GetEntitiesWithSelectorById is called
        _mockDatabaseActions.Setup(x => x.GetEntitiesWithSelectorById(
                It.IsAny<Expression<Func<UserLikePostRelationDao, object[]>>>(),
                It.IsAny<List<(string, Constants.Operator, string)>>(),
                It.IsAny<int>(),
                It.IsAny<int>(),
                It.IsAny<(string, Constants.Ordering, Constants.NullPosition)[]>()))
            .ThrowsAsync(new GeneralDatabaseException());

        // Act & Assert
        Assert.That(async () => await _likeService.GetLikesForPost(postId), Throws.TypeOf<LikeGeneralException>());
    }
}
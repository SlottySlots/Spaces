using Moq;
using SlottyMedia.Backend.Dtos;
using SlottyMedia.Backend.Exceptions.Services.PostExceptions;
using SlottyMedia.Backend.Services;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Database;
using SlottyMedia.Database.Daos;
using SlottyMedia.Database.Exceptions;

namespace SlottyMedia.Tests.ServiceTests;

/// <summary>
/// Tests for the ForumService class.
/// </summary>
[TestFixture]
public class ForumServiceTests
{
    /// <summary>
    ///     Setup method to initialize mocks and the service before each test.
    /// </summary>
    [SetUp]
    public void Setup()
    {
        _mockDatabaseActions = new Mock<IDatabaseActions>();
        _forumService = new ForumService(_mockDatabaseActions.Object);
    }

    /// <summary>
    ///     Teardown method to reset mocks after each test.
    /// </summary>
    [TearDown]
    public void TearDown()
    {
        _mockDatabaseActions.Reset();
    }

    private Mock<IDatabaseActions> _mockDatabaseActions;
    private IForumService _forumService;

    /// <summary>
    ///     Tests that InsertForum returns the inserted forum when the insert is successful.
    /// </summary>
    [Test]
    public async Task InsertForum_ShouldReturnInsertedForum_WhenInsertIsSuccessful()
    {
        // Arrange
        var forumDto = new ForumDto { ForumId = Guid.NewGuid(), Topic = "Test Topic" };
        var forumDao = forumDto.Mapper();

        // Setup the mock to return the forumDao when Insert is called
        _mockDatabaseActions.Setup(x => x.Insert(It.IsAny<ForumDao>())).ReturnsAsync(forumDao);

        // Act
        var result = await _forumService.InsertForum(forumDto);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.ForumId, Is.EqualTo(forumDto.ForumId));
        Assert.That(result.Topic, Is.EqualTo(forumDto.Topic));
        // Verify that all setups were called
        _mockDatabaseActions.VerifyAll();
    }

    /// <summary>
    ///     Tests that InsertForum throws ForumIudException when a DatabaseIudActionException is thrown.
    /// </summary>
    [Test]
    public void InsertForum_ShouldThrowForumIudException_WhenDatabaseIudActionExceptionIsThrown()
    {
        // Arrange
        var forumDto = new ForumDto { ForumId = Guid.NewGuid(), Topic = "Test Topic" };

        // Setup the mock to throw DatabaseIudActionException when Insert is called
        _mockDatabaseActions.Setup(x => x.Insert(It.IsAny<ForumDao>())).ThrowsAsync(new DatabaseIudActionException());

        // Act & Assert
        Assert.ThrowsAsync<ForumIudException>(async () => await _forumService.InsertForum(forumDto));
    }

    /// <summary>
    ///     Tests that InsertForum throws ForumGeneralException when a GeneralDatabaseException is thrown.
    /// </summary>
    [Test]
    public void InsertForum_ShouldThrowForumGeneralException_WhenGeneralDatabaseExceptionIsThrown()
    {
        // Arrange
        var forumDto = new ForumDto { ForumId = Guid.NewGuid(), Topic = "Test Topic" };

        // Setup the mock to throw GeneralDatabaseException when Insert is called
        _mockDatabaseActions.Setup(x => x.Insert(It.IsAny<ForumDao>())).ThrowsAsync(new GeneralDatabaseException());

        // Act & Assert
        Assert.ThrowsAsync<ForumGeneralException>(async () => await _forumService.InsertForum(forumDto));
    }

    /// <summary>
    ///     Tests that DeleteForum completes successfully when the delete is successful.
    /// </summary>
    [Test]
    public async Task DeleteForum_ShouldCompleteSuccessfully_WhenDeleteIsSuccessful()
    {
        // Arrange
        var forumDto = new ForumDto { ForumId = Guid.NewGuid(), Topic = "Test Topic" };

        // Setup the mock to return true when Delete is called
        _mockDatabaseActions.Setup(x => x.Delete(It.IsAny<ForumDao>())).ReturnsAsync(true);

        // Act & Assert
        Assert.DoesNotThrowAsync(async () => await _forumService.DeleteForum(forumDto));
        // Verify that all setups were called
        _mockDatabaseActions.VerifyAll();
    }

    /// <summary>
    ///     Tests that DeleteForum throws ForumIudException when a DatabaseIudActionException is thrown.
    /// </summary>
    [Test]
    public void DeleteForum_ShouldThrowForumIudException_WhenDatabaseIudActionExceptionIsThrown()
    {
        // Arrange
        var forumDto = new ForumDto { ForumId = Guid.NewGuid(), Topic = "Test Topic" };

        // Setup the mock to throw DatabaseIudActionException when Delete is called
        _mockDatabaseActions.Setup(x => x.Delete(It.IsAny<ForumDao>())).ThrowsAsync(new DatabaseIudActionException());

        // Act & Assert
        Assert.ThrowsAsync<ForumIudException>(async () => await _forumService.DeleteForum(forumDto));
    }

    /// <summary>
    ///     Tests that DeleteForum throws ForumGeneralException when a GeneralDatabaseException is thrown.
    /// </summary>
    [Test]
    public void DeleteForum_ShouldThrowForumGeneralException_WhenGeneralDatabaseExceptionIsThrown()
    {
        // Arrange
        var forumDto = new ForumDto { ForumId = Guid.NewGuid(), Topic = "Test Topic" };

        // Setup the mock to throw GeneralDatabaseException when Delete is called
        _mockDatabaseActions.Setup(x => x.Delete(It.IsAny<ForumDao>())).ThrowsAsync(new GeneralDatabaseException());

        // Act & Assert
        Assert.ThrowsAsync<ForumGeneralException>(async () => await _forumService.DeleteForum(forumDto));
    }
}
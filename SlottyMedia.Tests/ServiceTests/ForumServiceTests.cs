using Moq;
using SlottyMedia.Backend.Dtos;
using SlottyMedia.Backend.Exceptions.Services.ForumExceptions;
using SlottyMedia.Backend.Services;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Database.Daos;
using SlottyMedia.Database.Exceptions;
using SlottyMedia.Database.Repository.ForumRepo;

namespace SlottyMedia.Tests.ServiceTests;

/// <summary>
///     Unit tests for the ForumService class.
/// </summary>
[TestFixture]
public class ForumServiceTests
{
    private Mock<IForumRepository> _mockForumRepository;
    private Mock<ITopForumRepository> _mockTopForumRepository;
    private Mock<ISearchService> _mockSearchService;
    private ForumService _forumService;

    /// <summary>
    ///     Sets up the test environment before each test.
    /// </summary>
    [SetUp]
    public void Setup()
    {
        _mockForumRepository = new Mock<IForumRepository>();
        _mockTopForumRepository = new Mock<ITopForumRepository>();
        _mockSearchService = new Mock<ISearchService>();
        _forumService = new ForumService(_mockForumRepository.Object, _mockTopForumRepository.Object,
            _mockSearchService.Object);
    }

    /// <summary>
    ///     Cleans up the test environment after each test.
    /// </summary>
    [TearDown]
    public void TearDown()
    {
        _mockForumRepository.Reset();
        _mockTopForumRepository.Reset();
        _mockSearchService.Reset();
    }

    /// <summary>
    ///     Tests that a forum is inserted when the forum is valid.
    /// </summary>
    [Test]
    public async Task InsertForum_ShouldInsertForum_WhenForumIsValid()
    {
        var creatorUserId = Guid.NewGuid();
        var forumTopic = "Test Forum";
        var forumDao = new ForumDao { ForumId = Guid.NewGuid(), ForumTopic = forumTopic };

        _mockForumRepository.Setup(x => x.AddElement(It.IsAny<ForumDao>())).ReturnsAsync(forumDao);

        await _forumService.InsertForum(creatorUserId, forumTopic);

        _mockForumRepository.Verify(x => x.AddElement(It.IsAny<ForumDao>()), Times.Once);
    }

    /// <summary>
    ///     Tests that a ForumIudException is thrown when a DatabaseIudActionException is thrown.
    /// </summary>
    [Test]
    public void InsertForum_ShouldThrowForumIudException_WhenDatabaseIudActionExceptionIsThrown()
    {
        var creatorUserId = Guid.NewGuid();
        var forumTopic = "Test Forum";

        _mockForumRepository.Setup(x => x.AddElement(It.IsAny<ForumDao>()))
            .ThrowsAsync(new DatabaseIudActionException());

        Assert.ThrowsAsync<ForumIudException>(async () => await _forumService.InsertForum(creatorUserId, forumTopic));
    }

    /// <summary>
    ///     Tests that a ForumGeneralException is thrown when a GeneralDatabaseException is thrown.
    /// </summary>
    [Test]
    public void InsertForum_ShouldThrowForumGeneralException_WhenGeneralDatabaseExceptionIsThrown()
    {
        var creatorUserId = Guid.NewGuid();
        var forumTopic = "Test Forum";

        _mockForumRepository.Setup(x => x.AddElement(It.IsAny<ForumDao>())).ThrowsAsync(new GeneralDatabaseException());

        Assert.ThrowsAsync<ForumGeneralException>(
            async () => await _forumService.InsertForum(creatorUserId, forumTopic));
    }

    /// <summary>
    ///     Tests that a forum is deleted when the forum is valid.
    /// </summary>
    [Test]
    public async Task DeleteForum_ShouldDeleteForum_WhenForumIsValid()
    {
        var forum = new ForumDto { ForumId = Guid.NewGuid(), Topic = "Test Forum", CreatedAt = DateTime.Now };

        _mockForumRepository.Setup(x => x.DeleteElement(It.IsAny<ForumDao>())).Returns(Task.CompletedTask);

        await _forumService.DeleteForum(forum);

        _mockForumRepository.Verify(x => x.DeleteElement(It.IsAny<ForumDao>()), Times.Once);
    }

    /// <summary>
    ///     Tests that a ForumIudException is thrown when a DatabaseIudActionException is thrown.
    /// </summary>
    [Test]
    public void DeleteForum_ShouldThrowForumIudException_WhenDatabaseIudActionExceptionIsThrown()
    {
        var forum = new ForumDto { ForumId = Guid.NewGuid(), Topic = "Test Forum", CreatedAt = DateTime.Now };

        _mockForumRepository.Setup(x => x.DeleteElement(It.IsAny<ForumDao>()))
            .ThrowsAsync(new DatabaseIudActionException());

        Assert.ThrowsAsync<ForumIudException>(async () => await _forumService.DeleteForum(forum));
    }

    /// <summary>
    ///     Tests that a ForumGeneralException is thrown when a GeneralDatabaseException is thrown.
    /// </summary>
    [Test]
    public void DeleteForum_ShouldThrowForumGeneralException_WhenGeneralDatabaseExceptionIsThrown()
    {
        var forum = new ForumDto { ForumId = Guid.NewGuid(), Topic = "Test Forum" };

        _mockForumRepository.Setup(x => x.DeleteElement(It.IsAny<ForumDao>()))
            .ThrowsAsync(new GeneralDatabaseException());

        Assert.ThrowsAsync<ForumGeneralException>(async () => await _forumService.DeleteForum(forum));
    }

    /// <summary>
    ///     Tests that a forum is returned when the forum exists.
    /// </summary>
    [Test]
    public async Task GetForumByName_ShouldReturnForum_WhenForumExists()
    {
        var forumName = "Test Forum";
        var forumDao = new ForumDao { ForumId = Guid.NewGuid(), ForumTopic = forumName };

        _mockForumRepository.Setup(x => x.GetElementById(forumName)).ReturnsAsync(forumDao);

        var result = await _forumService.GetForumByName(forumName);

        Assert.That(forumName, Is.EqualTo(result.Topic));
    }

    /// <summary>
    ///     Tests that a ForumNotFoundException is thrown when a DatabaseMissingItemException is thrown.
    /// </summary>
    [Test]
    public void GetForumByName_ShouldThrowForumGeneralException_WhenDatabaseMissingItemExceptionIsThrown()
    {
        var forumName = "Test Forum";

        _mockForumRepository.Setup(x => x.GetElementById(forumName)).ThrowsAsync(new DatabaseMissingItemException());

        Assert.ThrowsAsync<ForumNotFoundException>(async () => await _forumService.GetForumByName(forumName));
    }

    /// <summary>
    ///     Tests that forums are returned when forums exist.
    /// </summary>
    [Test]
    public async Task GetForumsByNameContaining_ShouldReturnForums_WhenForumsExist()
    {
        var forumName = "Test";
        var forumDaos = new List<ForumDao>
        {
            new() { ForumId = Guid.NewGuid(), ForumTopic = "Test Forum 1" },
            new() { ForumId = Guid.NewGuid(), ForumTopic = "Test Forum 2" }
        };
        var forumDtos = forumDaos.Select(f => new ForumDto().Mapper(f)).ToList();

        _mockSearchService.Setup(x => x.SearchByTopic(forumName, 1, 10))
            .ReturnsAsync(new SearchDto { Forums = forumDtos });

        var result = await _forumService.GetForumsByNameContaining(forumName, 1);

        Assert.That(result.Count, Is.EqualTo(2));
    }

    /// <summary>
    ///     Tests that a ForumNotFoundException is thrown when a DatabaseMissingItemException is thrown.
    /// </summary>
    [Test]
    public void GetForumsByNameContaining_ShouldThrowForumGeneralException_WhenDatabaseMissingItemExceptionIsThrown()
    {
        var forumName = "Test";

        _mockSearchService.Setup(x => x.SearchByTopic(forumName, 1, 10))
            .ThrowsAsync(new DatabaseMissingItemException());

        Assert.ThrowsAsync<ForumNotFoundException>(async () =>
            await _forumService.GetForumsByNameContaining(forumName, 1));
    }

    /// <summary>
    ///     Tests that all forums are returned when forums exist.
    /// </summary>
    [Test]
    public async Task GetForums_ShouldReturnAllForums_WhenForumsExist()
    {
        var forumDaos = new List<ForumDao>
        {
            new() { ForumId = Guid.NewGuid(), ForumTopic = "Test Forum 1" },
            new() { ForumId = Guid.NewGuid(), ForumTopic = "Test Forum 2" }
        };

        _mockForumRepository.Setup(x => x.GetAllElements()).ReturnsAsync(forumDaos);

        var result = await _forumService.GetForums();

        Assert.That(result.Count, Is.EqualTo(2));
    }

    /// <summary>
    ///     Tests that a ForumNotFoundException is thrown when a DatabaseMissingItemException is thrown.
    /// </summary>
    [Test]
    public void GetForums_ShouldThrowForumGeneralException_WhenDatabaseMissingItemExceptionIsThrown()
    {
        _mockForumRepository.Setup(x => x.GetAllElements()).ThrowsAsync(new DatabaseMissingItemException());

        Assert.ThrowsAsync<ForumNotFoundException>(async () => await _forumService.GetForums());
    }

    /// <summary>
    ///     Tests that recent forums are returned when forums exist.
    /// </summary>
    [Test]
    public async Task DetermineRecentSpaces_ShouldReturnRecentForums_WhenForumsExist()
    {
        var forumDaos = new List<TopForumDao>
        {
            new() { ForumId = Guid.NewGuid(), ForumTopic = "Recent Forum 1" },
            new() { ForumId = Guid.NewGuid(), ForumTopic = "Recent Forum 2" }
        };

        _mockTopForumRepository.Setup(x => x.DetermineRecentSpaces()).ReturnsAsync(forumDaos);

        var result = await _forumService.DetermineRecentSpaces();

        Assert.That(result.Count(), Is.EqualTo(2));
    }

    /// <summary>
    ///     Tests that a ForumNotFoundException is thrown when a DatabaseMissingItemException is thrown.
    /// </summary>
    [Test]
    public void DetermineRecentSpaces_ShouldThrowForumGeneralException_WhenDatabaseMissingItemExceptionIsThrown()
    {
        _mockTopForumRepository.Setup(x => x.DetermineRecentSpaces()).ThrowsAsync(new DatabaseMissingItemException());

        Assert.ThrowsAsync<ForumNotFoundException>(async () => await _forumService.DetermineRecentSpaces());
    }

    /// <summary>
    ///     Tests that top forums are returned when forums exist.
    /// </summary>
    [Test]
    public async Task GetTopForums_ShouldReturnTopForums_WhenForumsExist()
    {
        var forumDaos = new List<TopForumDao>
        {
            new() { ForumId = Guid.NewGuid(), ForumTopic = "Top Forum 1" },
            new() { ForumId = Guid.NewGuid(), ForumTopic = "Top Forum 2" }
        };

        _mockTopForumRepository.Setup(x => x.GetTopForums()).ReturnsAsync(forumDaos);

        var result = await _forumService.GetTopForums();

        Assert.That(result.Count(), Is.EqualTo(2));
    }

    /// <summary>
    ///     Tests that a ForumNotFoundException is thrown when a DatabaseMissingItemException is thrown.
    /// </summary>
    [Test]
    public void GetTopForums_ShouldThrowForumGeneralException_WhenDatabaseMissingItemExceptionIsThrown()
    {
        _mockTopForumRepository.Setup(x => x.GetTopForums()).ThrowsAsync(new DatabaseMissingItemException());

        Assert.ThrowsAsync<ForumNotFoundException>(async () => await _forumService.GetTopForums());
    }

    /// <summary>
    ///     Tests that a ForumGeneralException is thrown when a general exception is thrown during forum insertion.
    /// </summary>
    [Test]
    public void InsertForum_ShouldThrowForumGeneralException_WhenGeneralExceptionIsThrown()
    {
        var creatorUserId = Guid.NewGuid();
        var forumTopic = "Test Forum";

        _mockForumRepository.Setup(x => x.AddElement(It.IsAny<ForumDao>())).ThrowsAsync(new Exception());

        Assert.ThrowsAsync<ForumGeneralException>(async () => await _forumService.InsertForum(creatorUserId, forumTopic));
    }

    /// <summary>
    ///     Tests that a ForumGeneralException is thrown when a general exception is thrown during forum deletion.
    /// </summary>
    [Test]
    public void DeleteForum_ShouldThrowForumGeneralException_WhenGeneralExceptionIsThrown()
    {
        var forum = new ForumDto { ForumId = Guid.NewGuid(), Topic = "Test Forum" };

        _mockForumRepository.Setup(x => x.DeleteElement(It.IsAny<ForumDao>())).ThrowsAsync(new Exception());

        Assert.ThrowsAsync<ForumGeneralException>(async () => await _forumService.DeleteForum(forum));
    }

    /// <summary>
    ///     Tests that a ForumGeneralException is thrown when a general exception is thrown during forum retrieval by name.
    /// </summary>
    [Test]
    public void GetForumByName_ShouldThrowForumGeneralException_WhenGeneralExceptionIsThrown()
    {
        var forumName = "Test Forum";

        _mockForumRepository.Setup(x => x.GetElementById(forumName)).ThrowsAsync(new Exception());

        Assert.ThrowsAsync<ForumGeneralException>(async () => await _forumService.GetForumByName(forumName));
    }

    /// <summary>
    ///     Tests that a ForumGeneralException is thrown when a general exception is thrown during forum search by name.
    /// </summary>
    [Test]
    public void GetForumsByNameContaining_ShouldThrowForumGeneralException_WhenGeneralExceptionIsThrown()
    {
        var forumName = "Test";

        _mockSearchService.Setup(x => x.SearchByTopic(forumName, 1, 10)).ThrowsAsync(new Exception());

        Assert.ThrowsAsync<ForumGeneralException>(async () => await _forumService.GetForumsByNameContaining(forumName, 1));
    }

    /// <summary>
    ///     Tests that a ForumGeneralException is thrown when a general exception is thrown during retrieval of all forums.
    /// </summary>
    [Test]
    public void GetForums_ShouldThrowForumGeneralException_WhenGeneralExceptionIsThrown()
    {
        _mockForumRepository.Setup(x => x.GetAllElements()).ThrowsAsync(new Exception());

        Assert.ThrowsAsync<ForumGeneralException>(async () => await _forumService.GetForums());
    }

    /// <summary>
    ///     Tests that a ForumGeneralException is thrown when a general exception is thrown during retrieval of recent forums.
    /// </summary>
    [Test]
    public void DetermineRecentSpaces_ShouldThrowForumGeneralException_WhenGeneralExceptionIsThrown()
    {
        _mockTopForumRepository.Setup(x => x.DetermineRecentSpaces()).ThrowsAsync(new Exception());

        Assert.ThrowsAsync<ForumGeneralException>(async () => await _forumService.DetermineRecentSpaces());
    }

    /// <summary>
    ///     Tests that a ForumGeneralException is thrown when a general exception is thrown during retrieval of top forums.
    /// </summary>
    [Test]
    public void GetTopForums_ShouldThrowForumGeneralException_WhenGeneralExceptionIsThrown()
    {
        _mockTopForumRepository.Setup(x => x.GetTopForums()).ThrowsAsync(new Exception());

        Assert.ThrowsAsync<ForumGeneralException>(async () => await _forumService.GetTopForums());
    }
}
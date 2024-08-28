using System.Linq.Expressions;
using Moq;
using SlottyMedia.Backend.Exceptions.Services.SearchExceptions;
using SlottyMedia.Backend.Services;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Database;
using SlottyMedia.Database.Daos;
using SlottyMedia.Database.Exceptions;
using SlottyMedia.Database.Repository.SearchRepo;
using Supabase.Postgrest;

namespace SlottyMedia.Tests.ServiceTests;

/// <summary>
///     Tests the SearchService used for searching for users and topics in the database.
/// </summary>
[TestFixture]
public class SearchServiceTests
{
    /// <summary>
    ///     The setup method that is called before each test.
    /// </summary>
    [SetUp]
    public void Setup()
    {
        _mockUserSearchRepository = new Mock<IUserSeachRepository>();
        _mockForumSearchRepository = new Mock<IForumSearchRepository>();
        _searchService = new SearchService(_mockUserSearchRepository.Object, _mockForumSearchRepository.Object);
    }

    /// <summary>
    ///     The teardown method that is called after each test.
    /// </summary>
    [TearDown]
    public void TearDown()
    {
        _mockUserSearchRepository.Reset();
        _mockForumSearchRepository.Reset();
    }

    private Mock<IUserSeachRepository> _mockUserSearchRepository;
    private Mock<IForumSearchRepository> _mockForumSearchRepository;
    private ISearchService _searchService;

    /// <summary>
    ///     Tests if SearchByUsername method returns user IDs when users are found.
    /// </summary>
    [Test]
    public async Task SearchByUsername_ShouldReturnUserIds_WhenUsersFound()
    {
        var searchTerm = "testUser";
        var userResults = new List<UserDao> { new() { UserId = Guid.NewGuid() } };

        _mockUserSearchRepository.Setup(x => x.GetUsersByUserName(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()))
            .ReturnsAsync(userResults);

        var result = await _searchService.SearchByUsername(searchTerm, 1, 10);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Users.Count, Is.EqualTo(1));
        Assert.That(result.Users[0].UserId, Is.EqualTo(userResults[0].UserId));
        _mockUserSearchRepository.VerifyAll();
    }

    /// <summary>
    ///     Tests if SearchByTopic method returns topic IDs when topics are found.
    /// </summary>
    [Test]
    public async Task SearchByTopic_ShouldReturnTopicIds_WhenTopicsFound()
    {
        var searchTerm = "testTopic";
        var topicResults = new List<ForumDao> { new() { ForumId = Guid.NewGuid() } };

        _mockForumSearchRepository.Setup(x => x.GetForumsByTopic(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()))
            .ReturnsAsync(topicResults);

        var result = await _searchService.SearchByTopic(searchTerm, 1, 10);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Forums.Count, Is.EqualTo(1));
        Assert.That(result.Forums[0].ForumId, Is.EqualTo(topicResults[0].ForumId));
        _mockForumSearchRepository.VerifyAll();
    }

    /// <summary>
    ///     Tests if SearchByUsername and SearchByTopic methods return an empty list when no results are found.
    /// </summary>
    [Test]
    public async Task SearchByUsernameOrTopic_ShouldReturnEmptyList_WhenNoResultsFound()
    {
        var searchTerm = "nonExistent";
        var emptyUserResults = new List<UserDao>();
        var emptyForumResults = new List<ForumDao>();

        _mockUserSearchRepository.Setup(x => x.GetUsersByUserName(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()))
            .ReturnsAsync(emptyUserResults);

        _mockForumSearchRepository.Setup(x => x.GetForumsByTopic(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()))
            .ReturnsAsync(emptyForumResults);

        var userResult = await _searchService.SearchByUsername(searchTerm, 1, 10);
        var topicResult = await _searchService.SearchByTopic(searchTerm, 1, 10);

        Assert.That(userResult, Is.Not.Null);
        Assert.That(userResult.Users, Is.Empty);
        Assert.That(topicResult, Is.Not.Null);
        Assert.That(topicResult.Forums, Is.Empty);
        _mockUserSearchRepository.VerifyAll();
        _mockForumSearchRepository.VerifyAll();
    }

    /// <summary>
    ///     Tests if SearchByUsername and SearchByTopic methods throw SearchGeneralExceptions when a general database exception is thrown.
    /// </summary>
    [Test]
    public void SearchByUsernameOrTopic_ShouldThrowException_WhenDatabaseThrowsException()
    {
        var searchTerm = "testUser";

        _mockUserSearchRepository.Setup(x => x.GetUsersByUserName(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()))
            .ThrowsAsync(new Exception("Database error"));

        _mockForumSearchRepository.Setup(x => x.GetForumsByTopic(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()))
            .ThrowsAsync(new Exception("Database error"));

        Assert.ThrowsAsync<SearchGeneralExceptions>(
            async () => await _searchService.SearchByUsername(searchTerm, 1, 10));
        Assert.ThrowsAsync<SearchGeneralExceptions>(
            async () => await _searchService.SearchByTopic(searchTerm, 1, 10));
    }

    /// <summary>
    ///     Tests if SearchByUsername and SearchByTopic methods throw SearchGeneralExceptions when DatabaseMissingItemException is thrown.
    /// </summary>
    [Test]
    public void SearchByUsernameOrTopic_ShouldThrowSearchGeneralExceptions_WhenDatabaseMissingItemExceptionIsThrown()
    {
        var searchTerm = "testUser";

        _mockUserSearchRepository.Setup(x => x.GetUsersByUserName(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()))
            .ThrowsAsync(new DatabaseMissingItemException());

        _mockForumSearchRepository.Setup(x => x.GetForumsByTopic(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()))
            .ThrowsAsync(new DatabaseMissingItemException());

        Assert.ThrowsAsync<SearchGeneralExceptions>(
            async () => await _searchService.SearchByUsername(searchTerm, 1, 10));
        Assert.ThrowsAsync<SearchGeneralExceptions>(
            async () => await _searchService.SearchByTopic(searchTerm, 1, 10));
    }

    /// <summary>
    ///     Tests if SearchByUsername and SearchByTopic methods throw SearchGeneralExceptions when GeneralDatabaseException is thrown.
    /// </summary>
    [Test]
    public void SearchByUsernameOrTopic_ShouldThrowSearchGeneralExceptions_WhenDatabaseExceptionIsThrown()
    {
        var searchTerm = "testUser";

        _mockUserSearchRepository.Setup(x => x.GetUsersByUserName(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()))
            .ThrowsAsync(new GeneralDatabaseException());

        _mockForumSearchRepository.Setup(x => x.GetForumsByTopic(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()))
            .ThrowsAsync(new GeneralDatabaseException());

        Assert.ThrowsAsync<SearchGeneralExceptions>(
            async () => await _searchService.SearchByUsername(searchTerm, 1, 10));
        Assert.ThrowsAsync<SearchGeneralExceptions>(
            async () => await _searchService.SearchByTopic(searchTerm, 1, 10));
    }
}
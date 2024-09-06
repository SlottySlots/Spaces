using Moq;
using SlottyMedia.Backend.Exceptions.Services.SearchExceptions;
using SlottyMedia.Backend.Services;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Database.Daos;
using SlottyMedia.Database.Exceptions;
using SlottyMedia.Database.Pagination;
using SlottyMedia.Database.Repository.SearchRepo;
using SlottyMedia.Tests.TestImpl;

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
    public async Task SearchByUsernameContaining_ShouldReturnUserIds_WhenUsersFound()
    {
        var searchTerm = "testUser";
        var userResults = new List<UserDao> { new() { UserId = Guid.NewGuid() } };

        _mockUserSearchRepository.Setup(x => x.GetUsersByUserName(It.IsAny<string>(), It.IsAny<PageRequest>()))
            .ReturnsAsync(new PageTestImpl<UserDao>(userResults, 0, 10, 1));

        var result = await _searchService.SearchByUsernameContaining(searchTerm, PageRequest.OfSize(10));

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Count, Is.EqualTo(1));
        Assert.That(result.Content[0].UserId, Is.EqualTo(userResults[0].UserId));
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

        _mockForumSearchRepository.Setup(x => x.GetForumsByTopic(It.IsAny<string>(), It.IsAny<PageRequest>()))
            .ReturnsAsync(new PageTestImpl<ForumDao>(topicResults, 0, 10, 1));

        var result = await _searchService.SearchByForumTopicContaining(searchTerm, PageRequest.OfSize(10));

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Count, Is.EqualTo(1));
        Assert.That(result.Content[0].ForumId, Is.EqualTo(topicResults[0].ForumId));
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

        _mockUserSearchRepository.Setup(x => x.GetUsersByUserName(It.IsAny<string>(), It.IsAny<PageRequest>()))
            .ReturnsAsync(new PageTestImpl<UserDao>(emptyUserResults, 0, 10, 1));

        _mockForumSearchRepository.Setup(x => x.GetForumsByTopic(It.IsAny<string>(), It.IsAny<PageRequest>()))
            .ReturnsAsync(new PageTestImpl<ForumDao>(emptyForumResults, 0, 10, 1));

        var userResult = await _searchService.SearchByUsernameContaining(searchTerm, PageRequest.OfSize(10));
        var topicResult = await _searchService.SearchByForumTopicContaining(searchTerm, PageRequest.OfSize(10));

        Assert.That(userResult, Is.Not.Null);
        Assert.That(userResult.Content, Is.Empty);
        Assert.That(topicResult, Is.Not.Null);
        Assert.That(topicResult.Content, Is.Empty);
        _mockUserSearchRepository.VerifyAll();
        _mockForumSearchRepository.VerifyAll();
    }

    /// <summary>
    ///     Tests if SearchByUsername and SearchByTopic methods throw SearchGeneralExceptions when a general database exception
    ///     is thrown.
    /// </summary>
    [Test]
    public void SearchByUsernameOrTopic_ShouldThrowException_WhenDatabaseThrowsException()
    {
        var searchTerm = "testUser";

        _mockUserSearchRepository.Setup(x => x.GetUsersByUserName(It.IsAny<string>(), It.IsAny<PageRequest>()))
            .ThrowsAsync(new Exception("Database error"));

        _mockForumSearchRepository.Setup(x => x.GetForumsByTopic(It.IsAny<string>(), It.IsAny<PageRequest>()))
            .ThrowsAsync(new Exception("Database error"));

        Assert.ThrowsAsync<SearchGeneralExceptions>(
            async () => await _searchService.SearchByUsernameContaining(searchTerm, PageRequest.OfSize(10)));
        Assert.ThrowsAsync<SearchGeneralExceptions>(
            async () => await _searchService.SearchByForumTopicContaining(searchTerm, PageRequest.OfSize(10)));
    }

    /// <summary>
    ///     Tests if SearchByUsername and SearchByTopic methods throw SearchGeneralExceptions when DatabaseMissingItemException
    ///     is thrown.
    /// </summary>
    [Test]
    public void SearchByUsernameOrTopic_ShouldThrowSearchGeneralExceptions_WhenDatabaseMissingItemExceptionIsThrown()
    {
        var searchTerm = "testUser";

        _mockUserSearchRepository.Setup(x => x.GetUsersByUserName(It.IsAny<string>(), It.IsAny<PageRequest>()))
            .ThrowsAsync(new DatabaseMissingItemException());

        _mockForumSearchRepository.Setup(x => x.GetForumsByTopic(It.IsAny<string>(), It.IsAny<PageRequest>()))
            .ThrowsAsync(new DatabaseMissingItemException());

        Assert.ThrowsAsync<SearchGeneralExceptions>(
            async () => await _searchService.SearchByUsernameContaining(searchTerm, PageRequest.OfSize(10)));
        Assert.ThrowsAsync<SearchGeneralExceptions>(
            async () => await _searchService.SearchByForumTopicContaining(searchTerm, PageRequest.OfSize(10)));
    }

    /// <summary>
    ///     Tests if SearchByUsername and SearchByTopic methods throw SearchGeneralExceptions when GeneralDatabaseException is
    ///     thrown.
    /// </summary>
    [Test]
    public void SearchByUsernameOrTopic_ShouldThrowSearchGeneralExceptions_WhenDatabaseExceptionIsThrown()
    {
        var searchTerm = "testUser";

        _mockUserSearchRepository.Setup(x => x.GetUsersByUserName(It.IsAny<string>(), It.IsAny<PageRequest>()))
            .ThrowsAsync(new GeneralDatabaseException());

        _mockForumSearchRepository.Setup(x => x.GetForumsByTopic(It.IsAny<string>(), It.IsAny<PageRequest>()))
            .ThrowsAsync(new GeneralDatabaseException());

        Assert.ThrowsAsync<SearchGeneralExceptions>(
            async () => await _searchService.SearchByUsernameContaining(searchTerm, PageRequest.OfSize(10)));
        Assert.ThrowsAsync<SearchGeneralExceptions>(
            async () => await _searchService.SearchByForumTopicContaining(searchTerm, PageRequest.OfSize(10)));
    }

    /// <summary>
    ///     Tests if SearchByUsername and SearchByTopic methods return an empty list when the search term is empty.
    /// </summary>
    [Test]
    public async Task SearchByUsernameContaining_ShouldReturnEmptyList_WhenSearchTermIsEmpty()
    {
        var searchTerm = string.Empty;

        _mockUserSearchRepository.Setup(x => x.GetUsersByUserName(It.IsAny<string>(), It.IsAny<PageRequest>()))
            .ReturnsAsync(new PageTestImpl<UserDao>([], 0, 10, 1));

        var result = await _searchService.SearchByUsernameContaining(searchTerm, PageRequest.OfSize(10));

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Content, Is.Empty);
        _mockUserSearchRepository.VerifyAll();
    }

    /// <summary>
    ///     Tests if SearchByUsername and SearchByTopic methods return an empty list when the search term is empty.
    /// </summary>
    [Test]
    public async Task SearchByTopicContaining_ShouldReturnEmptyList_WhenSearchTermIsEmpty()
    {
        var searchTerm = string.Empty;

        _mockForumSearchRepository.Setup(x => x.GetForumsByTopic(It.IsAny<string>(), It.IsAny<PageRequest>()))
            .ReturnsAsync(new PageTestImpl<ForumDao>([], 0, 10, 1));

        var result = await _searchService.SearchByForumTopicContaining(searchTerm, PageRequest.OfSize(10));

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Content, Is.Empty);
        _mockForumSearchRepository.VerifyAll();
    }


    /// <summary>
    ///     Tests if SearchByUsername and SearchByTopic methods return an empty list when the search term is null.
    /// </summary>
    [Test]
    public async Task SearchByUsername_ShouldHandleSpecialCharacters()
    {
        var searchTerm = "@testUser";
        var userResults = new List<UserDao> { new() { UserId = Guid.NewGuid() } };

        _mockUserSearchRepository.Setup(x => x.GetUsersByUserName(It.IsAny<string>(), It.IsAny<PageRequest>()))
            .ReturnsAsync(new PageTestImpl<UserDao>(userResults, 0, 10, 1));

        var result = await _searchService.SearchByUsernameContaining(searchTerm, PageRequest.OfSize(10));

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Count, Is.EqualTo(1));
        Assert.That(result.Content[0].UserId, Is.EqualTo(userResults[0].UserId));
        _mockUserSearchRepository.VerifyAll();
    }

    /// <summary>
    ///     Tests if SearchByUsername and SearchByTopic methods return an empty list when the search term is null.
    /// </summary>
    [Test]
    public async Task SearchByTopic_ShouldHandleSpecialCharacters()
    {
        var searchTerm = "#testTopic";
        var topicResults = new List<ForumDao> { new() { ForumId = Guid.NewGuid() } };

        _mockForumSearchRepository.Setup(x => x.GetForumsByTopic(It.IsAny<string>(), It.IsAny<PageRequest>()))
            .ReturnsAsync(new PageTestImpl<ForumDao>(topicResults, 0, 10, 1));

        var result = await _searchService.SearchByForumTopicContaining(searchTerm, PageRequest.OfSize(10));

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Count, Is.EqualTo(1));
        Assert.That(result.Content[0].ForumId, Is.EqualTo(topicResults[0].ForumId));
        _mockForumSearchRepository.VerifyAll();
    }
}
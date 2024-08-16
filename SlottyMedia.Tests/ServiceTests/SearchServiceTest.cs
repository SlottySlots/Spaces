using System.Linq.Expressions;
using Moq;
using SlottyMedia.Backend.Exceptions.Services.SearchExceptions;
using SlottyMedia.Backend.Services;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Database;
using SlottyMedia.Database.Daos;
using SlottyMedia.Database.Exceptions;
using Supabase.Postgrest;

namespace SlottyMedia.Tests.ServiceTests;

/// <summary>
/// Tests the SearchService used for searching for users and topics in the database.
/// </summary>
[TestFixture]
public class SearchServiceTests
{
    /// <summary>
    /// The setup method that is called before each test.
    /// </summary>
    [SetUp]
    public void Setup()
    {
        _mockDatabaseActions = new Mock<IDatabaseActions>();
        _searchService = new SearchService(_mockDatabaseActions.Object);
    }

    /// <summary>
    /// The teardown method that is called after each test.
    /// </summary>
    [TearDown]
    public void TearDown()
    {
        _mockDatabaseActions.Reset();
    }

    private Mock<IDatabaseActions> _mockDatabaseActions;
    private ISearchService _searchService;

    /// <summary>
    /// Tests if SearchByUsernameOrTopic method returns user IDs when users are found.
    /// </summary>
    [Test]
    public async Task SearchByUsernameOrTopic_ShouldReturnUserIds_WhenUsersFound()
    {
        var searchTerm = "testUser";
        var userResults = new List<UserDao> { new() { UserId = Guid.NewGuid() } };

        _mockDatabaseActions.Setup(x => x.GetEntitiesWithSelectorById(
                It.IsAny<Expression<Func<UserDao, object[]>>>(),
                It.IsAny<List<(string, Constants.Operator, string)>>(),
                It.IsAny<int>(),
                It.IsAny<int>(),
                It.IsAny<(string, Constants.Ordering, Constants.NullPosition)[]>()))!
            .ReturnsAsync(userResults);

        var result = await _searchService.SearchByUsernameOrTopic(searchTerm);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Users.Count, Is.EqualTo(1));
        Assert.That(result.Users[0].UserId, Is.EqualTo(userResults[0].UserId));
        _mockDatabaseActions.VerifyAll();
    }

    /// <summary>
    /// Tests if SearchByUsernameOrTopic method returns topic IDs when topics are found.
    /// </summary>
    [Test]
    public async Task SearchByUsernameOrTopic_ShouldReturnTopicIds_WhenTopicsFound()
    {
        var searchTerm = "testTopic";
        var topicResults = new List<ForumDao> { new() { ForumId = Guid.NewGuid() } };

        _mockDatabaseActions.Setup(x => x.GetEntitiesWithSelectorById(
                It.IsAny<Expression<Func<ForumDao, object[]>>>(),
                It.IsAny<List<(string, Constants.Operator, string)>>(),
                It.IsAny<int>(),
                It.IsAny<int>(),
                It.IsAny<(string, Constants.Ordering, Constants.NullPosition)[]>()))!
            .ReturnsAsync(topicResults);

        var result = await _searchService.SearchByUsernameOrTopic(searchTerm);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Forums.Count, Is.EqualTo(1));
        Assert.That(result.Forums[0].ForumId, Is.EqualTo(topicResults[0].ForumId));
        _mockDatabaseActions.VerifyAll();
    }

    /// <summary>
    /// Tests if SearchByUsernameOrTopic method returns an empty list when no results are found.
    /// </summary>
    [Test]
    public async Task SearchByUsernameOrTopic_ShouldReturnEmptyList_WhenNoResultsFound()
    {
        var searchTerm = "nonExistent";
        var emptyResults = new List<UserDao>();

        _mockDatabaseActions.Setup(x => x.GetEntitiesWithSelectorById(
                It.IsAny<Expression<Func<UserDao, object[]>>>(),
                It.IsAny<List<(string, Constants.Operator, string)>>(),
                It.IsAny<int>(),
                It.IsAny<int>(),
                It.IsAny<(string, Constants.Ordering, Constants.NullPosition)[]>()))!
            .ReturnsAsync(emptyResults);

        _mockDatabaseActions.Setup(x => x.GetEntitiesWithSelectorById(
                It.IsAny<Expression<Func<ForumDao, object[]>>>(),
                It.IsAny<List<(string, Constants.Operator, string)>>(),
                It.IsAny<int>(),
                It.IsAny<int>(),
                It.IsAny<(string, Constants.Ordering, Constants.NullPosition)[]>()))!
            .ReturnsAsync(new List<ForumDao>());

        var result = await _searchService.SearchByUsernameOrTopic(searchTerm);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Users, Is.Empty);
        Assert.That(result.Forums, Is.Empty);
        _mockDatabaseActions.VerifyAll();
    }

    /// <summary>
    /// Tests if SearchByUsernameOrTopic method throws SearchGeneralExceptions when a general database exception is thrown.
    /// </summary>
    [Test]
    public void SearchByUsernameOrTopic_ShouldThrowException_WhenDatabaseThrowsException()
    {
        var searchTerm = "testUser";

        _mockDatabaseActions.Setup(x => x.GetEntitiesWithSelectorById(
                It.IsAny<Expression<Func<UserDao, object[]>>>(),
                It.IsAny<List<(string, Constants.Operator, string)>>(),
                It.IsAny<int>(),
                It.IsAny<int>(),
                It.IsAny<(string, Constants.Ordering, Constants.NullPosition)[]>()))
            .ThrowsAsync(new Exception("Database error"));

        Assert.ThrowsAsync<SearchGeneralExceptions>(
            async () => await _searchService.SearchByUsernameOrTopic(searchTerm));
    }

    /// <summary>
    /// Tests if SearchByUsernameOrTopic method throws SearchGeneralExceptions when DatabaseMissingItemException is thrown.
    /// </summary>
    [Test]
    public void SearchByUsernameOrTopic_ShouldThrowSearchGeneralExceptions_WhenDatabaseMissingItemExceptionIsThrown()
    {
        var searchTerm = "testUser";

        _mockDatabaseActions.Setup(x => x.GetEntitiesWithSelectorById(
                It.IsAny<Expression<Func<UserDao, object[]>>>(),
                It.IsAny<List<(string, Constants.Operator, string)>>(),
                It.IsAny<int>(),
                It.IsAny<int>(),
                It.IsAny<(string, Constants.Ordering, Constants.NullPosition)[]>()))
            .ThrowsAsync(new DatabaseMissingItemException());

        Assert.ThrowsAsync<SearchGeneralExceptions>(
            async () => await _searchService.SearchByUsernameOrTopic(searchTerm));
    }

    /// <summary>
    /// Tests if SearchByUsernameOrTopic method throws SearchGeneralExceptions when GeneralDatabaseException is thrown.
    /// </summary>
    [Test]
    public void SearchByUsernameOrTopic_ShouldThrowSearchGeneralExceptions_WhenDatabaseExceptionIsThrown()
    {
        var searchTerm = "testUser";

        _mockDatabaseActions.Setup(x => x.GetEntitiesWithSelectorById(
                It.IsAny<Expression<Func<UserDao, object[]>>>(),
                It.IsAny<List<(string, Constants.Operator, string)>>(),
                It.IsAny<int>(),
                It.IsAny<int>(),
                It.IsAny<(string, Constants.Ordering, Constants.NullPosition)[]>()))
            .ThrowsAsync(new GeneralDatabaseException());

        Assert.ThrowsAsync<SearchGeneralExceptions>(
            async () => await _searchService.SearchByUsernameOrTopic(searchTerm));
    }
}
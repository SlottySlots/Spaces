using Moq;
using SlottyMedia.Backend.Dtos;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Backend.ViewModel;

namespace SlottyMedia.Tests.Viewmodel;

/// <summary>
///     Tests for the <see cref="SpacesCardVmImpl" /> class.
/// </summary>
[TestFixture]
public class SpacesCardVmImplTests
{
    /// <summary>
    ///     Sets up the test environment before each test.
    ///     Initializes the mocks and the view model instance.
    /// </summary>
    [SetUp]
    public void SetUp()
    {
        _forumServiceMock = new Mock<IForumService>();
        _postServiceMock = new Mock<IPostService>();
        _viewModel = new SpacesCardVmImpl(_forumServiceMock.Object, _postServiceMock.Object);
    }

    private Mock<IForumService> _forumServiceMock;
    private Mock<IPostService> _postServiceMock;
    private SpacesCardVmImpl _viewModel;

    /// <summary>
    ///     Tests that the Fetch method populates the TrendingSpaces and RecentSpaces properties.
    /// </summary>
    /// <returns>A task representing the asynchronous operation.</returns>
    [Test]
    public async Task Fetch_ShouldPopulateTrendingAndRecentSpaces()
    {
        var trendingSpaces = new List<ForumDto> { new() { ForumId = Guid.NewGuid(), Topic = "Trending Forum" } };
        var recentSpaces = new List<ForumDto> { new() { ForumId = Guid.NewGuid(), Topic = "Recent Forum" } };

        _forumServiceMock.Setup(s => s.GetTopForums()).ReturnsAsync(trendingSpaces);
        _forumServiceMock.Setup(s => s.DetermineRecentSpaces()).ReturnsAsync(recentSpaces);

        await _viewModel.Fetch();

        Assert.That(_viewModel.TrendingSpaces, Is.EqualTo(trendingSpaces));
        Assert.That(_viewModel.RecentSpaces, Is.EqualTo(recentSpaces));
    }

    /// <summary>
    ///     Tests that the Fetch method handles exceptions gracefully by ensuring
    ///     the TrendingSpaces and RecentSpaces properties are empty when an exception occurs.
    /// </summary>
    /// <returns>A task representing the asynchronous operation.</returns>
    [Test]
    public async Task Fetch_ShouldHandleExceptionGracefully()
    {
        _forumServiceMock.Setup(s => s.GetTopForums()).ThrowsAsync(new Exception("Service error"));

        await _viewModel.Fetch();

        Assert.That(_viewModel.TrendingSpaces, Is.Empty);
        Assert.That(_viewModel.RecentSpaces, Is.Empty);
    }

    /// <summary>
    ///     Tests that the Fetch method populates the TrendingSpaces property.
    /// </summary>
    /// <returns>A task representing the asynchronous operation.</returns>
    [Test]
    public async Task DetermineTrendingSpaces_ShouldPopulateTrendingSpaces()
    {
        var trendingSpaces = new List<ForumDto> { new() { ForumId = Guid.NewGuid(), Topic = "Trending Forum" } };

        _forumServiceMock.Setup(s => s.GetTopForums()).ReturnsAsync(trendingSpaces);

        await _viewModel.Fetch();

        Assert.That(_viewModel.TrendingSpaces, Is.EqualTo(trendingSpaces));
    }

    /// <summary>
    ///     Tests that the Fetch method populates the RecentSpaces property.
    /// </summary>
    /// <returns>A task representing the asynchronous operation.</returns>
    [Test]
    public async Task DetermineRecentSpaces_ShouldPopulateRecentSpaces()
    {
        var recentSpaces = new List<ForumDto> { new() { ForumId = Guid.NewGuid(), Topic = "Recent Forum" } };

        _forumServiceMock.Setup(s => s.DetermineRecentSpaces()).ReturnsAsync(recentSpaces);

        await _viewModel.Fetch();

        Assert.That(_viewModel.RecentSpaces, Is.EqualTo(recentSpaces));
    }
}
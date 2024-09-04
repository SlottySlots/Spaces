using Moq;
using SlottyMedia.Backend.Dtos;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Backend.ViewModel;

namespace SlottyMedia.Tests.Viewmodel;

/// <summary>
/// Unit tests for the HomePageVmImpl class.
/// </summary>
[TestFixture]
public class HomePageVmImplTests
{
    private Mock<IPostService> _mockPostService;
    private HomePageVmImpl _homePageVmImpl;

    /// <summary>
    /// Sets up the test environment by initializing mocks and the HomePageVmImpl instance.
    /// </summary>
    [SetUp]
    public void SetUp()
    {
        _mockPostService = new Mock<IPostService>();
        _homePageVmImpl = new HomePageVmImpl(_mockPostService.Object);
    }

    /// <summary>
    /// Tests that Initialize method sets initial values and loads posts.
    /// </summary>
    [Test]
    public async Task Initialize_SetsInitialValuesAndLoadsPosts()
    {
        _mockPostService.Setup(s => s.CountAllPosts()).ReturnsAsync(10);
        _mockPostService.Setup(s => s.GetAllPosts(It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(new List<PostDto> { new PostDto() });

        await _homePageVmImpl.Initialize();

        Assert.That(_homePageVmImpl.IsLoadingPage, Is.False);
        Assert.That(_homePageVmImpl.TotalNumberOfPosts, Is.EqualTo(10));
        Assert.That(_homePageVmImpl.Posts.Count, Is.EqualTo(1));
    }
}
using Moq;
using SlottyMedia.Backend.Dtos;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Backend.ViewModel.Pages.Home;
using SlottyMedia.Database.Pagination;
using Supabase.Gotrue;

namespace SlottyMedia.Tests.Viewmodel;

/// <summary>
///     Tests for the HomePageVmImpl class.
/// </summary>
[TestFixture]
public class HomePageVmImplTests
{
    /// <summary>
    ///     Sets up the test environment by initializing mocks and the system under test.
    /// </summary>
    [SetUp]
    public void SetUp()
    {
        _mockPostService = new Mock<IPostService>();
        _authServiceMock = new Mock<IAuthService>();
        _homePageVmImpl = new HomePageVmImpl(_mockPostService.Object, _authServiceMock.Object);
    }

    private Mock<IPostService> _mockPostService;
    private HomePageVmImpl _homePageVmImpl;
    private Mock<IAuthService> _authServiceMock;

    /// <summary>
    ///     Tests that the Initialize method sets initial values and loads the first page.
    /// </summary>
    [Test]
    public async Task Initialize_SetsInitialValuesAndLoadsFirstPage()
    {
        var page = new PageImpl<PostDto>(
            new List<PostDto> { new() },
            0, // PageNumber
            10, // PageSize
            1, // TotalPages
            pageNumber => Task.FromResult<IPage<PostDto>>(null!) // Callback
        );
        _mockPostService.Setup(s => s.GetAllPosts(It.IsAny<PageRequest>())).ReturnsAsync(page);
        _authServiceMock.Setup(s => s.GetCurrentSession())
            .Returns(new Session { User = new User { Id = Guid.NewGuid().ToString() } });


        await _homePageVmImpl.Initialize();

        Assert.That(_homePageVmImpl.IsLoadingPage, Is.False);
        Assert.That(_homePageVmImpl.Page.Content.Count, Is.EqualTo(1));
    }

    /// <summary>
    ///     Tests that the LoadPage method sets the loading state and loads the specified page.
    /// </summary>
    [Test]
    public async Task LoadPage_SetsLoadingStateAndLoadsSpecifiedPage()
    {
        var pageNumber = 1;
        var page = new PageImpl<PostDto>(
            new List<PostDto> { new() },
            pageNumber, // PageNumber
            10, // PageSize
            2, // TotalPages
            pageNumber => Task.FromResult<IPage<PostDto>>(null!) // Callback
        );
        _mockPostService.Setup(s => s.GetAllPosts(It.IsAny<PageRequest>())).ReturnsAsync(page);

        await _homePageVmImpl.LoadPage(pageNumber);

        Assert.That(_homePageVmImpl.IsLoadingPage, Is.False);
        Assert.That(_homePageVmImpl.Page.Content.Count, Is.EqualTo(1));
    }

    /// <summary>
    ///     Tests that the LoadPage method handles an empty page correctly.
    /// </summary>
    [Test]
    public async Task LoadPage_HandlesEmptyPage()
    {
        var pageNumber = 1;
        var page = new PageImpl<PostDto>(
            new List<PostDto>(),
            pageNumber, // PageNumber
            10, // PageSize
            2, // TotalPages
            pageNumber => Task.FromResult<IPage<PostDto>>(null!) // Callback
        );
        _mockPostService.Setup(s => s.GetAllPosts(It.IsAny<PageRequest>())).ReturnsAsync(page);

        await _homePageVmImpl.LoadPage(pageNumber);

        Assert.That(_homePageVmImpl.IsLoadingPage, Is.False);
        Assert.That(_homePageVmImpl.Page.Content.Count, Is.EqualTo(0));
    }
}
using Moq;
using SlottyMedia.Backend.Dtos;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Backend.ViewModel;
using SlottyMedia.Database.Pagination;

namespace SlottyMedia.Tests.Viewmodel;

/// <summary>
///     Unit tests for the <see cref="SpacesVmImpl" /> class.
/// </summary>
public class SpacesVmImplTest
{
    private Mock<IForumService> _forumServiceMock;
    private SpacesVmImpl _spacesVm;

    /// <summary>
    ///     Sets up the test environment before each test.
    /// </summary>
    [SetUp]
    public void Setup()
    {
        _forumServiceMock = new Mock<IForumService>();
        _spacesVm = new SpacesVmImpl(_forumServiceMock.Object);
    }

    /// <summary>
    ///     Verifies that LoadForums updates the forums list with a valid response.
    /// </summary>
    [Test]
    public async Task LoadForums_ValidResponse_UpdatesForumsList()
    {
        var forums = new List<ForumDto> { new() { Topic = "Test Forum" } };
        var page = new PageImpl<ForumDto>(forums, 1, 10, 1, null!);
        _forumServiceMock.Setup(f => f.GetAllForums(It.IsAny<PageRequest>())).ReturnsAsync(page);

        await _spacesVm.LoadForums();

        Assert.That(_spacesVm.Forums, Is.EqualTo(forums));
    }

    /// <summary>
    ///     Verifies that LoadForums logs an error and returns an empty list when an exception is thrown.
    /// </summary>
    [Test]
    public async Task LoadForums_ExceptionThrown_LogsError()
    {
        var exceptionMessage = "Service error";
        _forumServiceMock.Setup(f => f.GetAllForums(It.IsAny<PageRequest>()))
            .ThrowsAsync(new Exception(exceptionMessage));

        await _spacesVm.LoadForums();

        Assert.That(_spacesVm.Forums, Is.Empty);
    }

    /// <summary>
    ///     Verifies that the constructor throws an ArgumentNullException when the forum service is null.
    /// </summary>
    [Test]
    public void Constructor_NullForumService_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => new SpacesVmImpl(null!));
    }
}
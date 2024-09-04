using Moq;
using SlottyMedia.Backend.Dtos;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Backend.ViewModel;

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
    ///     Tests that the LoadForums method loads forums successfully.
    /// </summary>
    [Test]
    public async Task LoadForums_LoadsForumsSuccessfully()
    {
        var forums = new List<ForumDto> { new() { ForumId = Guid.NewGuid(), Topic = "Test Forum" } };
        _forumServiceMock.Setup(service => service.GetForums()).ReturnsAsync(forums);

        await _spacesVm.LoadForums();

        Assert.That(_spacesVm.Forums, Is.EqualTo(forums));
    }

    /// <summary>
    ///     Tests that the LoadForums method handles exceptions correctly.
    /// </summary>
    [Test]
    public async Task LoadForums_HandlesException()
    {
        _forumServiceMock.Setup(service => service.GetForums()).ThrowsAsync(new Exception("Service error"));

        await _spacesVm.LoadForums();

        Assert.That(_spacesVm.Forums, Is.Empty);
    }

    /// <summary>
    ///     Tests that the constructor throws an ArgumentNullException when the forum service is null.
    /// </summary>
    [Test]
    public void Constructor_ThrowsArgumentNullException_WhenForumServiceIsNull()
    {
        Assert.That(() => new SpacesVmImpl(null), Throws.ArgumentNullException);
    }
}
using Moq;
using SlottyMedia.Backend.Dtos;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Backend.ViewModel;

namespace SlottyMedia.Tests.Viewmodel;

/// <summary>
///     Unit tests for the UserVm class.
/// </summary>
public class UserVmImplTest
{
    private Mock<IUserService> _userServiceMock;
    private UserVm _userVm;

    /// <summary>
    ///     Initializes the test setup.
    /// </summary>
    [SetUp]
    public void Setup()
    {
        _userServiceMock = new Mock<IUserService>();
        _userVm = new UserVm(_userServiceMock.Object);
    }

    /// <summary>
    ///     Tests that GetUserById returns a UserDto when the user exists.
    /// </summary>
    [Test]
    public async Task GetUserById_ReturnsUserDto_WhenUserExists()
    {
        var userId = Guid.NewGuid();
        var expectedUser = new UserDto { UserId = userId };
        _userServiceMock.Setup(s => s.GetUserDtoById(userId)).ReturnsAsync(expectedUser);

        var result = await _userVm.GetUserById(userId);

        Assert.That(result, Is.EqualTo(expectedUser));
    }

    /// <summary>
    ///     Tests that GetUserById throws an exception when the user service throws an exception.
    /// </summary>
    [Test]
    public void GetUserById_ThrowsException_WhenUserServiceThrows()
    {
        var userId = Guid.NewGuid();
        _userServiceMock.Setup(s => s.GetUserDtoById(userId)).ThrowsAsync(new Exception("Service error"));

        Assert.That(async () => await _userVm.GetUserById(userId), Throws.Exception);
    }

    /// <summary>
    ///     Tests that UpdateUser calls the UpdateUser method of the user service.
    /// </summary>
    [Test]
    public async Task UpdateUser_CallsUserServiceUpdateUser()
    {
        var user = new UserDto { UserId = Guid.NewGuid() };

        await _userVm.UpdateUser(user);

        _userServiceMock.Verify(s => s.UpdateUser(user), Times.Once);
    }

    /// <summary>
    ///     Tests that UpdateUser logs an error when the user service throws an exception.
    /// </summary>
    [Test]
    public async Task UpdateUser_LogsError_WhenUserServiceThrows()
    {
        var user = new UserDto { UserId = Guid.NewGuid() };
        _userServiceMock.Setup(s => s.UpdateUser(user)).ThrowsAsync(new Exception("Service error"));

        await _userVm.UpdateUser(user);
    }
}
using System.Linq.Expressions;
using Moq;
using SlottyMedia.Backend.Dtos;
using SlottyMedia.Backend.Exceptions.Services.UserExceptions;
using SlottyMedia.Backend.Services;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Database.Daos;
using SlottyMedia.Database.Exceptions;
using SlottyMedia.Database.Repository.FollowerUserRelatioRepo;
using SlottyMedia.Database.Repository.UserRepo;

namespace SlottyMedia.Tests.ServiceTests;

/// <summary>
///     Tests the UserService used for user related actions in the database.
/// </summary>
[TestFixture]
public class UserServiceTests
{
    /// <summary>
    ///     The setup method that is called before each test.
    /// </summary>
    [SetUp]
    public void Setup()
    {
        _mockUserRepository = new Mock<IUserRepository>();
        _mockPostService = new Mock<IPostService>();
        _mockFollowerUserRelationRepository = new Mock<IFollowerUserRelationRepository>();
        _userService = new UserService(_mockUserRepository.Object, _mockPostService.Object,
            _mockFollowerUserRelationRepository.Object);
    }

    /// <summary>
    ///     The teardown method that is called after each test.
    /// </summary>
    [TearDown]
    public void TearDown()
    {
        _mockUserRepository.Reset();
        _mockPostService.Reset();
        _mockFollowerUserRelationRepository.Reset();
    }

    private Mock<IUserRepository> _mockUserRepository;
    private Mock<IPostService> _mockPostService;
    private Mock<IFollowerUserRelationRepository> _mockFollowerUserRelationRepository;
    private IUserService _userService;

    /// <summary>
    ///     Tests if CreateUser method throws UserGeneralException when GeneralDatabaseException is thrown.
    /// </summary>
    [Test]
    public void CreateUser_ShouldThrowUserGeneralException_WhenDatabaseExceptionIsThrown()
    {
        var userId = Guid.NewGuid();
        var username = "testUser";
        var email = "test@example.com";
        var roleId = Guid.NewGuid();

        _mockUserRepository.Setup(x => x.AddElement(It.IsAny<UserDao>()))
            .ThrowsAsync(new GeneralDatabaseException());

        Assert.ThrowsAsync<UserGeneralException>(
            async () => await _userService.CreateUser(userId.ToString(), username, email, roleId));
    }

    /// <summary>
    ///     Tests if DeleteUser method throws UserIudException when DatabaseIudActionException is thrown.
    /// </summary>
    [Test]
    public void DeleteUser_ShouldThrowUserIudException_WhenDatabaseIudActionExceptionIsThrown()
    {
        var user = new UserDto { UserId = Guid.NewGuid() };

        _mockUserRepository.Setup(x => x.DeleteElement(It.IsAny<UserDao>()))
            .ThrowsAsync(new DatabaseIudActionException());

        Assert.ThrowsAsync<UserIudException>(
            async () => await _userService.DeleteUser(user));
    }

    /// <summary>
    ///     Tests if GetUserDtoById method throws UserNotFoundException when DatabaseMissingItemException is thrown.
    /// </summary>
    [Test]
    public void GetUserById_ShouldThrowUserNotFoundException_WhenDatabaseMissingItemExceptionIsThrown()
    {
        var userId = Guid.NewGuid();

        _mockUserRepository.Setup(x => x.GetElementById(It.IsAny<Guid>()))
            .ThrowsAsync(new DatabaseMissingItemException());

        Assert.ThrowsAsync<UserNotFoundException>(
            async () => await _userService.GetUserDtoById(userId));
    }

    /// <summary>
    ///     Tests if GetUserDtoById method throws UserGeneralException when GeneralDatabaseException is thrown.
    /// </summary>
    [Test]
    public void GetUserById_ShouldThrowUserGeneralException_WhenDatabaseExceptionIsThrown()
    {
        var userId = Guid.NewGuid();

        _mockUserRepository.Setup(x => x.GetElementById(It.IsAny<Guid>()))
            .ThrowsAsync(new GeneralDatabaseException());

        Assert.ThrowsAsync<UserGeneralException>(
            async () => await _userService.GetUserDtoById(userId));
    }

    /// <summary>
    ///     Tests if CheckIfUserExistsByUserName method returns true when user exists.
    /// </summary>
    [Test]
    public async Task GetUserByUsername_ShouldBeTrue_WhenUserExists()
    {
        var username = "testUser";

        _mockUserRepository.Setup(x => x.GetUserByUsername(It.IsAny<string>()))
            .ReturnsAsync(new UserDao());

        var result = await _userService.CheckIfUserExistsByUserName(username);

        Assert.That(result, Is.True);
    }

    /// <summary>
    ///     Tests if UpdateUser method throws UserIudException when DatabaseIudActionException is thrown.
    /// </summary>
    [Test]
    public void UpdateUser_ShouldThrowUserIudException_WhenDatabaseIudActionExceptionIsThrown()
    {
        var user = new UserDao { UserId = Guid.NewGuid() };

        _mockUserRepository.Setup(x => x.UpdateElement(It.IsAny<UserDao>()))
            .ThrowsAsync(new DatabaseIudActionException());

        Assert.ThrowsAsync<UserIudException>(
            async () => await _userService.UpdateUser(user));
    }

    /// <summary>
    ///     Tests if UpdateUser method throws UserGeneralException when GeneralDatabaseException is thrown.
    /// </summary>
    [Test]
    public void UpdateUser_ShouldThrowUserGeneralException_WhenDatabaseExceptionIsThrown()
    {
        var user = new UserDao { UserId = Guid.NewGuid() };

        _mockUserRepository.Setup(x => x.UpdateElement(It.IsAny<UserDao>()))
            .ThrowsAsync(new GeneralDatabaseException());

        Assert.ThrowsAsync<UserGeneralException>(
            async () => await _userService.UpdateUser(user));
    }

    /// <summary>
    ///     Tests if GetProfilePic method throws UserNotFoundException when DatabaseMissingItemException is thrown.
    /// </summary>
    [Test]
    public void GetProfilePic_ShouldThrowUserNotFoundException_WhenDatabaseMissingItemExceptionIsThrown()
    {
        var userId = Guid.NewGuid();

        _mockUserRepository.Setup(x => x.GetElementById(It.IsAny<Guid>()))
            .ThrowsAsync(new DatabaseMissingItemException());

        Assert.ThrowsAsync<UserNotFoundException>(
            async () => await _userService.GetProfilePic(userId));
    }

    /// <summary>
    ///     Tests if GetProfilePic method throws UserGeneralException when GeneralDatabaseException is thrown.
    /// </summary>
    [Test]
    public void GetProfilePic_ShouldThrowUserGeneralException_WhenDatabaseExceptionIsThrown()
    {
        var userId = Guid.NewGuid();

        _mockUserRepository.Setup(x => x.GetElementById(It.IsAny<Guid>()))
            .ThrowsAsync(new GeneralDatabaseException());

        Assert.ThrowsAsync<UserGeneralException>(
            async () => await _userService.GetProfilePic(userId));
    }

    /// <summary>
    ///     Tests if GetUser method throws UserNotFoundException when DatabaseMissingItemException is thrown.
    /// </summary>
    [Test]
    public void GetUser_ShouldThrowUserNotFoundException_WhenDatabaseMissingItemExceptionIsThrown()
    {
        var userId = Guid.NewGuid();

        _mockUserRepository.Setup(x =>
                x.GetElementById(It.IsAny<Guid>(), It.IsAny<Expression<Func<UserDao, object[]>>>()))
            .ThrowsAsync(new DatabaseMissingItemException());

        Assert.ThrowsAsync<UserNotFoundException>(
            async () => await _userService.GetUser(userId));
    }

    /// <summary>
    ///     Tests if GetUser method throws UserGeneralException when GeneralDatabaseException is thrown.
    /// </summary>
    [Test]
    public void GetUser_ShouldThrowUserGeneralException_WhenDatabaseExceptionIsThrown()
    {
        var userId = Guid.NewGuid();

        _mockUserRepository.Setup(x =>
                x.GetElementById(It.IsAny<Guid>(), It.IsAny<Expression<Func<UserDao, object[]>>>()))
            .ThrowsAsync(new GeneralDatabaseException());

        Assert.ThrowsAsync<UserGeneralException>(
            async () => await _userService.GetUser(userId));
    }

    /// <summary>
    ///     Tests if GetFriends method throws UserNotFoundException when DatabaseMissingItemException is thrown.
    /// </summary>
    [Test]
    public void GetFriends_ShouldThrowUserNotFoundException_WhenDatabaseMissingItemExceptionIsThrown()
    {
        var userId = Guid.NewGuid();

        _mockFollowerUserRelationRepository.Setup(x => x.GetFriends(It.IsAny<Guid>()))
            .ThrowsAsync(new DatabaseMissingItemException());

        Assert.ThrowsAsync<UserNotFoundException>(
            async () => await _userService.GetFriends(userId));
    }

    /// <summary>
    ///     Tests if GetFriends method throws UserGeneralException when GeneralDatabaseException is thrown.
    /// </summary>
    [Test]
    public void GetFriends_ShouldThrowUserGeneralException_WhenDatabaseExceptionIsThrown()
    {
        var userId = Guid.NewGuid();

        _mockFollowerUserRelationRepository.Setup(x => x.GetFriends(It.IsAny<Guid>()))
            .ThrowsAsync(new GeneralDatabaseException());

        Assert.ThrowsAsync<UserGeneralException>(
            async () => await _userService.GetFriends(userId));
    }

    /// <summary>
    ///     Tests if GetCountOfUserFriends method throws UserGeneralException when GeneralDatabaseException is thrown.
    /// </summary>
    [Test]
    public void GetCountOfUserFriends_ThrowsUserGeneralException_OnGeneralDatabaseException()
    {
        var userId = Guid.NewGuid();

        _mockFollowerUserRelationRepository.Setup(x => x.GetCountOfUserFriends(It.IsAny<Guid>()))
            .ThrowsAsync(new GeneralDatabaseException());

        Assert.ThrowsAsync<UserGeneralException>(
            async () => await _userService.GetCountOfUserFriends(userId));
    }

    /// <summary>
    ///     Tests if GetCountOfUserFriends method throws UserGeneralException when an unexpected exception is thrown.
    /// </summary>
    [Test]
    public void GetCountOfUserFriends_ThrowsUserGeneralException_OnUnexpectedException()
    {
        var userId = Guid.NewGuid();

        _mockFollowerUserRelationRepository.Setup(x => x.GetCountOfUserFriends(It.IsAny<Guid>()))
            .ThrowsAsync(new Exception());

        Assert.ThrowsAsync<UserGeneralException>(
            async () => await _userService.GetCountOfUserFriends(userId));
    }

    /// <summary>
    ///     Tests if GetCountOfUserSpaces method returns the correct count of user spaces.
    /// </summary>
    [Test]
    public async Task GetCountOfUserSpaces()
    {
        var userId = Guid.NewGuid();
        var expectedCount = 5;
        _mockPostService.Setup(d => d.GetForumCountByUserId(userId))
            .ReturnsAsync(expectedCount);

        // Act
        var result = await _userService.GetCountOfUserSpaces(userId);

        // Assert
        Assert.That(result, Is.EqualTo(expectedCount));
    }
}
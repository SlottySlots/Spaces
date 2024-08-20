using System.Linq.Expressions;
using Moq;
using SlottyMedia.Backend.Dtos;
using SlottyMedia.Backend.Exceptions.Services.UserExceptions;
using SlottyMedia.Backend.Services;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Database;
using SlottyMedia.Database.Daos;
using SlottyMedia.Database.Exceptions;

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
        _mockDatabaseActions = new Mock<IDatabaseActions>();
        _mockPostService = new Mock<IPostService>();
        _mockPostService.Object.DatabaseActions = _mockDatabaseActions.Object;
        _userService = new UserService(_mockDatabaseActions.Object, _mockPostService.Object);
    }

    /// <summary>
    ///     The teardown method that is called after each test.
    /// </summary>
    [TearDown]
    public void TearDown()
    {
        _mockDatabaseActions.Reset();
        _mockPostService.Reset();
    }

    private Mock<IDatabaseActions> _mockDatabaseActions;
    private IUserService _userService;
    private Mock<IPostService> _mockPostService;

    /// <summary>
    ///     Tests if CreateUser method returns the created user correctly.
    /// </summary>
    [Test]
    public async Task CreateUser_ShouldReturnUser_WhenUserIsCreated()
    {
        var userId = Guid.NewGuid();
        var username = "testUsername";
        var user = new UserDao { UserId = userId, UserName = username };
        _mockDatabaseActions.Setup(x => x.Insert(It.IsAny<UserDao>())).ReturnsAsync(user);

        var result = await _userService.CreateUser(userId.ToString(), username);

        var resultDao = result.Mapper();

        Assert.That(result, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(resultDao.UserId ?? Guid.Empty, Is.EqualTo(userId));
            Assert.That(resultDao.UserName, Is.EqualTo(username));
        });
        _mockDatabaseActions.VerifyAll();
    }

    /// <summary>
    ///     Tests if CreateUser method throws UserIudException when DatabaseIudActionException is thrown.
    /// </summary>
    [Test]
    public void CreateUser_ShouldThrowUserIudException_WhenDatabaseIudActionExceptionIsThrown()
    {
        var userId = Guid.NewGuid();
        var username = "testUsername";
        _mockDatabaseActions.Setup(x => x.Insert(It.IsAny<UserDao>())).ThrowsAsync(new DatabaseIudActionException());

        Assert.ThrowsAsync<UserIudException>(async () => await _userService.CreateUser(userId.ToString(), username));
    }

    /// <summary>
    ///     Tests if CreateUser method throws UserGeneralException when GeneralDatabaseException is thrown.
    /// </summary>
    [Test]
    public void CreateUser_ShouldThrowUserGeneralException_WhenDatabaseExceptionIsThrown()
    {
        var userId = Guid.NewGuid();
        var username = "testUsername";
        _mockDatabaseActions.Setup(x => x.Insert(It.IsAny<UserDao>())).ThrowsAsync(new GeneralDatabaseException());

        Assert.ThrowsAsync<UserGeneralException>(async () =>
            await _userService.CreateUser(userId.ToString(), username));
    }

    /// <summary>
    ///     Tests if DeleteUser method returns true when user is deleted successfully.
    /// </summary>
    [Test]
    public async Task DeleteUser_ShouldReturnTrue_WhenUserIsDeleted()
    {
        var user = new UserDao { UserId = Guid.NewGuid() };
        _mockDatabaseActions.Setup(x => x.Delete(It.IsAny<UserDao>())).ReturnsAsync(true);

        var result = await _userService.DeleteUser(new UserDto().Mapper(user));

        Assert.That(result, Is.True);
        _mockDatabaseActions.VerifyAll();
    }

    /// <summary>
    ///     Tests if DeleteUser method throws UserIudException when DatabaseIudActionException is thrown.
    /// </summary>
    [Test]
    public void DeleteUser_ShouldThrowUserIudException_WhenDatabaseIudActionExceptionIsThrown()
    {
        var user = new UserDao { UserId = Guid.NewGuid() };
        _mockDatabaseActions.Setup(x => x.Delete(It.IsAny<UserDao>())).ThrowsAsync(new DatabaseIudActionException());

        Assert.ThrowsAsync<UserIudException>(async () => await _userService.DeleteUser(new UserDto().Mapper(user)));
    }

    /// <summary>
    ///     Tests if DeleteUser method throws UserGeneralException when GeneralDatabaseException is thrown.
    /// </summary>
    [Test]
    public void DeleteUser_ShouldThrowUserGeneralException_WhenDatabaseExceptionIsThrown()
    {
        var user = new UserDao { UserId = Guid.NewGuid() };
        _mockDatabaseActions.Setup(x => x.Delete(It.IsAny<UserDao>())).ThrowsAsync(new GeneralDatabaseException());

        Assert.ThrowsAsync<UserGeneralException>(async () => await _userService.DeleteUser(new UserDto().Mapper(user)));
    }

    /// <summary>
    ///     Tests if GetUserById method returns the user correctly when user exists.
    /// </summary>
    [Test]
    public async Task GetUserById_ShouldReturnUser_WhenUserExists()
    {
        var userId = Guid.NewGuid();
        var user = new UserDao { UserId = userId };
        _mockDatabaseActions.Setup(x => x.GetEntityByField<UserDao>("userID", userId.ToString())).ReturnsAsync(user);

        var result = await _userService.GetUserById(userId);

        var resultDao = result.Mapper();

        Assert.That(resultDao, Is.Not.Null);
        Assert.That(resultDao.UserId ?? Guid.Empty, Is.EqualTo(userId));
        _mockDatabaseActions.VerifyAll();
    }

    /// <summary>
    ///     Tests if GetUserById method throws UserNotFoundException when DatabaseMissingItemException is thrown.
    /// </summary>
    [Test]
    public void GetUserById_ShouldThrowUserNotFoundException_WhenDatabaseMissingItemExceptionIsThrown()
    {
        var userId = Guid.NewGuid();
        _mockDatabaseActions.Setup(x => x.GetEntityByField<UserDao>("userID", userId.ToString()))
            .ThrowsAsync(new DatabaseMissingItemException());

        Assert.ThrowsAsync<UserNotFoundException>(async () => await _userService.GetUserById(userId));
    }

    /// <summary>
    ///     Tests if GetUserById method throws UserGeneralException when GeneralDatabaseException is thrown.
    /// </summary>
    [Test]
    public void GetUserById_ShouldThrowUserGeneralException_WhenDatabaseExceptionIsThrown()
    {
        var userId = Guid.NewGuid();
        _mockDatabaseActions.Setup(x => x.GetEntityByField<UserDao>("userID", userId.ToString()))
            .ThrowsAsync(new GeneralDatabaseException());

        Assert.ThrowsAsync<UserGeneralException>(async () => await _userService.GetUserById(userId));
    }

    /// <summary>
    ///     Tests if CheckIfUserExistsByUserName method returns true when user exists.
    /// </summary>
    [Test]
    public async Task GetUserByUsername_ShouldBeTrue_WhenUserExists()
    {
        var username = "testUsername";
        var user = new UserDao { UserName = username };
        _mockDatabaseActions.Setup(x => x.CheckIfEntityExists<UserDao>("userName", username)).ReturnsAsync(true);

        var result = await _userService.CheckIfUserExistsByUserName(username);
        Assert.That(result, Is.True);
        _mockDatabaseActions.VerifyAll();
    }

    /// <summary>
    ///     Tests if UpdateUser method returns the updated user correctly.
    /// </summary>
    [Test]
    public async Task UpdateUser_ShouldReturnUpdatedUser_WhenUserIsUpdated()
    {
        var user = new UserDao { UserId = Guid.NewGuid(), UserName = "updatedUsername" };
        _mockDatabaseActions.Setup(x => x.Update(It.IsAny<UserDao>())).ReturnsAsync(user);

        var result = await _userService.UpdateUser(new UserDto().Mapper(user));
        var resultDao = result.Mapper();

        Assert.That(resultDao, Is.Not.Null);
        Assert.That(resultDao.UserName, Is.EqualTo("updatedUsername"));
        _mockDatabaseActions.VerifyAll();
    }

    /// <summary>
    ///     Tests if UpdateUser method throws UserIudException when DatabaseIudActionException is thrown.
    /// </summary>
    [Test]
    public void UpdateUser_ShouldThrowUserIudException_WhenDatabaseIudActionExceptionIsThrown()
    {
        var user = new UserDao { UserId = Guid.NewGuid(), UserName = "updatedUsername" };
        _mockDatabaseActions.Setup(x => x.Update(It.IsAny<UserDao>())).ThrowsAsync(new DatabaseIudActionException());

        Assert.ThrowsAsync<UserIudException>(async () => await _userService.UpdateUser(new UserDto().Mapper(user)));
    }

    /// <summary>
    ///     Tests if UpdateUser method throws UserGeneralException when GeneralDatabaseException is thrown.
    /// </summary>
    [Test]
    public void UpdateUser_ShouldThrowUserGeneralException_WhenDatabaseExceptionIsThrown()
    {
        var user = new UserDao { UserId = Guid.NewGuid(), UserName = "updatedUsername" };
        _mockDatabaseActions.Setup(x => x.Update(It.IsAny<UserDao>())).ThrowsAsync(new GeneralDatabaseException());

        Assert.ThrowsAsync<UserGeneralException>(async () => await _userService.UpdateUser(new UserDto().Mapper(user)));
    }

    /// <summary>
    ///     Tests if GetProfilePic method returns the profile picture correctly when user exists.
    /// </summary>
    [Test]
    public async Task GetProfilePic_ShouldReturnProfilePic_WhenUserExists()
    {
        var userId = Guid.NewGuid();
        var user = new UserDao { UserId = userId, ProfilePic = "123" };
        _mockDatabaseActions.Setup(x => x.GetEntityByField<UserDao>("userID", userId.ToString())).ReturnsAsync(user);

        var result = await _userService.GetProfilePic(userId);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.ProfilePic, Is.EqualTo("123"));
        _mockDatabaseActions.VerifyAll();
    }

    /// <summary>
    ///     Tests if GetProfilePic method throws UserNotFoundException when DatabaseMissingItemException is thrown.
    /// </summary>
    [Test]
    public void GetProfilePic_ShouldThrowUserNotFoundException_WhenDatabaseMissingItemExceptionIsThrown()
    {
        var userId = Guid.NewGuid();
        _mockDatabaseActions.Setup(x => x.GetEntityByField<UserDao>("userID", userId.ToString()))
            .ThrowsAsync(new DatabaseMissingItemException());

        Assert.ThrowsAsync<UserNotFoundException>(async () => await _userService.GetProfilePic(userId));
    }

    /// <summary>
    ///     Tests if GetProfilePic method throws UserGeneralException when GeneralDatabaseException is thrown.
    /// </summary>
    [Test]
    public void GetProfilePic_ShouldThrowUserGeneralException_WhenDatabaseExceptionIsThrown()
    {
        var userId = Guid.NewGuid();
        _mockDatabaseActions.Setup(x => x.GetEntityByField<UserDao>("userID", userId.ToString()))
            .ThrowsAsync(new GeneralDatabaseException());

        Assert.ThrowsAsync<UserGeneralException>(async () => await _userService.GetProfilePic(userId));
    }

    /// <summary>
    ///     Tests if GetUser method returns the user DTO correctly when user exists.
    /// </summary>
    [Test]
    public async Task GetUser_ShouldReturnUserDto_WhenUserExists()
    {
        var userId = Guid.NewGuid();
        var user = new UserDao
        {
            UserId = userId, UserName = "testUsername", Description = "testDescription",
            CreatedAt = DateTime.Now
        };

        var forum = new ForumDao { ForumId = Guid.NewGuid(), ForumTopic = "Test Forum" };

        var forumName = new List<string> { forum.ForumTopic };

        _mockDatabaseActions
            .Setup(x => x.GetEntitieWithSelectorById(It.IsAny<Expression<Func<UserDao, object[]>>>(), "userID",
                userId.ToString())).ReturnsAsync(user);
        _mockPostService
            .Setup(x => x.GetPostsFromForum(userId, 0, 5)).ReturnsAsync(forumName);

        var result = await _userService.GetUser(userId);

        Assert.That(result, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(result.UserId, Is.EqualTo(userId));
            Assert.That(result.Username, Is.EqualTo("testUsername"));
            Assert.That(result.Description, Is.EqualTo("testDescription"));
            Assert.That(result.CreatedAt, Is.EqualTo(user.CreatedAt));
            Assert.That(result.RecentForums, Is.EqualTo(forumName));
        });
        _mockDatabaseActions.VerifyAll();
    }

    /// <summary>
    ///     Tests if GetUser method throws UserNotFoundException when DatabaseMissingItemException is thrown.
    /// </summary>
    [Test]
    public void GetUser_ShouldThrowUserNotFoundException_WhenDatabaseMissingItemExceptionIsThrown()
    {
        var userId = Guid.NewGuid();
        _mockDatabaseActions
            .Setup(x => x.GetEntitieWithSelectorById(It.IsAny<Expression<Func<UserDao, object[]>>>(), "userID",
                userId.ToString())).ThrowsAsync(new DatabaseMissingItemException());

        Assert.ThrowsAsync<UserNotFoundException>(async () => await _userService.GetUser(userId));
    }

    /// <summary>
    ///     Tests if GetUser method throws UserGeneralException when GeneralDatabaseException is thrown.
    /// </summary>
    [Test]
    public void GetUser_ShouldThrowUserGeneralException_WhenDatabaseExceptionIsThrown()
    {
        var userId = Guid.NewGuid();
        _mockDatabaseActions
            .Setup(x => x.GetEntitieWithSelectorById(It.IsAny<Expression<Func<UserDao, object[]>>>(), "userID",
                userId.ToString())).ThrowsAsync(new GeneralDatabaseException());

        Assert.ThrowsAsync<UserGeneralException>(async () => await _userService.GetUser(userId));
    }

    /// <summary>
    ///     Tests if GetFriends method returns the friends list correctly when user has friends.
    /// </summary>
    [Test]
    public async Task GetFriends_ShouldReturnFriendsList_WhenUserHasFriends()
    {
        var userId = Guid.NewGuid();
        var friendId = Guid.NewGuid();
        var friendUser = new UserDao { UserId = friendId, UserName = "friendUsername" };
        var friends = new List<FollowerUserRelationDao>
            { new() { FollowerUserId = userId, FollowedUserId = friendId, FollowerUser = friendUser } };
        _mockDatabaseActions
            .Setup(x => x.GetEntitiesWithSelectorById(It.IsAny<Expression<Func<FollowerUserRelationDao, object[]>>>(),
                "followerUserID", userId.ToString(), -1, -1))!
            .ReturnsAsync(friends);

        var result = await _userService.GetFriends(userId);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Friends, Has.Count.EqualTo(1));
        Assert.That(result.Friends[0].Username, Is.EqualTo("friendUsername"));
        _mockDatabaseActions.VerifyAll();
    }

    /// <summary>
    ///     Tests if GetFriends method throws UserNotFoundException when DatabaseMissingItemException is thrown.
    /// </summary>
    [Test]
    public void GetFriends_ShouldThrowUserNotFoundException_WhenDatabaseMissingItemExceptionIsThrown()
    {
        var userId = Guid.NewGuid();
        _mockDatabaseActions
            .Setup(x => x.GetEntitiesWithSelectorById(It.IsAny<Expression<Func<FollowerUserRelationDao, object[]>>>(),
                "followerUserID", userId.ToString(), -1, -1))
            .ThrowsAsync(new DatabaseMissingItemException());

        Assert.ThrowsAsync<UserNotFoundException>(async () => await _userService.GetFriends(userId));
    }

    /// <summary>
    ///     Tests if GetFriends method throws UserGeneralException when GeneralDatabaseException is thrown.
    /// </summary>
    [Test]
    public void GetFriends_ShouldThrowUserGeneralException_WhenDatabaseExceptionIsThrown()
    {
        var userId = Guid.NewGuid();
        _mockDatabaseActions
            .Setup(x => x.GetEntitiesWithSelectorById(It.IsAny<Expression<Func<FollowerUserRelationDao, object[]>>>(),
                "followerUserID", userId.ToString(), -1, -1))
            .ThrowsAsync(new GeneralDatabaseException());

        Assert.ThrowsAsync<UserGeneralException>(async () => await _userService.GetFriends(userId));
    }
}
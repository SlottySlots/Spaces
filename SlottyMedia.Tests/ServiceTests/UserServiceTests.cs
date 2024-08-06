using System.Linq.Expressions;
using Moq;
using SlottyMedia.Backend.Services;
using SlottyMedia.Database;
using SlottyMedia.Database.Daos;

namespace SlottyMedia.Tests.ServiceTests;

[TestFixture]
public class UserServiceTests
{
    private Mock<IDatabaseActions> _mockDatabaseActions;
    private UserService _userService;

    [SetUp]
    public void Setup()
    {
        _mockDatabaseActions = new Mock<IDatabaseActions>();
        _userService = new UserService(_mockDatabaseActions.Object);
    }

    [Test]
    public async Task CreateUser_ShouldReturnUser_WhenUserIsCreated()
    {
        // Arrange
        var userId = "testUserId";
        var username = "testUsername";
        var user = new UserDao { UserId = userId, UserName = username };
        _mockDatabaseActions.Setup(x => x.Insert(It.IsAny<UserDao>())).ReturnsAsync(user);

        // Act
        var result = await _userService.CreateUser(userId, username);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(result.UserId, Is.EqualTo(userId));
            Assert.That(result.UserName, Is.EqualTo(username));
        });
    }

    [Test]
    public async Task DeleteUser_ShouldReturnTrue_WhenUserIsDeleted()
    {
        // Arrange
        var user = new UserDao { UserId = Guid.NewGuid().ToString() };
        _mockDatabaseActions.Setup(x => x.Delete(It.IsAny<UserDao>())).ReturnsAsync(true);

        // Act
        var result = await _userService.DeleteUser(user);

        // Assert
        Assert.That(result, Is.True);
    }

    [Test]
    public async Task GetUserById_ShouldReturnUser_WhenUserExists()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var user = new UserDao { UserId = userId.ToString() };
        _mockDatabaseActions.Setup(x => x.GetEntityByField<UserDao>("userID", userId.ToString())).ReturnsAsync(user);

        // Act
        var result = await _userService.GetUserById(userId);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.UserId, Is.EqualTo(userId.ToString()));
    }

    [Test]
    public async Task UpdateUser_ShouldReturnUpdatedUser_WhenUserIsUpdated()
    {
        // Arrange
        var user = new UserDao { UserId = Guid.NewGuid().ToString(), UserName = "updatedUsername" };
        _mockDatabaseActions.Setup(x => x.Update(It.IsAny<UserDao>())).ReturnsAsync(user);

        // Act
        var result = await _userService.UpdateUser(user);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.UserName, Is.EqualTo("updatedUsername"));
    }

    [Test]
    public async Task GetProfilePic_ShouldReturnProfilePic_WhenUserExists()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var user = new UserDao { UserId = userId.ToString(), ProfilePic = 123 };
        _mockDatabaseActions.Setup(x => x.GetEntityByField<UserDao>("userID", userId.ToString())).ReturnsAsync(user);

        // Act
        var result = await _userService.GetProfilePic(userId);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.ProfilePic, Is.EqualTo(123));
    }

    [Test]
    public async Task GetUser_ShouldReturnUserDto_WhenUserExists()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var user = new UserDao
        {
            UserId = userId.ToString(), UserName = "testUsername", Description = "testDescription",
            CreatedAt = DateTime.Now
        };
        _mockDatabaseActions
            .Setup(x => x.GetEntitieWithSelectorById(It.IsAny<Expression<Func<UserDao, object[]>>>(), "userID",
                userId.ToString())).ReturnsAsync(user);

        // Act
        var result = await _userService.GetUser(userId);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(result.UserId, Is.EqualTo(userId));
            Assert.That(result.Username, Is.EqualTo("testUsername"));
        });
    }

    [Test]
    public async Task GetFriends_ShouldReturnFriendsList_WhenUserHasFriends()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var friendId = Guid.NewGuid();
        var friends = new List<FollowerUserRelationDao> { new() { FollowerUserId = userId.ToString(), FollowedUserId = friendId.ToString() } };
        var friendUser = new UserDao { UserId = friendId.ToString(), UserName = "friendUsername" };
        _mockDatabaseActions
            .Setup(x => x.GetEntitiesWithSelectorById(It.IsAny<Expression<Func<FollowerUserRelationDao, object[]>>>(),
                "followerUserID", userId.ToString())).ReturnsAsync(friends);
        _mockDatabaseActions.Setup(x => x.GetEntityByField<UserDao>("userID", friendId.ToString())).ReturnsAsync(friendUser);

        // Act
        var result = await _userService.GetFriends(userId);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Friends.Count, Is.EqualTo(1));
        Assert.That(result.Friends[0].Username, Is.EqualTo("friendUsername"));
    }
}
using System.Linq.Expressions;
using Moq;
using SlottyMedia.Backend.Services;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Database;
using SlottyMedia.Database.Daos;

namespace SlottyMedia.Tests.ServiceTests;

/// <summary>
/// Test class for UserService.
/// </summary>
[TestFixture]
public class UserServiceTests
{
    private Mock<IDatabaseActions> _mockDatabaseActions;
    private IUserService _userService;
    private Mock<PostService> _mockPostService;

    /// <summary>
    /// Sets up the test environment before each test.
    /// </summary>
    [SetUp]
    public void Setup()
    {
        _mockDatabaseActions = new Mock<IDatabaseActions>();
        _mockPostService = new Mock<PostService>(_mockDatabaseActions.Object);
        _userService = new UserService(_mockDatabaseActions.Object, _mockPostService.Object);
    }

    /// <summary>
    /// Tests if CreateUser method returns a user when the user is created successfully.
    /// </summary>
    [Test]
    public async Task CreateUser_ShouldReturnUser_WhenUserIsCreated()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var username = "testUsername";
        var user = new UserDao { UserId = userId, UserName = username };
        _mockDatabaseActions.Setup(x => x.Insert(It.IsAny<UserDao>())).ReturnsAsync(user);

        // Act
        var result = await _userService.CreateUser(userId.ToString(), username);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(result.UserId ?? Guid.Empty, Is.EqualTo(userId));
            Assert.That(result.UserName, Is.EqualTo(username));
        });
    }

    /// <summary>
    /// Tests if DeleteUser method returns true when the user is deleted successfully.
    /// </summary>
    [Test]
    public async Task DeleteUser_ShouldReturnTrue_WhenUserIsDeleted()
    {
        // Arrange
        var user = new UserDao { UserId = Guid.NewGuid() };
        _mockDatabaseActions.Setup(x => x.Delete(It.IsAny<UserDao>())).ReturnsAsync(true);

        // Act
        var result = await _userService.DeleteUser(user);

        // Assert
        Assert.That(result, Is.True);
    }

    /// <summary>
    /// Tests if GetUserById method returns a user when the user exists.
    /// </summary>
    [Test]
    public async Task GetUserById_ShouldReturnUser_WhenUserExists()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var user = new UserDao { UserId = userId };
        _mockDatabaseActions.Setup(x => x.GetEntityByField<UserDao>("userID", userId.ToString())).ReturnsAsync(user);

        // Act
        var result = await _userService.GetUserById(userId);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.UserId ?? Guid.Empty, Is.EqualTo(userId));
    }

    /// <summary>
    /// Tests if UpdateUser method returns the updated user when the user is updated successfully.
    /// </summary>
    [Test]
    public async Task UpdateUser_ShouldReturnUpdatedUser_WhenUserIsUpdated()
    {
        // Arrange
        var user = new UserDao { UserId = Guid.NewGuid(), UserName = "updatedUsername" };
        _mockDatabaseActions.Setup(x => x.Update(It.IsAny<UserDao>())).ReturnsAsync(user);

        // Act
        var result = await _userService.UpdateUser(user);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.UserName, Is.EqualTo("updatedUsername"));
    }

    /// <summary>
    /// Tests if GetProfilePic method returns the profile picture when the user exists.
    /// </summary>
    [Test]
    public async Task GetProfilePic_ShouldReturnProfilePic_WhenUserExists()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var user = new UserDao { UserId = userId, ProfilePic = 123 };
        _mockDatabaseActions.Setup(x => x.GetEntityByField<UserDao>("userID", userId.ToString())).ReturnsAsync(user);

        // Act
        var result = await _userService.GetProfilePic(userId);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.ProfilePic, Is.EqualTo(123));
    }

    /// <summary>
    /// Tests if GetUser method returns a UserDto when the user exists.
    /// </summary>
    [Test]
    public async Task GetUser_ShouldReturnUserDto_WhenUserExists()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var user = new UserDao
        {
            UserId = userId, UserName = "testUsername", Description = "testDescription",
            CreatedAt = DateTime.Now
        };

        var forum = new ForumDao { ForumId = Guid.NewGuid(), ForumTopic = "Test Forum" };

        var posts = new List<PostsDao>
        {
            new PostsDao { PostId = Guid.NewGuid(), Content = "Test Post 1", ForumId = forum.ForumId},
            new PostsDao { PostId = Guid.NewGuid(), Content = "Test Post 2", ForumId = forum.ForumId}
        };

        var forumName = new List<string>() { forum.ForumTopic };

        _mockDatabaseActions
            .Setup(x => x.GetEntitieWithSelectorById(It.IsAny<Expression<Func<UserDao, object[]>>>(), "userID",
                userId.ToString())).ReturnsAsync(user);
        _mockPostService
            .Setup(x => x.GetPostsFromForum(userId, 5)).ReturnsAsync(forumName);

        // Act
        var result = await _userService.GetUser(userId);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(result.UserId, Is.EqualTo(userId));
            Assert.That(result.Username, Is.EqualTo("testUsername"));
            Assert.That(result.Description, Is.EqualTo("testDescription"));
            Assert.That(result.CreatedAt, Is.EqualTo(user.CreatedAt));
            Assert.That(result.RecentForums, Is.EqualTo(forumName));
        });
    }

    /// <summary>
    /// Tests if GetFriends method returns a list of friends when the user has friends.
    /// </summary>
    [Test]
    public async Task GetFriends_ShouldReturnFriendsList_WhenUserHasFriends()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var friendId = Guid.NewGuid();
        var friends = new List<FollowerUserRelationDao> { new() { FollowerUserId = userId, FollowedUserId = friendId } };
        var friendUser = new UserDao { UserId = friendId, UserName = "friendUsername" };
        _mockDatabaseActions
            .Setup(x => x.GetEntitiesWithSelectorById(It.IsAny<Expression<Func<FollowerUserRelationDao, object[]>>>(),
                "followerUserID", userId.ToString(), 5)).ReturnsAsync(friends);
        _mockDatabaseActions.Setup(x => x.GetEntityByField<UserDao>("userID", friendId.ToString())).ReturnsAsync(friendUser);

        // Act
        var result = await _userService.GetFriends(userId);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Friends.Count, Is.EqualTo(1));
        Assert.That(result.Friends[0].Username, Is.EqualTo("friendUsername"));
    }
}
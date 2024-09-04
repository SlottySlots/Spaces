using Moq;
using SlottyMedia.Backend.Dtos;
using SlottyMedia.Backend.Exceptions.Services.UserExceptions;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Backend.ViewModel;
using SlottyMedia.Database.Daos;

namespace SlottyMedia.Tests.Viewmodel;

/// <summary>
/// Unit tests for the <see cref="ProfilePageVmImpl" /> class.
/// </summary>
[TestFixture]
public class ProfilePageVmImplTests
{
    /// <summary>
    ///     Sets up the test environment before each test.
    ///     Initializes the mocks and the view model instance.
    /// </summary>
    [SetUp]
    public void SetUp()
    {
        _userServiceMock = new Mock<IUserService>();
        _postServiceMock = new Mock<IPostService>();
        _viewModel = new ProfilePageVmImpl(_userServiceMock.Object, _postServiceMock.Object);
    }

    private Mock<IUserService> _userServiceMock;
    private Mock<IPostService> _postServiceMock;
    private ProfilePageVmImpl _viewModel;

    /// <summary>
    ///     Tests that GetUserInfo returns a UserInformationDto when the user exists.
    /// </summary>
    /// <returns>A task representing the asynchronous operation.</returns>
    [Test]
    public async Task GetUserInfo_ShouldReturnUserInformationDto_WhenUserExists()
    {
        var userId = Guid.NewGuid();
        var userInformationDto = new UserInformationDto()
        {
            UserId = userId, Username = "TestUser", Description = "TestDescription", 
            CreatedAt = DateTime.UtcNow, FriendsAmount = 5, SpacesAmount = 3
        };
        _userServiceMock.Setup(s => s.GetUserInfo(userId)).ReturnsAsync(userInformationDto);

        var result = await _viewModel.GetUserInfo(userId);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.UserId, Is.EqualTo(userId));
        Assert.That(result.Username, Is.EqualTo("TestUser"));
        Assert.That(result.Description, Is.EqualTo("TestDescription"));
        Assert.That(result.FriendsAmount, Is.EqualTo(5));
        Assert.That(result.SpacesAmount, Is.EqualTo(3));
    }

    /// <summary>
    ///     Tests that GetUserInfo returns null when the user does not exist.
    /// </summary>
    /// <returns>A task representing the asynchronous operation.</returns>
    [Test]
    public async Task GetUserInfo_ShouldReturnNull_WhenUserDoesNotExist()
    {
        var userId = Guid.NewGuid();
        _userServiceMock.Setup(s => s.GetUserDaoById(userId)).ThrowsAsync(new UserNotFoundException("User not found"));

        var result = await _viewModel.GetUserInfo(userId);

        Assert.That(result, Is.Null);
    }

    /// <summary>
    ///     Tests that UserFollowRelation returns true when a user follows another user.
    /// </summary>
    /// <returns>A task representing the asynchronous operation.</returns>
    [Test]
    public async Task UserFollowRelation_ShouldReturnTrue_WhenUserFollowsAnother()
    {
        var userIdToCheck = Guid.NewGuid();
        var userIdLoggedIn = Guid.NewGuid();
        _userServiceMock.Setup(s => s.UserFollowRelation(userIdToCheck, userIdLoggedIn)).ReturnsAsync(true);

        var result = await _viewModel.UserFollowRelation(userIdToCheck, userIdLoggedIn);

        Assert.That(result, Is.True);
    }

    /// <summary>
    ///     Tests that UserFollowRelation returns false when a user does not follow another user.
    /// </summary>
    /// <returns>A task representing the asynchronous operation.</returns>
    [Test]
    public async Task UserFollowRelation_ShouldReturnFalse_WhenUserDoesNotFollowAnother()
    {
        var userIdToCheck = Guid.NewGuid();
        var userIdLoggedIn = Guid.NewGuid();
        _userServiceMock.Setup(s => s.UserFollowRelation(userIdToCheck, userIdLoggedIn)).ReturnsAsync(false);

        var result = await _viewModel.UserFollowRelation(userIdToCheck, userIdLoggedIn);

        Assert.That(result, Is.False);
    }

    /// <summary>
    ///     Tests that UserFollowRelation returns null when the user IDs are the same.
    /// </summary>
    /// <returns>A task representing the asynchronous operation.</returns>
    [Test]
    public async Task UserFollowRelation_ShouldReturnNull_WhenUserIdsAreSame()
    {
        var userId = Guid.NewGuid();

        var result = await _viewModel.UserFollowRelation(userId, userId);

        Assert.That(result, Is.Null);
    }

    /// <summary>
    ///     Tests that FollowUserById calls FollowUserById on the user service.
    /// </summary>
    /// <returns>A task representing the asynchronous operation.</returns>
    [Test]
    public async Task FollowUserById_ShouldCallFollowUserByIdOnUserService()
    {
        var userIdFollows = Guid.NewGuid();
        var userIdToFollow = Guid.NewGuid();

        await _viewModel.FollowUserById(userIdFollows, userIdToFollow);

        _userServiceMock.Verify(s => s.FollowUserById(userIdFollows, userIdToFollow), Times.Once);
    }

    /// <summary>
    ///     Tests that UnfollowUserById calls UnfollowUserById on the user service.
    /// </summary>
    /// <returns>A task representing the asynchronous operation.</returns>
    [Test]
    public async Task UnfollowUserById_ShouldCallUnfollowUserByIdOnUserService()
    {
        var userIdFollows = Guid.NewGuid();
        var userIdToUnfollow = Guid.NewGuid();

        await _viewModel.UnfollowUserById(userIdFollows, userIdToUnfollow);

        _userServiceMock.Verify(s => s.UnfollowUserById(userIdFollows, userIdToUnfollow), Times.Once);
    }

    /// <summary>
    ///     Tests that GetPostsByUserId returns a list of PostDto.
    /// </summary>
    /// <returns>A task representing the asynchronous operation.</returns>
    [Test]
    public async Task GetPostsByUserId_ShouldReturnListOfPostDtos()
    {
        var userId = Guid.NewGuid();
        var posts = new List<PostDto> { new() { PostId = Guid.NewGuid(), Content = "TestContent" } };
        _postServiceMock.Setup(s => s.GetPostsByUserId(userId, 0, 10)).ReturnsAsync(posts);

        var result = await _viewModel.GetPostsByUserId(userId, 0, 10);

        Assert.That(result, Is.EqualTo(posts));
    }
}
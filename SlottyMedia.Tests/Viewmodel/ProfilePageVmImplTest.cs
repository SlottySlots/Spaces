using Moq;
using SlottyMedia.Backend.Dtos;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Backend.ViewModel;
using SlottyMedia.Database.Pagination;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SlottyMedia.Tests.Viewmodel;

/// <summary>
///     Unit tests for the <see cref="ProfilePageVmImpl" /> class.
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
    ///     Verifies that GetUserInfo returns user information for a valid user ID.
    /// </summary>
    [Test]
    public async Task GetUserInfo_ValidUserId_ReturnsUserInformation()
    {
        var userId = Guid.NewGuid();
        var userInfo = new UserInformationDto { Username = "Test User" };
        _userServiceMock.Setup(u => u.GetUserInfo(userId)).ReturnsAsync(userInfo);

        var result = await _viewModel.GetUserInfo(userId);

        Assert.That(result, Is.EqualTo(userInfo));
    }

    /// <summary>
    ///     Verifies that GetUserInfo returns null for an invalid user ID.
    /// </summary>
    [Test]
    public async Task GetUserInfo_InvalidUserId_ReturnsNull()
    {
        var userId = Guid.NewGuid();
        _userServiceMock.Setup(u => u.GetUserInfo(userId)).ReturnsAsync((UserInformationDto?)null);

        var result = await _viewModel.GetUserInfo(userId);

        Assert.That(result, Is.Null);
    }

    /// <summary>
    ///     Verifies that UserFollowRelation returns true for different user IDs.
    /// </summary>
    [Test]
    public async Task UserFollowRelation_DifferentUserIds_ReturnsFollowRelation()
    {
        var userIdToCheck = Guid.NewGuid();
        var userIdLoggedIn = Guid.NewGuid();
        _userServiceMock.Setup(u => u.UserFollowRelation(userIdToCheck, userIdLoggedIn)).ReturnsAsync(true);

        var result = await _viewModel.UserFollowRelation(userIdToCheck, userIdLoggedIn);

        Assert.That(result, Is.True);
    }

    /// <summary>
    ///     Verifies that UserFollowRelation returns null for the same user IDs.
    /// </summary>
    [Test]
    public async Task UserFollowRelation_SameUserIds_ReturnsNull()
    {
        var userId = Guid.NewGuid();

        var result = await _viewModel.UserFollowRelation(userId, userId);

        Assert.That(result, Is.Null);
    }

    /// <summary>
    ///     Verifies that FollowUserById calls the FollowUserById method of the user service with valid user IDs.
    /// </summary>
    [Test]
    public async Task FollowUserById_ValidUserIds_CallsFollowUserById()
    {
        var userIdFollows = Guid.NewGuid();
        var userIdToFollow = Guid.NewGuid();

        await _viewModel.FollowUserById(userIdFollows, userIdToFollow);

        _userServiceMock.Verify(u => u.FollowUserById(userIdFollows, userIdToFollow), Times.Once);
    }

    /// <summary>
    ///     Verifies that UnfollowUserById calls the UnfollowUserById method of the user service with valid user IDs.
    /// </summary>
    [Test]
    public async Task UnfollowUserById_ValidUserIds_CallsUnfollowUserById()
    {
        var userIdFollows = Guid.NewGuid();
        var userIdToUnfollow = Guid.NewGuid();

        await _viewModel.UnfollowUserById(userIdFollows, userIdToUnfollow);

        _userServiceMock.Verify(u => u.UnfollowUserById(userIdFollows, userIdToUnfollow), Times.Once);
    }

    /// <summary>
    ///     Verifies that GetPostsByUserId returns posts for a valid user ID.
    /// </summary>
    [Test]
    public async Task GetPostsByUserId_ValidUserId_ReturnsPosts()
    {
        var userId = Guid.NewGuid();
        var pageRequest = PageRequest.OfSize(10);
        var posts = new PageImpl<PostDto>(new List<PostDto> { new() { Content = "Test Post" } }, 1, 10, 1, null);
        _postServiceMock.Setup(p => p.GetPostsByUserId(userId, pageRequest)).ReturnsAsync(posts);

        var result = await _viewModel.GetPostsByUserId(userId, pageRequest);

        Assert.That(result, Is.EqualTo(posts.Content));
    }

    /// <summary>
    ///     Verifies that GetPostsByUserId returns an empty list for an invalid user ID.
    /// </summary>
    [Test]
    public async Task GetPostsByUserId_InvalidUserId_ReturnsEmptyList()
    {
        var userId = Guid.NewGuid();
        var pageRequest = PageRequest.OfSize(10);
        var posts = new PageImpl<PostDto>(new List<PostDto>(), 1, 10, 0, null);
        _postServiceMock.Setup(p => p.GetPostsByUserId(userId, pageRequest)).ReturnsAsync(posts);

        var result = await _viewModel.GetPostsByUserId(userId, pageRequest);

        Assert.That(result, Is.Empty);
    }
}
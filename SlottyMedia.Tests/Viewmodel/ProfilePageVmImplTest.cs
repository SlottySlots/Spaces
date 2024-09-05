using Moq;
using SlottyMedia.Backend.Dtos;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Backend.ViewModel;
using SlottyMedia.Database.Pagination;
using NUnit.Framework;
using SlottyMedia.Database.Daos;
using Supabase.Gotrue;

namespace SlottyMedia.Tests.Viewmodel
{
    /// <summary>
    ///     Unit tests for the <see cref="ProfilePageVmImpl" /> class.
    /// </summary>
    [TestFixture]
    public class ProfilePageVmImplTests
    {
        private Mock<IUserService> _userServiceMock;
        private Mock<IPostService> _postServiceMock;
        private Mock<IAuthService> _authServiceMock;
        private ProfilePageVmImpl _viewModel;

        /// <summary>
        ///     Sets up the test environment before each test.
        ///     Initializes the mocks and the view model instance.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            _userServiceMock = new Mock<IUserService>();
            _postServiceMock = new Mock<IPostService>();
            _authServiceMock = new Mock<IAuthService>();
            _viewModel = new ProfilePageVmImpl(_userServiceMock.Object, _postServiceMock.Object, _authServiceMock.Object);
        }

        /// <summary>
        ///     Tests that the Initialize method loads user information and posts correctly.
        /// </summary>
        [Test]
        public async Task Initialize_LoadsUserInfoAndPosts()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var authServiceMock = new Mock<IAuthService>();
            var postServiceMock = new Mock<IPostService>();
            var userServiceMock = new Mock<IUserService>();
            var viewModel = new ProfilePageVmImpl(userServiceMock.Object, postServiceMock.Object, authServiceMock.Object);

            authServiceMock.Setup(a => a.GetCurrentSession()).Returns(new Session { User = new User { Id = userId.ToString() } });
            userServiceMock.Setup(u => u.GetUserDaoById(It.IsAny<Guid>())).ReturnsAsync(new UserDao { UserId = userId, UserName = "testuser" });
            userServiceMock.Setup(u => u.GetCountOfUserFriends(It.IsAny<Guid>())).ReturnsAsync(5);
            userServiceMock.Setup(u => u.GetCountOfUserSpaces(It.IsAny<Guid>())).ReturnsAsync(3);
            postServiceMock.Setup(p => p.GetPostsByUserId(It.IsAny<Guid>(), It.IsAny<PageRequest>())).ReturnsAsync(PageImpl<PostDto>.Empty());

            // Act
            await viewModel.Initialize(userId);

            // Assert
            Assert.That(viewModel.IsLoadingPage, Is.False);
            Assert.That(viewModel.UserInfo, Is.Not.Null);
            Assert.That(viewModel.UserInfo.UserId, Is.EqualTo(userId));
            Assert.That(viewModel.UserInfo.Username, Is.EqualTo("testuser"));
            Assert.That(viewModel.UserInfo.FriendsAmount, Is.EqualTo(5));
            Assert.That(viewModel.UserInfo.SpacesAmount, Is.EqualTo(3));
            Assert.That(viewModel.Posts, Is.Not.Null);
        }

        /// <summary>
        ///     Tests that the LoadPosts method loads posts for the user correctly.
        /// </summary>
        [Test]
        public async Task LoadPosts_LoadsPostsForUser()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var postServiceMock = new Mock<IPostService>();
            var userServiceMock = new Mock<IUserService>();
            var authServiceMock = new Mock<IAuthService>();
            var viewModel = new ProfilePageVmImpl(userServiceMock.Object, postServiceMock.Object, authServiceMock.Object);

            userServiceMock.Setup(u => u.GetUserDaoById(It.IsAny<Guid>())).ReturnsAsync(new UserDao { UserId = userId, UserName = "testuser" });
            postServiceMock.Setup(p => p.GetPostsByUserId(It.IsAny<Guid>(), It.IsAny<PageRequest>())).ReturnsAsync(PageImpl<PostDto>.Empty());

            await viewModel.Initialize(userId);

            // Act
            await viewModel.LoadPosts(1);

            // Assert
            Assert.That(viewModel.IsLoadingPosts, Is.False);
            Assert.That(viewModel.Posts, Is.Not.Null);
        }

        /// <summary>
        ///     Tests that the FollowThisUser method follows the user correctly.
        /// </summary>
        [Test]
        public async Task FollowThisUser_FollowsUser()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var authServiceMock = new Mock<IAuthService>();
            var postServiceMock = new Mock<IPostService>();
            var userServiceMock = new Mock<IUserService>();
            var viewModel = new ProfilePageVmImpl(userServiceMock.Object, postServiceMock.Object, authServiceMock.Object);

            authServiceMock.Setup(a => a.GetCurrentSession()).Returns(new Session { User = new User { Id = userId.ToString() } });
            userServiceMock.Setup(u => u.FollowUserById(It.IsAny<Guid>(), It.IsAny<Guid>())).Returns(Task.CompletedTask);
            userServiceMock.Setup(u => u.GetUserDaoById(It.IsAny<Guid>())).ReturnsAsync(new UserDao { UserId = userId, UserName = "testuser" });
            postServiceMock.Setup(p => p.GetPostsByUserId(It.IsAny<Guid>(), It.IsAny<PageRequest>())).ReturnsAsync(PageImpl<PostDto>.Empty());

            await viewModel.Initialize(userId);

            // Act
            await viewModel.FollowThisUser();

            // Assert
            Assert.That(viewModel.IsUserFollowed, Is.True);
        }

        /// <summary>
        ///     Tests that the UnfollowThisUser method unfollows the user correctly.
        /// </summary>
        [Test]
        public async Task UnfollowThisUser_UnfollowsUser()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var authServiceMock = new Mock<IAuthService>();
            var postServiceMock = new Mock<IPostService>();
            var userServiceMock = new Mock<IUserService>();
            var viewModel = new ProfilePageVmImpl(userServiceMock.Object, postServiceMock.Object, authServiceMock.Object);

            authServiceMock.Setup(a => a.GetCurrentSession()).Returns(new Session { User = new User { Id = userId.ToString() } });
            userServiceMock.Setup(u => u.UnfollowUserById(It.IsAny<Guid>(), It.IsAny<Guid>())).Returns(Task.CompletedTask);
            userServiceMock.Setup(u => u.GetUserDaoById(It.IsAny<Guid>())).ReturnsAsync(new UserDao { UserId = userId, UserName = "testuser" });
            userServiceMock.Setup(u => u.FollowUserById(It.IsAny<Guid>(), It.IsAny<Guid>())).Returns(Task.CompletedTask);
            postServiceMock.Setup(p => p.GetPostsByUserId(It.IsAny<Guid>(), It.IsAny<PageRequest>())).ReturnsAsync(PageImpl<PostDto>.Empty());

            await viewModel.Initialize(userId);
            await viewModel.FollowThisUser();

            Assert.That(viewModel.IsUserFollowed, Is.True);
            
            // Act
            await viewModel.UnfollowThisUser();

            // Assert
            Assert.That(viewModel.IsUserFollowed, Is.False);
        }
    }
}
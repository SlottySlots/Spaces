using Moq;
using SlottyMedia.Backend.Dtos;
using SlottyMedia.Backend.Services;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Backend.ViewModel;
using SlottyMedia.Database;
using SlottyMedia.Database.Daos;
using SlottyMedia.Database.Repository.UserRepo;
using Supabase.Gotrue;
using Client = Supabase.Client;

namespace SlottyMedia.Tests.Viewmodel;

/// <summary>
///     Unit tests for the MainLayoutVmImpl class.
/// </summary>
[TestFixture]
public class MainLayoutVmImplTest
{
    /// <summary>
    ///     Sets up the necessary mocks and initializes the service before any tests are run.
    /// </summary>
    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        _client = InitializeSupabaseClient.GetSupabaseClient();
        _cookieServiceMock = new Mock<ICookieService>();
        _authService = new Mock<AuthService>(_client, _cookieServiceMock.Object);
        _mockUserRepository = new Mock<IUserRepository>();
        var postServide = new Mock<IPostService>();
        _userService = new Mock<IUserService>();
        _vm = new MainLayoutVmImpl(_authService.Object, _userService.Object);
    }

    /// <summary>
    ///     Resets the mocks after each test.
    /// </summary>
    [TearDown]
    public void TearDown()
    {
        _authService.Reset();
        _mockUserRepository.Reset();
        _cookieServiceMock.Reset();
    }

    private Client _client;
    private Mock<AuthService> _authService;
    private Mock<ICookieService> _cookieServiceMock;
    private Mock<IUserRepository> _mockUserRepository;
    private MainLayoutVmImpl _vm;
    private Mock<IUserService> _userService;

    /// <summary>
    ///     Tests that a session is restored on initialization.
    /// </summary>
    [Test]
    public void RestoreSessionOnInit_ReturnsSession()
    {
        _authService.Setup(service => service.RestoreSessionOnInit()).ReturnsAsync(new Session());
        Assert.That(_vm.RestoreSessionOnInit(), Is.Not.Null);
        _authService.VerifyAll();
        _authService.VerifyNoOtherCalls();
    }

    /// <summary>
    ///     Tests that no session is restored and returns null.
    /// </summary>
    [Test]
    public void RestoreSessionOnInit_NoSessionRestoredReturnsNull()
    {
        _authService.Setup(service => service.RestoreSessionOnInit()).ReturnsAsync((Session?)null);
        Assert.ThatAsync(async () => await _vm.RestoreSessionOnInit(), Is.Null);
        _authService.VerifyAll();
        _authService.VerifyNoOtherCalls();
    }

    /// <summary>
    ///     Tests that SetUserInfo returns null when no session is set.
    /// </summary>
    [Test]
    public void SetUserInfo_SessionNotSetReturnsNull()
    {
        _authService.Setup(service => service.GetCurrentSession()).Returns((Session?)null);
        Assert.ThatAsync(async () => await _vm.SetUserInfo(), Is.Null);
        _authService.VerifyAll();
        _authService.VerifyNoOtherCalls();
    }

    /// <summary>
    ///     Tests that SetUserInfo returns null when the user DAO is corrupt.
    /// </summary>
    [Test]
    public void SetUserInfo_CorruptUserDaoReturnsNull()
    {
        _authService.Setup(service => service.GetCurrentSession())
            .Returns(new Session { User = new User { Email = "test@test.de", Id = Guid.NewGuid().ToString() } });
        _userService.Setup(service => service.GetUserDaoById(It.IsAny<Guid>()))
            .ReturnsAsync(new UserDao());

        Assert.ThatAsync(async () => await _vm.SetUserInfo(), Is.Null);
        _authService.VerifyAll();
        _authService.VerifyNoOtherCalls();
    }

    /// <summary>
    ///     Tests that SetUserInfo returns a UserInfoDto when the user DAO is valid.
    /// </summary>
    [Test]
    public void SetUserInfo_ReturnsUserInfoDto()
    {
        _authService.Setup(service => service.GetCurrentSession())
            .Returns(new Session { User = new User { Email = "test@test.de", Id = Guid.NewGuid().ToString() } });
        var userDao = new UserDao
        {
            UserId = Guid.NewGuid(), UserName = "Test", Description = "TestDesc", Email = "test@test.de",
            ProfilePic = "123"
        };
        _userService.Setup(service => service.GetUserDaoById(It.IsAny<Guid>()))
            .ReturnsAsync(userDao);
        Assert.MultipleAsync(async () =>
            {
                var serviceCall = await _vm.SetUserInfo();
                Assert.That(serviceCall, Is.Not.Null);
                Assert.That(serviceCall!.UserId, Is.EqualTo(userDao.UserId));
                Assert.That(serviceCall!.Username, Is.EqualTo(userDao.UserName));
                Assert.That(serviceCall!.Description, Is.EqualTo(userDao.Description));
                Assert.That(serviceCall!.ProfilePic, Is.EqualTo(userDao.ProfilePic));
                Assert.That(serviceCall!.CreatedAt, Is.EqualTo(userDao.CreatedAt));
            }
        );
        _authService.VerifyAll();
        _authService.VerifyNoOtherCalls();
    }

    /// <summary>
    ///     Tests that PersistUserAvatarInDb returns null when no session is set.
    /// </summary>
    [Test]
    public void PersistUserAvatarInDb_ReturnsNullOnNoSession()
    {
        _authService.Setup(service => service.GetCurrentSession()).Returns((Session?)null);
        Assert.ThatAsync(async () => await _vm.PersistUserAvatarInDb("123"), Is.Null);
        _authService.VerifyAll();
    }

    /// <summary>
    ///     Tests that PersistUserAvatarInDb persists the user avatar in the database.
    /// </summary>
    [Test]
    public async Task PersistsUserAvatarInDb()
    {
        // Arrange
        var session = new Session { User = new User { Email = "test@test.de", Id = new Guid().ToString() } };
        _authService.Setup(service => service.GetCurrentSession()).Returns(session);
        var user = new UserDao { ProfilePic = "123" };
        _userService.Setup(service => service.UpdateUser(It.IsAny<UserDao>()));
        _userService.Setup(service => service.GetUserDaoById(It.IsAny<Guid>()))
            .ReturnsAsync(user);

        // Act
        var result = await _vm.PersistUserAvatarInDb("123");

        // Assert
        Assert.That(result, Is.EqualTo("123"));
        _authService.VerifyAll();
        _mockUserRepository.VerifyAll();
        _userService.Verify(service => service.UpdateUser(It.Is<UserDao>(u => u.ProfilePic == "123")), Times.Once);
    }
}
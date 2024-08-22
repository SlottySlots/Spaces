using Moq;
using SlottyMedia.Backend.Dtos;
using SlottyMedia.Backend.Services;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Backend.ViewModel;
using SlottyMedia.Database;
using SlottyMedia.Database.Daos;
using Supabase.Gotrue;
using Client = Supabase.Client;

namespace SlottyMedia.Tests.Viewmodel;

[TestFixture]
public class MainLayoutVmImplTest
{
    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        _client = InitializeSupabaseClient.GetSupabaseClient();
        _cookieServiceMock = new Mock<ICookieService>();
        _authService = new Mock<AuthService>(_client, _cookieServiceMock.Object);
        _dbActions = new Mock<DatabaseActions>(_client);
        var postServide = new Mock<IPostService>();
        _userService = new Mock<IUserService>();
        _vm = new MainLayoutVmImpl(_authService.Object, _dbActions.Object, _userService.Object);
    }

    [TearDown]
    public void TearDown()
    {
        _authService.Reset();
        _dbActions.Reset();
        _cookieServiceMock.Reset();
    }

    private Client _client;
    private Mock<AuthService> _authService;
    private Mock<ICookieService> _cookieServiceMock;
    private Mock<DatabaseActions> _dbActions;
    private MainLayoutVmImpl _vm;
    private Mock<IUserService> _userService;

    [Test]
    public void RestoreSessionOnInit_ReturnsSession()
    {
        _authService.Setup(service => service.RestoreSessionOnInit()).ReturnsAsync(new Session());
        Assert.That(_vm.RestoreSessionOnInit(), Is.Not.Null);
        _authService.VerifyAll();
        _authService.VerifyNoOtherCalls();
    }

    [Test]
    public void RestoreSessionOnInit_NoSessionRestoredReturnsNull()
    {
        _authService.Setup(service => service.RestoreSessionOnInit()).ReturnsAsync((Session?)null);
        Assert.ThatAsync(async () => await _vm.RestoreSessionOnInit(), Is.Null);
        _authService.VerifyAll();
        _authService.VerifyNoOtherCalls();
    }

    [Test]
    public void SetUserInfo_SessionNotSetReturnsNull()
    {
        _authService.Setup(service => service.GetCurrentSession()).Returns((Session?)null);
        Assert.ThatAsync(async () => await _vm.SetUserInfo(), Is.Null);
        _authService.VerifyAll();
        _authService.VerifyNoOtherCalls();
    }

    [Test]
    public void SetUserInfo_ReturnsUserInfoDto()
    {
        _authService.Setup(service => service.GetCurrentSession())
            .Returns(new Session { User = new User { Email = "test@test.de" } });
        var userDao = new UserDao
        {
            UserId = Guid.NewGuid(), UserName = "Test", Description = "TestDesc", Email = "test@test.de",
            ProfilePic = "123"
        };
        _dbActions.Setup(service => service.GetEntityByField<UserDao>("email", "test@test.de")).ReturnsAsync(userDao);
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

    [Test]
    public void PersistUserAvatarInDb_ReturnsNullOnNoSession()
    {
        _authService.Setup(service => service.GetCurrentSession()).Returns((Session?)null);
        Assert.ThatAsync(async () => await _vm.PersistUserAvatarInDb("123"), Is.Null);
        _authService.VerifyAll();
    }

    [Test]
    public async Task PersistsUserAvatarInDb()
    {
        // Arrange
        var session = new Session { User = new User { Email = "test@test.de", Id = new Guid().ToString() } };
        _authService.Setup(service => service.GetCurrentSession()).Returns(session);
        var user = new UserDao { ProfilePic = "123" };
        _userService.Setup(service => service.UpdateUser(It.IsAny<UserDao>())).ReturnsAsync(new UserDto().Mapper(user));
        _userService.Setup(service => service.GetUserBy(It.IsAny<Guid>(), It.IsAny<string>(), It.IsAny<string>()))
            .ReturnsAsync(user);

        // Act
        var result = await _vm.PersistUserAvatarInDb("123");

        // Assert
        Assert.That(result, Is.EqualTo("123"));
        _authService.VerifyAll();
        _dbActions.VerifyAll();
        _userService.Verify(service => service.UpdateUser(It.Is<UserDao>(u => u.ProfilePic == "123")), Times.Once);
    }
}
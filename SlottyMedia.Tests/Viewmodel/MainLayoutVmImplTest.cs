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
    private Client _client;
    private Mock<AuthService> _authService;
    private Mock<ICookieService> _cookieServiceMock;
    private Mock<DatabaseActions> _dbActions;
    private MainLayoutVmImpl _vm;

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        _client = InitializeSupabaseClient.GetSupabaseClient();
        _cookieServiceMock = new Mock<ICookieService>();
        _authService = new Mock<AuthService>(_client, _cookieServiceMock.Object);
        _dbActions = new Mock<DatabaseActions>(_client);
        _vm = new MainLayoutVmImpl(_authService.Object, _dbActions.Object);
    }

    [TearDown]
    public void TearDown()
    {
        _authService.Reset();
        _dbActions.Reset();
        _cookieServiceMock.Reset();
    }

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
    public void SetUserInfo_CorruptUserDaoReturnsNull()
    {
        _authService.Setup(service => service.GetCurrentSession()).Returns(new Session() { User = new User() {Email = "test@test.de"}});
        _dbActions.Setup(service => service.GetEntityByField<UserDao>("email", "test@test.de")).ReturnsAsync(new UserDao() { UserId= null, UserName= null, Description= null, Email= null });
        Assert.ThatAsync(async () => await _vm.SetUserInfo(), Is.Null);
        _authService.VerifyAll();
        _authService.VerifyNoOtherCalls();
    }
    
    [Test]
    public void SetUserInfo_ReturnsUserInfoDto()
    {
        _authService.Setup(service => service.GetCurrentSession()).Returns(new Session() { User = new User() {Email = "test@test.de"}});
        UserDao userDao = new UserDao()
            { UserId = Guid.NewGuid(), UserName = "Test", Description = "TestDesc", Email = "test@test.de", ProfilePic = "123"};
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
    public void PersistsUserAvatarInDb()
    {
        var session = new Session();
        session.User = new User();
        session.User.Email = "test@test.de";
        _authService.Setup(service => service.GetCurrentSession()).Returns(session);
        var user = new UserDao();
        _dbActions.Setup(actions => actions.GetEntityByField<UserDao>("email", session.User.Email))
            .ReturnsAsync(user);
        user.ProfilePic = "123";
        _dbActions.Setup(actions => actions.Update(user));

        Assert.ThatAsync(async () => await _vm.PersistUserAvatarInDb("123"), Is.EqualTo("123"));
        _authService.VerifyAll();
        _dbActions.VerifyAll();
    }
}
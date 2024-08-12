using Moq;
using SlottyMedia.Backend.Dtos;
using SlottyMedia.Backend.Exceptions.signup;
using SlottyMedia.Backend.Services;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Database;
using Supabase.Gotrue;
using Client = Supabase.Client;

namespace SlottyMedia.Tests.Auth;

/// <summary>
///     Tests the Service used for registering a new user in the database.
/// </summary>
[TestFixture]
public class SignUpServiceTest
{
    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        _client = InitializeSupabaseClient.GetSupabaseClient();
        _cookieServiceMock = new Mock<ICookieService>();
        _dbActionMock = new Mock<IDatabaseActions>();
        var postService = new Mock<IPostService>();
        _userServiceMock = new Mock<UserService>(_dbActionMock.Object, postService.Object);
        _signupService = new SignupServiceImpl(_client, _userServiceMock.Object, _cookieServiceMock.Object);
    }

    [SetUp]
    public void Setup()
    {
        var testUuid = Guid.NewGuid();

        _userName = testUuid.ToString();
        _email = testUuid + "@unittest.de";
        _password = "TestPassword1!";
    }

    [TearDown]
    public void TearDown()
    {
        _cookieServiceMock.Reset();
        _dbActionMock.Reset();
        _userServiceMock.Reset();
        _session = null;
    }

    private ISignupService _signupService;
    private Client _client;

    private Mock<UserService> _userServiceMock;
    private Mock<IDatabaseActions> _dbActionMock;
    private Mock<ICookieService> _cookieServiceMock;

    private string _userName;
    private string _email;
    private string _password;

    private Session? _session;

    [Test]
    public void SignUp_UserAlreadyExists()
    {
        _userServiceMock.Setup(userService => userService.GetUserByUsername(_userName)).ReturnsAsync(new UserDto());
        Assert.ThrowsAsync<UsernameAlreadyExistsException>(async () =>
            {
                await _signupService.SignUp(_userName, _email, _password);
            }
        );
    }

    [Test]
    public async Task SignUp()
    {
        _userServiceMock.Setup(userService => userService.GetUserByUsername(_userName)).ReturnsAsync((UserDto?)null);

        _cookieServiceMock.Setup(cookieService =>
            cookieService.SetCookie("supabase.auth.token", It.IsAny<string>(), 7)).Returns(new ValueTask());
        _cookieServiceMock.Setup(cookieService =>
            cookieService.SetCookie("supabase.auth.token", It.IsAny<string>(), 7)).Returns(new ValueTask());

        _session = await _signupService.SignUp(_userName, _email, _password);
        Assert.Multiple(() => { Assert.That(_session.User?.Email, Is.EqualTo(_email)); }
        );
        _cookieServiceMock.VerifyAll();
    }
}
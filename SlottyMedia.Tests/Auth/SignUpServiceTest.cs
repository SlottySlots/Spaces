using Moq;
using SlottyMedia.Backend.Exceptions.signup;
using SlottyMedia.Backend.Services;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Database;
using SlottyMedia.Database.Daos;
using Supabase.Gotrue;
using Client = Supabase.Client;

namespace SlottyMedia.Tests.Auth;

/// <summary>
///     Tests the Service used for registering a new user in the database.
/// </summary>
[TestFixture]
public class SignUpServiceTest
{
    /// <summary>
    ///     Sets up the test fixture. Initializes the Supabase client and mocks the necessary services.
    /// </summary>
    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        _client = InitializeSupabaseClient.GetSupabaseClient();
        _cookieServiceMock = new Mock<ICookieService>();
        _dbActionMock = new Mock<IDatabaseActions>();
        var postService = new Mock<IPostService>();
        _userServiceMock = new Mock<UserService>(_dbActionMock.Object, postService.Object);
        _signupService = new SignupServiceImpl(_client, _userServiceMock.Object, _cookieServiceMock.Object,
            _dbActionMock.Object);
    }

    /// <summary>
    ///     Sets up each test. Generates a new UUID for the username, email, and password.
    /// </summary>
    [SetUp]
    public void Setup()
    {
        var testUuid = Guid.NewGuid();

        _userName = testUuid.ToString();
        _email = testUuid + "@unittest.de";
        _password = "TestPassword1!";
    }

    /// <summary>
    ///     Tears down each test. Resets the mocks and clears the session.
    /// </summary>
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

    /// <summary>
    ///     Tests that SignUp throws a UsernameAlreadyExistsException when the username already exists.
    /// </summary>
    [Test]
    public void SignUp_UserAlreadyExists()
    {
        _userServiceMock.Setup(userService => userService.CheckIfUserExistsByUserName(_userName)).ReturnsAsync(true);
        Assert.ThrowsAsync<UsernameAlreadyExistsException>(async () =>
            {
                await _signupService.SignUp(_userName, _email, _password);
            }
        );
    }

    /// <summary>
    ///     Tests that SignUp successfully registers a new user and sets the session.
    /// </summary>
    [Test]
    public async Task SignUp()
    {
        _userServiceMock.Setup(userService => userService.CheckIfUserExistsByUserName(_userName)).ReturnsAsync(false);

        _cookieServiceMock.Setup(cookieService =>
            cookieService.SetCookie("supabase.auth.token", It.IsAny<string>(), 7)).Returns(new ValueTask());
        _cookieServiceMock.Setup(cookieService =>
            cookieService.SetCookie("supabase.auth.token", It.IsAny<string>(), 7)).Returns(new ValueTask());
        var roleDao = new RoleDao();
        roleDao.RoleId = Guid.NewGuid();
        roleDao.RoleName = "user";
        roleDao.Description = "user";

        var user = new UserDao(Guid.NewGuid(), roleDao.RoleId ?? Guid.Empty, _userName, _email, "TestPassword1!");

        _dbActionMock.Setup(dbAction => dbAction.GetEntityByField<RoleDao>("role", "User")).ReturnsAsync(roleDao);
        _dbActionMock.Setup(dbAction =>
            dbAction.Insert(It.Is<UserDao>(u => u.UserName == _userName && u.Email == _email))).ReturnsAsync(user);

        _session = await _signupService.SignUp(_userName, _email, _password);
        Assert.Multiple(() => { Assert.That(_session.User?.Email, Is.EqualTo(_email)); }
        );
        _cookieServiceMock.VerifyAll();
        _dbActionMock.VerifyAll();
    }
}
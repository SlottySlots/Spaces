using Moq;
using SlottyMedia.Backend.Exceptions.signup;
using SlottyMedia.Backend.Services;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Backend.ViewModel;
using SlottyMedia.Database;
using SlottyMedia.Database.Repository.RoleRepo;
using Client = Supabase.Client;

namespace SlottyMedia.Tests.Viewmodel.auth;

/// <summary>
///     This tests the viewmodel user in the Register.razor page
/// </summary>
[TestFixture]
public class SignUpFormVmImplTest
{
    /// <summary>
    ///     Sets up the necessary mocks and initializes the service before any tests are run.
    /// </summary>
    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        _client = InitializeSupabaseClient.GetSupabaseClient();
        _cookieServiceMock = new Mock<ICookieService>();
        _userServiceMock = new Mock<IUserService>();
        _roleRepositoryMock = new Mock<IRoleRepository>();
        _signUpServiceMock = new Mock<SignupServiceImpl>(_client, _userServiceMock.Object, _cookieServiceMock.Object,
            _roleRepositoryMock.Object);

        _service = new SignupFormVmImpl(_signUpServiceMock.Object);
    }

    /// <summary>
    ///     Resets the mocks after each test.
    /// </summary>
    [TearDown]
    public void TearDown()
    {
        _cookieServiceMock.Reset();
        _userServiceMock.Reset();
        _roleRepositoryMock.Reset();
        _signUpServiceMock.Reset();
    }

    private SignupFormVmImpl _service;
    private Client _client;
    private Mock<IUserService> _userServiceMock;
    private Mock<IRoleRepository> _roleRepositoryMock;
    private Mock<ICookieService> _cookieServiceMock;
    private Mock<SignupServiceImpl> _signUpServiceMock;

    /// <summary>
    ///     Tests that an ArgumentException is thrown when the username is not provided.
    /// </summary>
    [Test]
    public void SubmitSignUpForm_UsernameNotProvided()
    {
        _service.Username = null;
        _service.Email = "test";
        _service.Password = "test";

        Assert.ThrowsAsync<ArgumentException>(async () => { await _service.SubmitSignupForm(); });
    }

    /// <summary>
    ///     Tests that an ArgumentException is thrown when the email is not provided.
    /// </summary>
    [Test]
    public void SubmitSignUpForm_EmailNotProvided()
    {
        _service.Username = "test";
        _service.Email = null;
        _service.Password = "test";

        Assert.ThrowsAsync<ArgumentException>(async () => { await _service.SubmitSignupForm(); });
    }

    /// <summary>
    ///     Tests that an ArgumentException is thrown when the password is not provided.
    /// </summary>
    [Test]
    public void SubmitSignUpForm_PasswordNotProvided()
    {
        _service.Username = "test";
        _service.Email = "test";
        _service.Password = null;

        Assert.ThrowsAsync<ArgumentException>(async () => { await _service.SubmitSignupForm(); });
    }

    /// <summary>
    ///     Tests that a UsernameAlreadyExistsException is thrown when the username already exists.
    /// </summary>
    [Test]
    public void SubmitSignUpForm_UserNameAlreadyExists()
    {
        _service.Username = "test";
        _service.Email = "test";
        _service.Password = "test";
        _signUpServiceMock.Setup(service => service.SignUp(_service.Username, _service.Email, _service.Password))
            .ThrowsAsync(new UsernameAlreadyExistsException(_service.Username));

        Assert.ThrowsAsync<UsernameAlreadyExistsException>(async () => { await _service.SubmitSignupForm(); });
    }

    /// <summary>
    ///     Tests that an EmailAlreadyExistsException is thrown when the email already exists.
    /// </summary>
    [Test]
    public void SubmitSignUpForm_EmailAlreadyExists()
    {
        _service.Username = "test";
        _service.Email = "test";
        _service.Password = "test";
        _signUpServiceMock.Setup(service => service.SignUp(_service.Username, _service.Email, _service.Password))
            .ThrowsAsync(new EmailAlreadyExistsException(_service.Username));

        Assert.ThrowsAsync<EmailAlreadyExistsException>(async () => { await _service.SubmitSignupForm(); });
    }
}
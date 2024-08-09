using Moq;
using SlottyMedia.Backend.Exceptions;
using SlottyMedia.Backend.Exceptions.signup;
using SlottyMedia.Backend.Services;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Backend.ViewModel;
using SlottyMedia.Database;
using Supabase.Gotrue;
using Client = Supabase.Client;

namespace SlottyMedia.Tests.Viewmodel.auth;

/// <summary>
/// This tests the viewmodel user in the Register.razor page
/// </summary>
[TestFixture]
public class SignUpFormVmImplTest
{
    private SignupFormVmImpl _service;
    
    private Client _client;
    

    private Mock<UserService> _userServiceMock;
    private Mock<DatabaseActions> _dbActionsMock;
    private Mock<ICookieService> _cookieServiceMock;
    private Mock<SignupServiceImpl> _signUpServiceMock;
    
    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        _client = InitializeSupabaseClient.GetSupabaseClient();
        _cookieServiceMock = new Mock<ICookieService>();
        _dbActionsMock = new Mock<DatabaseActions>(_client);
        _userServiceMock = new Mock<UserService>(_dbActionsMock.Object);
        _signUpServiceMock = new Mock<SignupServiceImpl>(_client, _userServiceMock.Object, _cookieServiceMock.Object);
        
        _service = new SignupFormVmImpl(_signUpServiceMock.Object);
    }

    [TearDown]
    public void TearDown()
    {
        _cookieServiceMock.Reset();
        _userServiceMock.Reset();
        _dbActionsMock.Reset();
        _signUpServiceMock.Reset();
    }

    [Test]
    public void SubmitSignUpForm_UsernameNotProvided()
    {
        _service.Username = null;
        _service.Email = "test";
        _service.Password = "test";

        Assert.ThrowsAsync<ArgumentException>(async () =>
            {
                await _service.SubmitSignupForm();
            }
        );
    }
    
    [Test]
    public void SubmitSignUpForm_EmailNotProvided()
    {
        _service.Username = "test";
        _service.Email = null;
        _service.Password = "test";

        Assert.ThrowsAsync<ArgumentException>(async () =>
            {
                await _service.SubmitSignupForm();
            }
        );
    }
    
    [Test]
    public void SubmitSignUpForm_PasswordNotProvided()
    {
        _service.Username = "test";
        _service.Email = "test";
        _service.Password = null;

        Assert.ThrowsAsync<ArgumentException>(async () =>
            {
                await _service.SubmitSignupForm();
            }
        );
    }

    [Test]
    public void SubmitSignUpForm_UserNameAlreadyExists()
    {
        _service.Username = "test";
        _service.Email = "test";
        _service.Password = "test";
        _signUpServiceMock.Setup(service => service.SignUp(_service.Username, _service.Email, _service.Password))
            .ThrowsAsync(new UsernameAlreadyExistsException(_service.Username));
        
        Assert.ThrowsAsync<UsernameAlreadyExistsException>(async () =>
            {
                await _service.SubmitSignupForm();
            }
        );
    }
    
    [Test]
    public void SubmitSignUpForm_EmailAlreadyExists()
    {
        _service.Username = "test";
        _service.Email = "test";
        _service.Password = "test";
        _signUpServiceMock.Setup(service => service.SignUp(_service.Username, _service.Email, _service.Password))
            .ThrowsAsync(new EmailAlreadyExistsException(_service.Username));
        
        Assert.ThrowsAsync<EmailAlreadyExistsException>(async () =>
            {
                await _service.SubmitSignupForm();
            }
        );
    }
    
    
}
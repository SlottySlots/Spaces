using Moq;
using SlottyMedia.Backend.Services;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Backend.ViewModel;
using SlottyMedia.Database;
using Supabase;

namespace SlottyMedia.Tests.Viewmodel.auth;

public class SignInFormVmImplTest
{
    private Mock<AuthService> _authService;

    private Client _client;
    private Mock<ICookieService> _cookieServiceMock;
    private SignInFormVmImpl _service;

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        _client = InitializeSupabaseClient.GetSupabaseClient();
        _cookieServiceMock = new Mock<ICookieService>();
        _authService = new Mock<AuthService>(_client, _cookieServiceMock.Object);
        _service = new SignInFormVmImpl(_authService.Object);
    }

    [TearDown]
    public void TearDown()
    {
        _cookieServiceMock.Reset();
        _authService.Reset();
    }

    [Test]
    [TestCase("", "password")]
    [TestCase(null, "password")]
    public async Task SubmitSignInForm_WhenEmailEmpty_ShouldDisplayErrorMessage(string? email, string? password)
    {
        _service.Email = email;
        _service.Password = password;
        
        await _service.SubmitSignInForm();
        Assert.That(_service.EmailErrorMessage, Is.Not.Null);
        Assert.That(_service.EmailErrorMessage, Is.Not.Empty);
    }

    [Test]
    [TestCase("user@gmail.com", "")]
    [TestCase("user@gmail.com", null)]
    public async Task SubmitSignInForm_WhenPasswordEmpty_ShouldDisplayErrorMessage(string? email, string? password)
    {
        _service.Email = email;
        _service.Password = password;
        
        await _service.SubmitSignInForm();
        Assert.That(_service.PasswordErrorMessage, Is.Not.Null);
        Assert.That(_service.PasswordErrorMessage, Is.Not.Empty);
    }
    
}
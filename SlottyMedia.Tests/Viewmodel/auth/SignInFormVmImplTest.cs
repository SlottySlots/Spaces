using Moq;
using SlottyMedia.Backend.Services;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Backend.ViewModel;
using SlottyMedia.Database;
using Supabase;

namespace SlottyMedia.Tests.Viewmodel;

public class SignInFormVmImplTest
{
    private SignInFormVmImpl _service;
    
    private Client _client;
    
    private Mock<AuthService> _authService;
    private Mock<ICookieService> _cookieServiceMock;
    
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
    public void SubmitSignInForm_EmailNotProvided()
    {
        Assert.ThrowsAsync<ArgumentException>(async () => await _service.SubmitSignInForm());
    }
    
    [Test]
    public void SubmitSignInForm_PasswordNotProvided()
    {
        _service.Email = "test@test.de";
        Assert.ThrowsAsync<ArgumentException>(async () => await _service.SubmitSignInForm());
    }
}
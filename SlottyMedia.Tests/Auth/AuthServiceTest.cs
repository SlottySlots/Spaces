using Moq;
using SlottyMedia.Backend.Exceptions.auth;
using SlottyMedia.Backend.Services;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Database;
using Supabase.Gotrue;
using Client = Supabase.Client;

namespace SlottyMedia.Tests.Auth;


/// <summary>
/// Tests the non-supabase reliant business logic of AuthService.
/// </summary>
[TestFixture]
public class AuthServiceTest
{
    private IAuthService _authService;
    private Client _client;
    private Mock<ICookieService> _cookieServiceMock;

    private string _userName;
    private string _email;
    
    private Session? _session;
    
    
    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        _client = InitializeSupabaseClient.GetSupabaseClient();
        _cookieServiceMock = new Mock<ICookieService>();
        _authService = new AuthService(_client, _cookieServiceMock.Object);
    }

    [SetUp]
    public void Setup()
    {
        Guid testUuid = Guid.NewGuid();

        _userName = testUuid.ToString();
        _email = testUuid + "@unittest.de";
    }

    [TearDown]
    public void TearDown()
    {
        _cookieServiceMock.Reset();
        _session = null;
    }
    
    [Test]
    public void SaveSessionAsync_TokenNotProvided()
    {
        _session = new Session();
        Assert.ThrowsAsync<TokenNotProvidedException>(async () =>
            {
                await _authService.SaveSessionAsync(_session);
            }
        );
    }

    [Test]
    public void SaveSessionAsync()
    {
        _session = new Session();
        _session.AccessToken = "123";
        _session.RefreshToken = "456";
        _cookieServiceMock.Setup(
            service => service.SetCookie("supabase.auth.token", _session.AccessToken, It.IsAny<int>()
            )).Returns(new ValueTask());
        _cookieServiceMock.Setup(
            service => service.SetCookie("supabase.auth.refreshToken", _session.RefreshToken, It.IsAny<int>()
            )).Returns(new ValueTask());

        _authService.SaveSessionAsync(_session);
        _cookieServiceMock.VerifyAll();
    }

    [Test]
    public void RestoreSessionAsync_TokenNotProvided()
    {
        _cookieServiceMock.Setup(service => service.GetCookie("supabase.auth.token")).Returns(new ValueTask<string>(""));
        _cookieServiceMock.Setup(service => service.GetCookie("supabase.auth.refreshToken")).Returns(new ValueTask<string>(""));

        Assert.ThrowsAsync<TokenNotProvidedException>(async () =>
            {
                await _authService.RestoreSessionAsync();
            }
        );
        _cookieServiceMock.VerifyAll();
    }

    [Test]
    public void SignOut_CookiesNotRemoved()
    {
        _cookieServiceMock.Setup(service => service.RemoveCookie("supabase.auth.token"))
            .Returns(new ValueTask<string>());
        _cookieServiceMock.Setup(service => service.RemoveCookie("supabase.auth.refreshToken"))
            .Returns(new ValueTask<string>());
    }
    
}
using Moq;
using SlottyMedia.Backend.Exceptions.auth;
using SlottyMedia.Backend.Services;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Database;
using Supabase.Gotrue;
using Client = Supabase.Client;

namespace SlottyMedia.Tests.Auth;

/// <summary>
///     Tests the non-supabase reliant business logic of AuthService.
/// </summary>
[TestFixture]
public class AuthServiceTest
{
    /// <summary>
    ///     Sets up the test fixture. Initializes the Supabase client and mocks the cookie service.
    /// </summary>
    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        _client = InitializeSupabaseClient.GetSupabaseClient();
        _cookieServiceMock = new Mock<ICookieService>();
        _authService = new AuthService(_client, _cookieServiceMock.Object);
    }

    /// <summary>
    ///     Sets up each test. Generates a new UUID for the username and email.
    /// </summary>
    [SetUp]
    public void Setup()
    {
        var testUuid = Guid.NewGuid();

        _userName = testUuid.ToString();
        _email = testUuid + "@unittest.de";
    }

    /// <summary>
    ///     Tears down each test. Resets the cookie service mock and clears the session.
    /// </summary>
    [TearDown]
    public void TearDown()
    {
        _cookieServiceMock.Reset();
        _session = null;
    }

    private IAuthService _authService;
    private Client _client;
    private Mock<ICookieService> _cookieServiceMock;

    private Session? _session;

    /// <summary>
    ///     Tests that SaveSessionAsync throws a TokenNotProvidedException when the token is not provided.
    /// </summary>
    [Test]
    public void SaveSessionAsync_TokenNotProvided()
    {
        _session = new Session();
        Assert.ThrowsAsync<TokenNotProvidedException>(async () => { await _authService.SaveSessionAsync(_session); }
        );
    }

    /// <summary>
    ///     Tests that SaveSessionAsync saves the session and sets the cookies correctly.
    /// </summary>
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

    /// <summary>
    ///     Tests that RestoreSessionAsync throws a TokenNotProvidedException when the token is not provided.
    /// </summary>
    [Test]
    public void RestoreSessionAsync_TokenNotProvided()
    {
        _cookieServiceMock.Setup(service => service.GetCookie("supabase.auth.token"))
            .Returns(new ValueTask<string>(""));
        _cookieServiceMock.Setup(service => service.GetCookie("supabase.auth.refreshToken"))
            .Returns(new ValueTask<string>(""));

        Assert.ThrowsAsync<TokenNotProvidedException>(async () => { await _authService.RestoreSessionAsync(); }
        );
        _cookieServiceMock.VerifyAll();
    }

    /// <summary>
    ///     Tests that SignOut does not remove the cookies.
    /// </summary>
    [Test]
    public void SignOut_CookiesNotRemoved()
    {
        _cookieServiceMock.Setup(service => service.RemoveCookie("supabase.auth.token"))
            .Returns(new ValueTask<string>());
        _cookieServiceMock.Setup(service => service.RemoveCookie("supabase.auth.refreshToken"))
            .Returns(new ValueTask<string>());
    }
}
using Microsoft.AspNetCore.Components;
using Moq;
using SlottyMedia.Backend.Services;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Backend.ViewModel;
using SlottyMedia.Database;
using Supabase;

namespace SlottyMedia.Tests.Viewmodel.auth;

/// <summary>
///     Unit tests for the SignInFormVmImpl class.
/// </summary>
public class SignInFormVmImplTest
{
    private Mock<AuthService> _authService;
    private Client _client;
    private Mock<ICookieService> _cookieServiceMock;
    private Mock<NavigationManager> _navigationManager;
    private SignInFormVmImpl _service;

    /// <summary>
    ///     Sets up the test environment before any tests are run.
    /// </summary>
    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        _client = InitializeSupabaseClient.GetSupabaseClient();
        _cookieServiceMock = new Mock<ICookieService>();
        _authService = new Mock<AuthService>(_client, _cookieServiceMock.Object);
        _navigationManager = new Mock<NavigationManager>();
        _service = new SignInFormVmImpl(_authService.Object, _navigationManager.Object);
    }

    /// <summary>
    ///     Resets the mocks after each test.
    /// </summary>
    [TearDown]
    public void TearDown()
    {
        _cookieServiceMock.Reset();
        _authService.Reset();
    }

    /// <summary>
    ///     Tests that an error message is displayed when the email is empty or null.
    /// </summary>
    /// <param name="email">The email input.</param>
    /// <param name="password">The password input.</param>
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

    /// <summary>
    ///     Tests that an error message is displayed when the password is empty or null.
    /// </summary>
    /// <param name="email">The email input.</param>
    /// <param name="password">The password input.</param>
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
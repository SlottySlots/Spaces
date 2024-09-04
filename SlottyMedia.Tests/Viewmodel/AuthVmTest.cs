using Moq;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Backend.ViewModel;
using Supabase.Gotrue;

namespace SlottyMedia.Tests.Viewmodel;

/// <summary>
/// Unit tests for the AuthVm class.
/// </summary>
[TestFixture]
public class AuthVmTests
{
    private Mock<IAuthService> _mockAuthService;
    private AuthVm _authVm;

    /// <summary>
    /// Sets up the test environment by initializing mocks and the AuthVm instance.
    /// </summary>
    [SetUp]
    public void SetUp()
    {
        _mockAuthService = new Mock<IAuthService>();
        _authVm = new AuthVm(_mockAuthService.Object);
    }

    /// <summary>
    /// Tests that GetCurrentSession method returns the current session.
    /// </summary>
    [Test]
    public void GetCurrentSession_ReturnsCurrentSession()
    {
        var session = new Session { User = new User { Id = "user-id" } };
        _mockAuthService.Setup(s => s.GetCurrentSession()).Returns(session);

        var result = _authVm.GetCurrentSession();

        Assert.That(result, Is.EqualTo(session));
    }

    /// <summary>
    /// Tests that GetCurrentUserId method returns the user ID when a session exists.
    /// </summary>
    [Test]
    public void GetCurrentUserId_ReturnsUserIdWhenSessionExists()
    {
        var session = new Session { User = new User { Id = Guid.NewGuid().ToString() } };
        _mockAuthService.Setup(s => s.GetCurrentSession()).Returns(session);

        var result = _authVm.GetCurrentUserId();

        Assert.That(result, Is.EqualTo(Guid.Parse(session.User.Id)));
    }

    /// <summary>
    /// Tests that GetCurrentUserId method throws an exception when the session is null.
    /// </summary>
    [Test]
    public void GetCurrentUserId_ThrowsExceptionWhenSessionIsNull()
    {
        _mockAuthService.Setup(s => s.GetCurrentSession()).Returns((Session?)null);

        Assert.Throws<ArgumentNullException>(() => _authVm.GetCurrentUserId());
    }

    /// <summary>
    /// Tests that IsAuthenticated method returns true when the user is authenticated.
    /// </summary>
    [Test]
    public void IsAuthenticated_ReturnsTrueWhenAuthenticated()
    {
        _mockAuthService.Setup(s => s.IsAuthenticated()).Returns(true);

        var result = _authVm.IsAuthenticated();

        Assert.That(result, Is.True);
    }

    /// <summary>
    /// Tests that IsAuthenticated method returns false when the user is not authenticated.
    /// </summary>
    [Test]
    public void IsAuthenticated_ReturnsFalseWhenNotAuthenticated()
    {
        _mockAuthService.Setup(s => s.IsAuthenticated()).Returns(false);

        var result = _authVm.IsAuthenticated();

        Assert.That(result, Is.False);
    }
}
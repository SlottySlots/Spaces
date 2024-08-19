using Microsoft.IdentityModel.Tokens;
using SlottyMedia.Backend.Exceptions.auth;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Backend.ViewModel.Interfaces;
using SlottyMedia.LoggingProvider;

namespace SlottyMedia.Backend.ViewModel;

/// <summary>
///     Viewmodel used for the SignInForm of the Mainlayout
/// </summary>
public class SignInFormVmImpl : ISignInFormVm
{
    private static readonly Logging Logger = Logging.Instance;

    /// <summary>
    ///     AuthService used for supabase authentication
    /// </summary>
    private readonly IAuthService _authService;


    /// <summary>
    ///     Standard Constructor used for dependency injection
    /// </summary>
    /// <param name="authService">
    ///     AuthService about to being injected
    /// </param>
    public SignInFormVmImpl(IAuthService authService)
    {
        Logger.LogInfo("SignInFormVm initialized");
        _authService = authService;
    }

    /// <summary>
    ///     Corresponds to the email a user sets in the form. This is achieved via data-binding.
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    ///     Corresponds to the password a user sets in the form. This is achieved via data-binding.
    /// </summary>
    public string? Password { get; set; }

    /// <summary>
    ///     Field for setting a user exposing error message.
    /// </summary>
    public string? LoginErrorMessage { get; set; }


    /// <summary>
    ///     Function called on submition of the SignInForm
    /// </summary>
    /// <exception cref="ArgumentException">
    ///     Exception thrown on a missing email / password
    /// </exception>
    /// <exception cref="UserAlreadySignedInException">
    ///     Exception thrown on a already authenticated user
    /// </exception>
    public async Task SubmitSignInForm()
    {
        Logger.LogDebug("SubmitSignInForm called");
        LoginErrorMessage = "";

        if (Email.IsNullOrEmpty())
        {
            LoginErrorMessage = "Email must be set!";
            throw new ArgumentException("Email must be set!");
        }

        if (Password.IsNullOrEmpty())
        {
            LoginErrorMessage = "Password must be set!";
            throw new ArgumentException("Password must be set!");
        }

        if (!_authService.IsAuthenticated())
            try
            {
                await _authService.SignIn(Email!, Password!);
            }
            catch (Exception)
            {
                LoginErrorMessage = "Invalid credentials!";
            }
        else
            throw new UserAlreadySignedInException();
    }
}
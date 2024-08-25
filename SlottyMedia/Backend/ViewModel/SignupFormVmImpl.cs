using Microsoft.IdentityModel.Tokens;
using SlottyMedia.Backend.Exceptions.signup;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Backend.ViewModel.Interfaces;
using SlottyMedia.LoggingProvider;

namespace SlottyMedia.Backend.ViewModel;

/// <summary>
///     Viewmodel used to signing up a user.
/// </summary>
public class SignupFormVmImpl : ISignupFormVm
{
    private static readonly Logging<SignupFormVmImpl> Logger = new();

    /// <summary>
    ///     Service used for signing up a user
    /// </summary>
    private readonly ISignupService _signupService;

    private Logging<SignupFormVmImpl> logger = new();

    /// <summary>
    ///     Standard Constructor used for dependency injection
    /// </summary>
    /// <param name="signupService">
    ///     Sign Up service for dependency injection
    /// </param>
    public SignupFormVmImpl(ISignupService signupService)
    {
        Logger.LogInfo("SignupFormVm initialized");
        _signupService = signupService;
    }

    /// <summary>
    ///     UserName a user can set. This is achieved via data-binding.
    /// </summary>
    public string? Username { get; set; }

    /// <summary>
    ///     Error message exposed when a user isn't providing a username
    /// </summary>
    public string? UsernameErrorMessage { get; set; }

    /// <summary>
    ///     Email a user can set. This is achieved via data-binding.
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    ///     Error message exposed when a user isn't providing a email
    /// </summary>
    public string? EmailErrorMessage { get; set; }

    /// <summary>
    ///     Password a user can set. This is achieved via data-binding.
    /// </summary>
    public string? Password { get; set; }

    /// <summary>
    ///     Error message exposed when a user isn't providing a password
    /// </summary>
    public string? PasswordErrorMessage { get; set; }

    /// <summary>
    ///     Generic error message shown when server throws an unknown exception
    /// </summary>
    public string? ServerErrorMessage { get; set; }

    /// <summary>
    ///     Function called when user submits a form
    /// </summary>
    /// <exception cref="ArgumentException">
    ///     Thrown when user isn't providing all information needed for a signup
    /// </exception>
    public async Task SubmitSignupForm()
    {
        Logger.LogDebug("SubmitSignupForm called");
        // reset all existing errors first
        _resetErrors();

        // handle errors when fields were empty
        if (Username.IsNullOrEmpty())
        {
            UsernameErrorMessage = "Username is required";
            throw new ArgumentException("Username is required but was null or empty");
        }

        if (Email.IsNullOrEmpty())
        {
            EmailErrorMessage = "Email is required";
            throw new ArgumentException("Email is required but was null or empty");
        }

        if (Password.IsNullOrEmpty())
        {
            PasswordErrorMessage = "Password is required";
            throw new ArgumentException("Password is required but was null or empty");
        }

        // if all fields were provided, try signing up
        try
        {
            Logger.LogDebug("Calling signup service");
            await _signupService.SignUp(Username!, Email!, Password!);
        }
        catch (UsernameAlreadyExistsException)
        {
            UsernameErrorMessage = "Username already taken";
            throw;
        }
        catch (EmailAlreadyExistsException)
        {
            EmailErrorMessage = "Email already in use";
            throw;
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "An exception occurred while signing up");
            ServerErrorMessage = "An unknown error has occured. Please try again later.";
            throw;
        }
    }

    /// <summary>
    ///     Resets all previous set errors.
    /// </summary>
    private void _resetErrors()
    {
        UsernameErrorMessage = null;
        EmailErrorMessage = null;
        PasswordErrorMessage = null;
        ServerErrorMessage = null;
    }
}
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Components;
using Microsoft.IdentityModel.Tokens;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Backend.ViewModel.Interfaces;
using SlottyMedia.LoggingProvider;
using Supabase.Gotrue.Exceptions;

namespace SlottyMedia.Backend.ViewModel;

/// <summary>
///     Viewmodel used for the SignInForm of the Mainlayout
/// </summary>
public class SignInFormVmImpl : ISignInFormVm
{
    private static readonly Logging<SignInFormVmImpl> Logger = new();

    /// <summary>
    ///     AuthService used for supabase authentication
    /// </summary>
    private readonly IAuthService _authService;

    private readonly NavigationManager _navigationManager;


    /// <summary>
    ///     Standard Constructor used for dependency injection
    /// </summary>
    /// <param name="authService">
    ///     AuthService about to being injected
    /// </param>
    public SignInFormVmImpl(IAuthService authService, NavigationManager navigationManager)
    {
        Logger.LogInfo("SignInFormVm initialized");
        _authService = authService;
        _navigationManager = navigationManager;
    }

    public string? Email { get; set; }

    public string? EmailErrorMessage { get; set; }

    public string? Password { get; set; }

    public string? PasswordErrorMessage { get; set; }

    public string? ServerErrorMessage { get; set; }

    public async Task SubmitSignInForm()
    {
        Logger.LogDebug("SubmitSignInForm called");

        // reset all error messages when (re-)submitting the form
        _resetErrorMessages();

        // display error message when fields were empty
        if (Email.IsNullOrEmpty())
        {
            EmailErrorMessage = "Email is required";
            return;
        }

        if (Password.IsNullOrEmpty())
        {
            PasswordErrorMessage = "Password is required";
            return;
        }

        // attempt signin
        try
        {
            // sign out if user was already signed in
            await _authService.SignOut();
            // perform signin
            await _authService.SignIn(Email!, Password!);

            // TODO display error message when password was invalid! This is urgent!
        }
        catch (GotrueException ex)
        {
            var message = ex.Message;
            var regex = new Regex("\"error_description\"\\s*:\\s*\"([^\"]*)\"");
            var errorDescription = regex.Match(message);
            if (errorDescription.Success && errorDescription.Groups[1].Value == "Invalid login credentials")
                ServerErrorMessage = "Provided credentials were invalid!";
            else
                ServerErrorMessage = "An unknown error occurred. Try again later.";
            return;
        }
        catch
        {
            ServerErrorMessage = "An unknown error occurred. Try again later.";
            return;
        }

        // if no errors occurred and user was signed in successfully: redirect to home page
        _navigationManager.NavigateTo("/");
    }

    private void _resetErrorMessages()
    {
        EmailErrorMessage = null;
        ServerErrorMessage = null;
    }
}
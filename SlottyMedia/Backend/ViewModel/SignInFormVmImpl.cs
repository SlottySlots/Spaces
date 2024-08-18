using Microsoft.IdentityModel.Tokens;
using SlottyMedia.Backend.Exceptions.auth;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Backend.ViewModel.Interfaces;

namespace SlottyMedia.Backend.ViewModel;

/// <summary>
///     Viewmodel used for the SignInForm of the Mainlayout
/// </summary>
public class SignInFormVmImpl : ISignInFormVm
{
    private readonly IAuthService _authService;

    public SignInFormVmImpl(IAuthService authService)
    {
        _authService = authService;
    }

    public string? Email { get; set; }
    
    public string? EmailErrorMessage { get; set; }

    public string? Password { get; set; }
    
    public string? PasswordErrorMessage { get; set; }

    public string? ServerErrorMessage { get; set; }
    
    public async Task SubmitSignInForm()
    {
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
        catch
        {
            ServerErrorMessage = "An unknown error occurred. Try again later.";
            throw;
        }
    }

    private void _resetErrorMessages()
    {
        EmailErrorMessage = null;
        ServerErrorMessage = null;
    }
}
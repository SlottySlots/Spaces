using Microsoft.IdentityModel.Tokens;
using SlottyMedia.Backend.Exceptions.auth;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Backend.ViewModel.Interfaces;

namespace SlottyMedia.Backend.ViewModel;

public class SignInFormVmImpl : ISignInFormVm
{
    private IAuthService _authService;
    
    public string? Email { get; set; }
    public string? Password { get; set; }
    
    public string? LoginErrorMessage { get; set; }

    public SignInFormVmImpl(IAuthService authService)
    {
        _authService = authService;
    }
    
    public async Task SubmitSignInForm()
    {
        LoginErrorMessage = "";
        
        if (Email.IsNullOrEmpty())
        {
            throw new ArgumentException("Email must be set!");
        }

        if (Password.IsNullOrEmpty())
        {
            throw new ArgumentException("Password must be set!");
        }
        
        if (!_authService.IsAuthenticated())
        {
            try
            {
                await _authService.SignIn(Email!, Password!);
            }
            catch (Exception)
            {
                LoginErrorMessage = "Invalid credentials!";
            }
        }
        else
        {
            throw new UserAlreadySignedInException();
        }
    }
}
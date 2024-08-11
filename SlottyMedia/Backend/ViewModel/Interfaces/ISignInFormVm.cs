namespace SlottyMedia.Backend.ViewModel.Interfaces;

public interface ISignInFormVm
{
    /// <summary>
    /// Email to authenticate a user
    /// </summary>
    string? Email { get; set; }
    /// <summary>
    /// Password to authenticate a user
    /// </summary>
    string? Password { get; set; }
    
    /// <summary>
    /// Error message displayed in login field
    /// </summary>
    string? LoginErrorMessage { get; set; }
    
    /// <summary>
    /// Used to sign in a user by email and password
    /// </summary>
    /// <returns></returns>
    Task SubmitSignInForm();
}
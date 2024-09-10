namespace SlottyMedia.Backend.ViewModel.Partial.SignIn;

/// <summary>
///     Interface used for dependency injection on the SignInFormVm
/// </summary>
public interface ISignInFormVm
{
    /// <summary>The form's email address</summary>
    string? Email { get; set; }

    /// <summary>An optional error message that is caused by the email address</summary>
    string? EmailErrorMessage { get; set; }

    /// <summary>The form's password</summary>
    string? Password { get; set; }

    /// <summary>An optional error message that is caused by the password</summary>
    string? PasswordErrorMessage { get; set; }

    /// <summary>An optional error message that is caused by some internal server error</summary>
    string? ServerErrorMessage { get; set; }

    /// <summary>
    ///     Attempts to submit the form. If this is successful, then the user was signed in
    ///     successfully and cookies have been set. Otherwise, displays an appropriate error
    ///     message.
    /// </summary>
    Task SubmitSignInForm();
}
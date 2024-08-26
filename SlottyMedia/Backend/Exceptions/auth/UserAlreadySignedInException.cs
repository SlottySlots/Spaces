using SlottyMedia.LoggingProvider;

namespace SlottyMedia.Backend.Exceptions.auth;

/// <summary>
///     Exception for the case that a user is already signed in
/// </summary>
public class UserAlreadySignedInException : BaseException<UserAlreadySignedInException>
{
    /// <summary>
    ///     Constructor to create generic exception message
    /// </summary>
    public UserAlreadySignedInException() : base("User already signed in!")
    {
    }
}
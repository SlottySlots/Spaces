using SlottyMedia.LoggingProvider;

namespace SlottyMedia.Backend.Exceptions.Services.UserExceptions;

/// <summary>
///     This exception is thrown when a general exception occurs. For example when interacting with the database there
///     is the option, that Exceptions which aren't predictable can occur. In this case, this exception is thrown.
/// </summary>
public class UserGeneralException : BaseException<UserGeneralException>
{
    /// <summary>
    ///     This constructor creates a new UserGeneralException object.
    /// </summary>
    /// <param name="message"></param>
    public UserGeneralException(string message) : base(message)
    {
    }

    /// <summary>
    ///     This constructor creates a new UserGeneralException object.
    /// </summary>
    /// <param name="message"></param>
    /// <param name="innerException"></param>
    public UserGeneralException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
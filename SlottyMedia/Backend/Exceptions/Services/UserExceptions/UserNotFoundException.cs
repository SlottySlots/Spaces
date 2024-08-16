using SlottyMedia.LoggingProvider;

namespace SlottyMedia.Backend.Exceptions.Services.UserExceptions;

/// <summary>
///     This exception is thrown when a user is not found.
/// </summary>
public class UserNotFoundException : BaseException
{
    /// <summary>
    ///     This constructor creates a new UserNotFoundException object.
    /// </summary>
    /// <param name="message"></param>
    public UserNotFoundException(string message) : base(message)
    {
    }

    /// <summary>
    ///     This constructor creates a new UserNotFoundException object.
    /// </summary>
    /// <param name="message"></param>
    /// <param name="innerException"></param>
    public UserNotFoundException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
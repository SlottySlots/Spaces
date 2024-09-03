using SlottyMedia.Backend.Exceptions.Services.LikeExceptions;
using SlottyMedia.LoggingProvider;

namespace SlottyMedia.Backend.Exceptions.Services.ForumExceptions;

/// <summary>
///     This exception is thrown when a user is not found.
/// </summary>
public class ForumNotFoundException : BaseException<LikeNotFoundException>
{
    /// <summary>
    ///     This constructor creates a new ForumNotFoundException object.
    /// </summary>
    /// <param name="message"></param>
    public ForumNotFoundException(string message) : base(message)
    {
    }

    /// <summary>
    ///     This constructor creates a new ForumNotFoundException object.
    /// </summary>
    /// <param name="message"></param>
    /// <param name="innerException"></param>
    public ForumNotFoundException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
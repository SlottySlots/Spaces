using SlottyMedia.LoggingProvider;

namespace SlottyMedia.Backend.Exceptions.Services.LikeExceptions;

/// <summary>
///     This exception is thrown when a user is not found.
/// </summary>
public class LikeNotFoundException : BaseException<LikeNotFoundException>
{
    /// <summary>
    ///     This constructor creates a new LikeNotFoundException object.
    /// </summary>
    /// <param name="message"></param>
    public LikeNotFoundException(string message) : base(message)
    {
    }

    /// <summary>
    ///     This constructor creates a new LikeNotFoundException object.
    /// </summary>
    /// <param name="message"></param>
    /// <param name="innerException"></param>
    public LikeNotFoundException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
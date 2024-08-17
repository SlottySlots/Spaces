using SlottyMedia.LoggingProvider;

namespace SlottyMedia.Backend.Exceptions.Services.PostExceptions;

/// <summary>
///     Represents an exception that occurs during Insert, Update, or Delete operations in the Forum service.
/// </summary>
public class LikeIudException : BaseException<LikeIudException>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="ForumIudException" /> class with a specified error message.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public LikeIudException(string message) : base(message)
    {
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ForumIudException" /> class with a specified error message and a
    ///     reference to the inner exception that is the cause of this exception.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="innerException">The exception that is the cause of the current exception.</param>
    public LikeIudException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
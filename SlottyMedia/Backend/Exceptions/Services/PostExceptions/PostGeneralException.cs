using SlottyMedia.LoggingProvider;

namespace SlottyMedia.Backend.Exceptions.Services.PostExceptions;

/// <summary>
///     Represents a general exception that occurs in the Post service.
/// </summary>
public class PostGeneralException : BaseException<PostGeneralException>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="PostGeneralException" /> class with a specified error message.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public PostGeneralException(string message) : base(message)
    {
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="PostGeneralException" /> class with a specified error message and a
    ///     reference to the inner exception that is the cause of this exception.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="innerException">The exception that is the cause of the current exception.</param>
    public PostGeneralException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
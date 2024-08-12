namespace SlottyMedia.Backend.Exceptions.Services.SearchExceptions;

/// <summary>
///     Represents a general exception that occurs in the Search service.
/// </summary>
public class SearchGeneralExceptions : BaseException
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="SearchGeneralExceptions" /> class with a specified error message.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public SearchGeneralExceptions(string message) : base(message)
    {
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="SearchGeneralExceptions" /> class with a specified error message and a
    ///     reference to the inner exception that is the cause of this exception.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="innerException">The exception that is the cause of the current exception.</param>
    public SearchGeneralExceptions(string message, Exception innerException) : base(message, innerException)
    {
    }
}
using SlottyMedia.LoggingProvider;

namespace SlottyMedia.Database.Exceptions;

/// <summary>
///     This exception is thrown when the Pagination fails. 
/// </summary>
public class DatabasePaginationFailedException : BaseException<DatabasePaginationFailedException>
{
    /// <summary>
    ///     The default constructor.
    /// </summary>
    public DatabasePaginationFailedException()
    {
    }


    /// <summary>
    ///     The constructor with parameters.
    /// </summary>
    /// <param name="message"></param>
    public DatabasePaginationFailedException(string message) : base(message)
    {
    }

    /// <summary>
    ///     The constructor with parameters.
    /// </summary>
    /// <param name="propertyName"></param>
    /// <param name="message"></param>
    public DatabasePaginationFailedException(string propertyName, string message) : base($"{propertyName}: {message}")
    {
    }

    /// <summary>
    ///     The constructor with parameters.
    /// </summary>
    /// <param name="message"></param>
    /// <param name="innerException"></param>
    public DatabasePaginationFailedException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
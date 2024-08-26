using SlottyMedia.LoggingProvider;

namespace SlottyMedia.Database.Exceptions;

/// <summary>
///     /// This exception is thrown when an item is missing from the database.
/// </summary>
public class DatabaseMissingItemException : BaseException<DatabaseMissingItemException>
{
    /// <summary>
    ///     The default constructor.
    /// </summary>
    public DatabaseMissingItemException()
    {
    }

    /// <summary>
    ///     The constructor with parameters.
    /// </summary>
    /// <param name="message"></param>
    public DatabaseMissingItemException(string message) : base(message)
    {
    }

    /// <summary>
    ///     The constructor with parameters.
    /// </summary>
    /// <param name="propertyName"></param>
    /// <param name="message"></param>
    public DatabaseMissingItemException(string propertyName, string message) : base($"{propertyName}: {message}")
    {
    }

    /// <summary>
    ///     THe constructor with parameters.
    /// </summary>
    /// <param name="message"></param>
    /// <param name="innerException"></param>
    public DatabaseMissingItemException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
namespace SlottyMedia.Database.Exceptions;

/// <summary>
///     This exception is thrown when a general database exception occurs.
/// </summary>
public class GeneralDatabaseException : BaseDatabaseException
{
    /// <summary>
    ///     The default constructor.
    /// </summary>
    public GeneralDatabaseException()
    {
    }

    /// <summary>
    ///     The constructor with parameters.
    /// </summary>
    /// <param name="message"></param>
    public GeneralDatabaseException(string message) : base(message)
    {
    }

    /// <summary>
    ///     The constructor with parameters.
    /// </summary>
    /// <param name="propertyName"></param>
    /// <param name="message"></param>
    public GeneralDatabaseException(string propertyName, string message) : base($"{propertyName}: {message}")
    {
    }

    /// <summary>
    ///     The constructor with parameters.
    /// </summary>
    /// <param name="message"></param>
    /// <param name="innerException"></param>
    public GeneralDatabaseException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
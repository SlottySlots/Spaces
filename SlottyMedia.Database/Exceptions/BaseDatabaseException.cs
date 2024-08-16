using NLog;

namespace SlottyMedia.Database.Exceptions;

/// <summary>
///     This class represents the BaseDatabaseException.
/// </summary>
public class BaseDatabaseException : Exception
{
    private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

    /// <summary>
    ///     The default constructor.
    /// </summary>
    public BaseDatabaseException()
    {
        Logger.Error("An exception occurred.");
    }

    /// <summary>
    ///     The constructor with parameters.
    /// </summary>
    /// <param name="message"></param>
    public BaseDatabaseException(string message) : base(message)
    {
        Logger.Error(message);
    }

    /// <summary>
    ///     The constructor with parameters.
    /// </summary>
    /// <param name="propertyName"></param>
    /// <param name="message"></param>
    public BaseDatabaseException(string propertyName, string message) : base(message)
    {
        Logger.Error($"{propertyName}: {message}");
    }

    /// <summary>
    ///     The constructor with parameters.
    /// </summary>
    /// <param name="message"></param>
    /// <param name="innerException"></param>
    public BaseDatabaseException(string message, Exception innerException) : base(message, innerException)
    {
        Logger.Error(innerException, message);
    }
}
namespace SlottyMedia.LoggingProvider;

/// <summary>
///     This exception is the base exception for all exceptions in the application.
/// </summary>
public class BaseException<T> : Exception
{
    private static readonly Logging<T> Logger = new ();
    
    /// <summary>
    ///     The default constructor.
    /// </summary>
    public BaseException()
    {
        Logger.LogError("An exception occurred.");
    }

    /// <summary>
    ///     The constructor with parameters.
    /// </summary>
    /// <param name="message"></param>
    public BaseException(string message) : base(message)
    {
        Logger.LogError(message);
    }

    /// <summary>
    ///     The constructor with parameters.
    /// </summary>
    /// <param name="propertyName"></param>
    /// <param name="message"></param>
    public BaseException(string propertyName, string message) : base(message)
    {
        Logger.LogError($"{propertyName}: {message}");
    }

    /// <summary>
    ///     The constructor with parameters.
    /// </summary>
    /// <param name="message"></param>
    /// <param name="innerException"></param>
    public BaseException(string message, Exception innerException) : base(message, innerException)
    {
        Logger.LogError(innerException, message);
    }
}
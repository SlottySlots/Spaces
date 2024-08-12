using NLog;

namespace SlottyMedia.Backend.Exceptions;

/// <summary>
///     This class represents the Base Exception. It is used as a base class for all exceptions.
/// </summary>
public class BaseException : Exception
{
    private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

    /// <summary>
    ///     Standard constructor.
    /// </summary>
    public BaseException()
    {
        Logger.Error("An exception occurred.");
    }

    /// <summary>
    ///     Constructor with a message.
    /// </summary>
    /// <param name="message">The exception message</param>
    public BaseException(string message) : base(message)
    {
        Logger.Error(message);
    }

    /// <summary>
    ///     Constructor with a message and inner exception.
    /// </summary>
    /// <param name="message">The exception message</param>
    /// <param name="innerException">The inner exception</param>
    public BaseException(string message, Exception innerException) : base(message, innerException)
    {
        Logger.Error(innerException, message);
    }
}
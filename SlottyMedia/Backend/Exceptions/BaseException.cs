namespace SlottyMedia.Backend.Exceptions;

/// <summary>
/// This class represents the Base Exception. It is used as a base class for all exceptions.
/// </summary>
public class BaseException : Exception
{
    /// <summary>
    /// Standard constructor.
    /// </summary>
    public BaseException()
    {
        // TODO Implement Logging
    }

    /// <summary>
    /// Constructor with a message.
    /// </summary>
    /// <param name="message">The exception message</param>
    public BaseException(string message) : base(message)
    {
        Console.WriteLine(message);
        // TODO Implement Logging
    }

    /// <summary>
    /// Constructor with a message and inner exception.
    /// </summary>
    /// <param name="message">The exception message</param>
    /// <param name="innerException">The inner exception</param>
    public BaseException(string message, Exception innerException) : base(message, innerException)
    {
        Console.WriteLine(message);
        // TODO Implement Logging
    }
}
using System;

namespace SlottyMedia.LoggingProvider;

public class BaseException : Exception
{
    private static readonly Logging Logger = Logging.Instance;

    public BaseException()
    {
        Logger.LogError("An exception occurred.");
    }

    public BaseException(string message) : base(message)
    {
        Logger.LogError(message);
    }

    public BaseException(string propertyName, string message) : base(message)
    {
        Logger.LogError($"{propertyName}: {message}");
    }

    public BaseException(string message, Exception innerException) : base(message, innerException)
    {
        Logger.LogError(innerException, message);
    }
}
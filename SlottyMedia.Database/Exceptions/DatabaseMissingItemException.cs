using SlottyMedia.LoggingProvider;

namespace SlottyMedia.Database.Exceptions;

public class DatabaseMissingItemException : BaseException
{
    public DatabaseMissingItemException()
    {
    }

    public DatabaseMissingItemException(string message) : base(message)
    {
    }

    public DatabaseMissingItemException(string propertyName, string message) : base($"{propertyName}: {message}")
    {
    }

    public DatabaseMissingItemException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
using NLog;

namespace SlottyMedia.Database.Exceptions;

public class BaseDatabaseException : Exception
{
    private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

    public BaseDatabaseException()
    {
        Logger.Error("An exception occurred.");
    }

    public BaseDatabaseException(string message) : base(message)
    {
        Logger.Error(message);
    }

    public BaseDatabaseException(string propertyName, string message) : base(message)
    {
        Logger.Error($"{propertyName}: {message}");
    }

    public BaseDatabaseException(string message, Exception innerException) : base(message, innerException)
    {
        Logger.Error(innerException, message);
    }
}
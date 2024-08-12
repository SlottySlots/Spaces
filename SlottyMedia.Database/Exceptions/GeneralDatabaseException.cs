namespace SlottyMedia.Database.Exceptions;

public class GeneralDatabaseException : BaseDatabaseException
{
    public GeneralDatabaseException() : base()
    {
    }
    
    public GeneralDatabaseException(string message) : base(message)
    {
    }

    public GeneralDatabaseException(string propertyName, string message) : base($"{propertyName}: {message}")
    {
    }

    public GeneralDatabaseException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
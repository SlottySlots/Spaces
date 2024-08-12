namespace SlottyMedia.Database.Exceptions;

/// <summary>
///     This exception is thrown when an IUD action fails. I stands for Insert, U for Update and D for Delete.
/// </summary>
public class DatabaseIudActionException :  BaseDatabaseException
{
    public DatabaseIudActionException() : base()
    {
    }
    
    public DatabaseIudActionException(string message) : base(message)
    {
    }

    public DatabaseIudActionException(string propertyName, string message) : base($"{propertyName}: {message}")
    {
    }

    public DatabaseIudActionException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
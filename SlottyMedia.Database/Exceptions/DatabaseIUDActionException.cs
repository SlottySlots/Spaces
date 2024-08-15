namespace SlottyMedia.Database.Exceptions;

/// <summary>
///     This exception is thrown when an IUD action fails. I stands for Insert, U for Update and D for Delete.
/// </summary>
public class DatabaseIudActionException :  BaseDatabaseException
{
    /// <summary>
    /// The default constructor.
    /// </summary>
    public DatabaseIudActionException() : base()
    {
    }
    
    /// <summary>
    /// The constructor with parameters.
    /// </summary>
    /// <param name="message"></param>
    public DatabaseIudActionException(string message) : base(message)
    {
    }

    /// <summary>
    /// The constructor with parameters.
    /// </summary>
    /// <param name="propertyName"></param>
    /// <param name="message"></param>
    public DatabaseIudActionException(string propertyName, string message) : base($"{propertyName}: {message}")
    {
    }

    /// <summary>
    /// The constructor with parameters.
    /// </summary>
    /// <param name="message"></param>
    /// <param name="innerException"></param>
    public DatabaseIudActionException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
namespace SlottyMedia.Database.Exceptions;

/// <summary>
///     This exception is thrown when an IUD action fails. I stands for Insert, U for Update and D for Delete.
/// </summary>
public class DatabaseIudActionException : Exception
{
    public DatabaseIudActionException()
    {
    }

    public DatabaseIudActionException(string message) : base(message)
    {
        Console.WriteLine(message);
        // TODO Implement Logging
    }

    public DatabaseIudActionException(string propertyName, string message) : base($"{propertyName}: {message}")
    {
        Console.WriteLine($"{propertyName}: {message}");
        // TODO Implement Logging
    }

    public DatabaseIudActionException(string message, Exception innerException) : base(message, innerException)
    {
        Console.WriteLine(message);
        // TODO Implement Logging
    }
}
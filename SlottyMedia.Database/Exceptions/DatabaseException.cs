namespace SlottyMedia.Database.Exceptions;

public class DatabaseException : Exception
{
    public DatabaseException()
    {
    }

    public DatabaseException(string message) : base(message)
    {
        Console.WriteLine(message);
        // TODO Implement Logging
    }

    public DatabaseException(string propertyName, string message) : base($"{propertyName}: {message}")
    {
        Console.WriteLine($"{propertyName}: {message}");
        // TODO Implement Logging
    }

    public DatabaseException(string message, Exception innerException) : base(message, innerException)
    {
        Console.WriteLine(message);
        // TODO Implement Logging
    }
}
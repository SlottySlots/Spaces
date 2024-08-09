namespace SlottyMedia.Database.Exceptions;

public class DatabaseMissingItemException : Exception
{
    public DatabaseMissingItemException()
    {
    }

    public DatabaseMissingItemException(string message) : base(message)
    {
        Console.WriteLine(message);
        // TODO Implement Logging
    }

    public DatabaseMissingItemException(string propertyName, string message) : base($"{propertyName}: {message}")
    {
        Console.WriteLine($"{propertyName}: {message}");
        // TODO Implement Logging
    }

    public DatabaseMissingItemException(string message, Exception innerException) : base(message, innerException)
    {
        Console.WriteLine(message);
        // TODO Implement Logging
    }
}
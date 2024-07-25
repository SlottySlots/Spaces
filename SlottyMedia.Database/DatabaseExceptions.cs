namespace SlottyMedia.Database;

public class DatabaseExceptions : Exception
{
    public DatabaseExceptions()
    {
    }
    
    public DatabaseExceptions(string message) : base(message)
    {
        Console.WriteLine(message);
        // TODO Implement Logging
    }
    
    public DatabaseExceptions(string propertyName, string message) : base($"{propertyName}: {message}")
    {
        Console.WriteLine($"{propertyName}: {message}");
        // TODO Implement Logging
    }
    
    public DatabaseExceptions(string message, Exception innerException) : base(message, innerException)
    {
        Console.WriteLine(message);
        // TODO Implement Logging
    }
}
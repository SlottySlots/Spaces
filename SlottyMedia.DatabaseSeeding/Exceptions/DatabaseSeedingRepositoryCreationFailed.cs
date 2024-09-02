using SlottyMedia.LoggingProvider;

namespace SlottyMedia.DatabaseSeeding.Exceptions;

/// <summary>
///     This exception is thrown when an IUD action fails. I stands for Insert, U for Update and D for Delete.
/// </summary>
public class DatabaseSeedingRepositoryCreationFailed : BaseException<DatabaseSeedingRepositoryCreationFailed>
{
    /// <summary>
    ///     The default constructor.
    /// </summary>
    public DatabaseSeedingRepositoryCreationFailed()
    {
    }


    /// <summary>
    ///     The constructor with parameters.
    /// </summary>
    /// <param name="message"></param>
    public DatabaseSeedingRepositoryCreationFailed(string message) : base(message)
    {
    }

    /// <summary>
    ///     The constructor with parameters.
    /// </summary>
    /// <param name="propertyName"></param>
    /// <param name="message"></param>
    public DatabaseSeedingRepositoryCreationFailed(string propertyName, string message) : base(
        $"{propertyName}: {message}")
    {
    }

    /// <summary>
    ///     The constructor with parameters.
    /// </summary>
    /// <param name="message"></param>
    /// <param name="innerException"></param>
    public DatabaseSeedingRepositoryCreationFailed(string message, Exception innerException) : base(message,
        innerException)
    {
    }
}
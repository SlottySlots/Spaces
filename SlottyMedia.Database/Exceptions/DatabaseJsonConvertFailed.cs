using SlottyMedia.LoggingProvider;

namespace SlottyMedia.Database.Exceptions;

/// <summary>
///     This exception is thrown when an IUD action fails. I stands for Insert, U for Update and D for Delete.
/// </summary>
public class DatabaseJsonConvertFailed : BaseException<DatabaseJsonConvertFailed>
{
    /// <summary>
    ///     The default constructor.
    /// </summary>
    public DatabaseJsonConvertFailed()
    {
    }


    /// <summary>
    ///     The constructor with parameters.
    /// </summary>
    /// <param name="message"></param>
    public DatabaseJsonConvertFailed(string message) : base(message)
    {
    }

    /// <summary>
    ///     The constructor with parameters.
    /// </summary>
    /// <param name="propertyName"></param>
    /// <param name="message"></param>
    public DatabaseJsonConvertFailed(string propertyName, string message) : base($"{propertyName}: {message}")
    {
    }

    /// <summary>
    ///     The constructor with parameters.
    /// </summary>
    /// <param name="message"></param>
    /// <param name="innerException"></param>
    public DatabaseJsonConvertFailed(string message, Exception innerException) : base(message, innerException)
    {
    }
}
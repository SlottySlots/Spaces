using SlottyMedia.LoggingProvider;

namespace SlottyMedia.Database.Exceptions;

/// <summary>
///     This exception is thrown when a table has no primary key.
/// </summary>
public class TableHasNoPrimaryKeyException : BaseException<TableHasNoPrimaryKeyException>
{
    /// <summary>
    ///     The default constructor.
    /// </summary>
    public TableHasNoPrimaryKeyException()
    {
    }

    /// <summary>
    ///     The constructor with parameters.
    /// </summary>
    /// <param name="message"></param>
    public TableHasNoPrimaryKeyException(string message) : base(message)
    {
    }

    /// <summary>
    ///     The constructor with parameters.
    /// </summary>
    /// <param name="message"></param>
    /// <param name="innerException"></param>
    public TableHasNoPrimaryKeyException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
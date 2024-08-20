using NLog;

namespace SlottyMedia.LoggingProvider;

/// <summary>
///     Logging class to handle application logging using NLog.
/// </summary>
public class Logging<T>
{
    /// <summary>
    ///     The logger instance.
    /// </summary>
    private readonly ILogger logger;

    /// <summary>
    ///     Constructor for the Logging class.
    /// </summary>
    /// <param name="type"></param>
    public Logging()
    {
        var config = NlogConfiguration.CreateNlogConfig();
        LogManager.Setup().LoadConfiguration(config);
        if (typeof(T).Namespace != null)
            logger = LogManager.GetLogger(typeof(T).Namespace);
        else
            logger = LogManager.GetLogger(typeof(T).FullName);
    }

    /// <summary>
    ///     Logs a trace message.
    /// </summary>
    /// <param name="message">The message to log.</param>
    public void LogTrace(string message)
    {
        logger.Trace(message);
    }

    /// <summary>
    ///     Logs a debug message.
    /// </summary>
    /// <param name="message">The message to log.</param>
    public void LogDebug(string message)
    {
        logger.Debug(message);
    }

    /// <summary>
    ///     Logs an info message.
    /// </summary>
    /// <param name="message">The message to log.</param>
    public void LogInfo(string message)
    {
        logger.Info(message);
    }

    /// <summary>
    ///     Logs a warning message.
    /// </summary>
    /// <param name="message">The message to log.</param>
    public void LogWarn(string message)
    {
        logger.Warn(message);
    }

    /// <summary>
    ///     Logs an error message.
    /// </summary>
    /// <param name="message">The message to log.</param>
    public void LogError(string message)
    {
        logger.Error(message);
    }

    /// <summary>
    ///     Logs a fatal message.
    /// </summary>
    /// <param name="message">The message to log.</param>
    public void LogFatal(string message)
    {
        logger.Fatal(message);
    }

    /// <summary>
    ///     Logs a trace message with an exception.
    /// </summary>
    /// <param name="ex">The exception to log.</param>
    /// <param name="message">The message to log.</param>
    public void LogTrace(Exception ex, string message)
    {
        logger.Trace(ex, message);
    }

    /// <summary>
    ///     Logs a debug message with an exception.
    /// </summary>
    /// <param name="ex">The exception to log.</param>
    /// <param name="message">The message to log.</param>
    public void LogDebug(Exception ex, string message)
    {
        logger.Debug(ex, message);
    }

    /// <summary>
    ///     Logs an info message with an exception.
    /// </summary>
    /// <param name="ex">The exception to log.</param>
    /// <param name="message">The message to log.</param>
    public void LogInfo(Exception ex, string message)
    {
        logger.Info(ex, message);
    }

    /// <summary>
    ///     Logs a warning message with an exception.
    /// </summary>
    /// <param name="ex">The exception to log.</param>
    /// <param name="message">The message to log.</param>
    public void LogWarn(Exception ex, string message)
    {
        logger.Warn(ex, message);
    }

    /// <summary>
    ///     Logs an error message with an exception.
    /// </summary>
    /// <param name="ex">The exception to log.</param>
    /// <param name="message">The message to log.</param>
    public void LogError(Exception ex, string message)
    {
        logger.Error(ex, message);
    }

    /// <summary>
    ///     Logs a fatal message with an exception.
    /// </summary>
    /// <param name="ex">The exception to log.</param>
    /// <param name="message">The message to log.</param>
    public void LogFatal(Exception ex, string message)
    {
        logger.Fatal(ex, message);
    }
}
using NLog;
using NLog.Conditions;
using NLog.Config;
using NLog.Filters;
using NLog.Targets;
using NLog.Targets.Wrappers;

namespace SlottyMedia.LoggingProvider;

/// <summary>
///     The configuration for NLog.
/// </summary>
public static class NlogConfiguration
{
    /// <summary>
    ///     This method creates a new NLog configuration.
    /// </summary>
    /// <remarks>
    ///     The `CreateNlogConfig` method generates an NLog configuration for logging:
    ///     1. **Initialize Configuration**: Creates a `LoggingConfiguration` object.
    ///     2. **Define Log File Target**: Creates a `FileTarget` named "logfile" with daily archiving and a specific layout.
    ///     3. **Define Console Target**: Creates a `ColoredConsoleTarget` named "console" with ANSI output and custom
    ///     highlighting rules.
    ///     4. **Add Console Row Highlighting Rules**: Adds custom highlighting rules for different log levels to the console
    ///     target.
    ///     5. **Wrap Targets in Async Wrappers**: Wraps the file and console targets in `AsyncTargetWrapper` for asynchronous
    ///     logging.
    ///     6. **Add Targets to Configuration**: Adds the async file and console targets to the logging configuration.
    ///     7. **Define Logging Rules**: Adds rules to log messages to the file and console targets, with a filter for
    ///     Microsoft logs.
    ///     8. **Return Configuration**: Returns the configured `LoggingConfiguration` object.
    /// </remarks>
    public static LoggingConfiguration CreateNlogConfig()
    {
        var config = new LoggingConfiguration();

        var logFilePath = "logs/logfile-${shortdate}.txt";

        var logfile = new FileTarget("logfile")
        {
            FileName = logFilePath,
            ArchiveEvery = FileArchivePeriod.Day,
            ArchiveNumbering = ArchiveNumberingMode.Date,
            MaxArchiveFiles = 30,
            ArchiveFileName = "logs/archives/logfile-{#}.txt",
            Layout = @"${date:format=HH\\:mm\\:ss} [${level}] ${logger} ${message}"
        };
        var logconsole = new ColoredConsoleTarget("console")
        {
            Layout = @"${date:format=HH\:mm\:ss} [${level}] ${logger} ${message} 
                        ${exception: format=Tostring, Data:maxInnerExceptionLevel=10}",
            UseDefaultRowHighlightingRules = false,
            EnableAnsiOutput = true
        };

        AddConsoleRowHighlightingRules(ref logconsole);

        var asyncLogfile = new AsyncTargetWrapper(logfile);
        var asyncLogconsole = new AsyncTargetWrapper(logconsole);

        config.AddTarget(asyncLogfile);
        config.AddTarget(asyncLogconsole);

        config.AddRule(LogLevel.Trace, LogLevel.Fatal, asyncLogfile);

        var consoleRule = new LoggingRule("*", LogLevel.Debug, LogLevel.Fatal, asyncLogconsole);

        // Filter out Microsoft logs with level less than or equal to Warn
        consoleRule.Filters.Add(new WhenMethodFilter(logEvent =>
            logEvent.LoggerName.StartsWith("Microsoft.") && logEvent.Level <= LogLevel.Warn
                ? FilterResult.Ignore
                : FilterResult.Log));
        config.AddRule(consoleRule);

        return config;
    }

    /// <summary>
    ///     This method adds console row highlighting rules.
    /// </summary>
    /// <param name="logconsole"></param>
    private static void AddConsoleRowHighlightingRules(ref ColoredConsoleTarget logconsole)
    {
        var debugHighlightRule = new ConsoleRowHighlightingRule
        {
            Condition = ConditionParser.ParseExpression("level == LogLevel.Debug"),
            ForegroundColor = ConsoleOutputColor.Cyan,
            BackgroundColor = ConsoleOutputColor.NoChange
        };
        logconsole.RowHighlightingRules.Add(debugHighlightRule);

        var infoHighlightRule = new ConsoleRowHighlightingRule
        {
            Condition = ConditionParser.ParseExpression("level == LogLevel.Info"),
            ForegroundColor = ConsoleOutputColor.White,
            BackgroundColor = ConsoleOutputColor.NoChange
        };
        logconsole.RowHighlightingRules.Add(infoHighlightRule);

        var warnHighlightRule = new ConsoleRowHighlightingRule
        {
            Condition = ConditionParser.ParseExpression("level == LogLevel.Warn"),
            ForegroundColor = ConsoleOutputColor.Yellow,
            BackgroundColor = ConsoleOutputColor.NoChange
        };
        logconsole.RowHighlightingRules.Add(warnHighlightRule);

        var errorHighlightRule = new ConsoleRowHighlightingRule
        {
            Condition = ConditionParser.ParseExpression("level == LogLevel.Error"),
            ForegroundColor = ConsoleOutputColor.Red,
            BackgroundColor = ConsoleOutputColor.NoChange
        };
        logconsole.RowHighlightingRules.Add(errorHighlightRule);

        var fatalHighlightRule = new ConsoleRowHighlightingRule
        {
            Condition = ConditionParser.ParseExpression("level == LogLevel.Fatal"),
            ForegroundColor = ConsoleOutputColor.Magenta,
            BackgroundColor = ConsoleOutputColor.NoChange
        };
        logconsole.RowHighlightingRules.Add(fatalHighlightRule);
    }
}
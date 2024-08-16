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
            Layout = @"${date:format=HH\:mm\:ss} [${level}] ${logger} ${message}",
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
        consoleRule.Filters.Add(new WhenMethodFilter(logEvent =>
            logEvent.LoggerName.StartsWith("Microsoft.") && logEvent.Level <= LogLevel.Warn
                ? FilterResult.Ignore
                : FilterResult.Log));
        config.AddRule(consoleRule);

        return config;
    }

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
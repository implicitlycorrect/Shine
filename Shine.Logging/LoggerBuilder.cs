namespace Shine.Logging;

public class LoggerBuilder
{
    private readonly List<ILogger> _loggers;

    public LoggerBuilder()
    {
        _loggers = new List<ILogger>(2);
    }

    public LoggerBuilder ToFile(string filePath = "shine_log.txt")
    {
        _loggers.Add(new FileLogger(filePath));
        return this;
    }

    public LoggerBuilder ToConsole()
    {
        _loggers.Add(ConsoleLogger.Instance);
        return this;
    }

    public ILogger Build()
    {
        return new Logger(_loggers);
    }
}

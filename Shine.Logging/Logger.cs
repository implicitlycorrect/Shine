namespace Shine.Logging;

internal sealed class Logger : ILogger
{
    private readonly IEnumerable<ILogger> _loggers;
    internal Logger(IEnumerable<ILogger> loggers)
    {
        _loggers = loggers;
    }

    public void Log(LogMessage message)
    {
        _loggers.AsParallel().ForAll(logger => logger.Log(message));
    }

    public async Task LogAsync(LogMessage message)
    {
        foreach (ILogger logger in _loggers) 
        { 
            await logger.LogAsync(message);
        }
    }
}

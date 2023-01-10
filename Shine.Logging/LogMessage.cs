using System.Diagnostics;

namespace Shine.Logging;

public sealed class LogMessage
{
    public LogMessage(LogLevel level, string message)
    {
        Level = level;
        Message = message;
    }

    public LogLevel Level { get; }

    public string Message { get; }

    public override string ToString()
    {
        string? levelAsText = Level switch
        {
            LogLevel.Information => "INF",
            LogLevel.Warning => "WRN",
            LogLevel.Debug => "DBG",
            LogLevel.Error => "ERR",
            _ => throw new UnreachableException()
        };

        string utcTimestamp = DateTime.UtcNow.ToString("t").Replace(" ", string.Empty);
        return $"[{levelAsText}] ({utcTimestamp}): {Message}";
    }
}

using System.Runtime.CompilerServices;

namespace Shine.Logging;

public interface ILogger
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Task LogAsync(LogLevel level, string message)
    {
        return LogAsync(new LogMessage(level, message));
    }

    public Task LogAsync(LogMessage message);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Log(LogLevel level, string message)
    {
        Log(new LogMessage(level, message));
    }

    public void Log(LogMessage message);
}
using System.Diagnostics;

namespace Shine.Logging;

internal sealed class ConsoleLogger : ILogger
{
    internal static readonly ConsoleLogger Instance = new();

    public void Log(LogMessage message)
    {
        lock (Console.Out)
        {
            ConsoleColor foregroundColor = message.Level switch
            {
                LogLevel.Information => ConsoleColor.White,
                LogLevel.Warning => ConsoleColor.Yellow,
                LogLevel.Error => ConsoleColor.Red,
                LogLevel.Debug => ConsoleColor.DarkGray,
                _ => throw new UnreachableException()
            };

            Console.ForegroundColor = foregroundColor;
            Console.WriteLine(message.ToString());
            Console.ResetColor();
        }
    }

    public Task LogAsync(LogMessage message)
    {
        Log(message);
        return Task.CompletedTask;
    }
}

using Shine.Core;
using Shine.Logging;

Console.Title = "[ Shine.CLI ]";

ILogger logger = new LoggerBuilder()
    .ToConsole()
    .ToFile()
    .Build();

await logger.LogAsync(LogLevel.Information, "Hello World!");

ShineEngine engine = new ShineEngine(logger);
await engine.RunAsync();
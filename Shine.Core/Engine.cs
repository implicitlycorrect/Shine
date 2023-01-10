using CliWrap;
using Shine.Logging;

namespace Shine.Core;

public partial class ShineEngine
{
    private readonly ILogger _logger;
    private readonly Configuration _configuration;

    public ShineEngine(ILogger logger, Configuration? configuration = null)
    {
        _logger = logger;
        _configuration = configuration ?? Configuration.Load();
    }

    public async Task RunAsync()
    {
        await _logger.LogAsync(LogLevel.Information, $"Detected {_configuration.Jobs.Length} jobs");
        foreach (Job job in _configuration.Jobs)
        {
            await _logger.LogAsync(LogLevel.Information, $"Executing job {job.Name}");
            foreach (string command in job.Commands)
            {
                try
                {
                    await ExecuteCommand(command);
                }
                catch (Exception ex)
                {
                    await _logger.LogAsync(LogLevel.Error, ex.ToString());
                }
            }
            await _logger.LogAsync(LogLevel.Information, $"Done");
        }
    }
}

public partial class ShineEngine
{
    private static async Task ExecuteCommand(string command)
    {
        string[] splits = command.Split(' ');

        string target = splits[0];
        string[] arguments = splits[1..];

        await Cli.Wrap(target)
            .WithStandardOutputPipe(PipeTarget.ToDelegate(Console.WriteLine))
            .WithArguments(arguments)
            .ExecuteAsync();
    }
}
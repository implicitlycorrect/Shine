namespace Shine.Core;

public sealed class Job
{
    public Job(string name, string[] commands)
    {
        Name = name;
        Commands = commands;
    }

    public string Name { get; }
    public string[] Commands { get; }
}
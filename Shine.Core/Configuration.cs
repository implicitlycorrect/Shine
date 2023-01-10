using System.Text.Json;

namespace Shine.Core;

public partial class Configuration
{
    /// <summary>
    /// An array of jobs
    /// </summary>
    public Job[] Jobs { get; set; } = Array.Empty<Job>();
}

public partial class Configuration
{
    /// <summary>
    /// Options for JsonSerializer
    /// </summary>
    private static readonly JsonSerializerOptions SerializerOptions = new JsonSerializerOptions()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    /// <summary>
    /// Default configuration
    /// </summary>
    public static readonly Configuration Default = new();

    /// <summary>
    /// Loads the configuration from file
    /// </summary>
    /// <returns>Loaded configuration or default</returns>
    /// <exception cref="JsonException">Thrown if deserialization fails</exception>
    public static Configuration Load()
    {
        if (!File.Exists("shine_config.json"))
        {
            Default.Write();
            return Default;
        }

        string? fileTextContents = File.ReadAllText("shine_config.json");
        Configuration? deserializedConfig = JsonSerializer.Deserialize<Configuration>(fileTextContents, SerializerOptions);
        return deserializedConfig ?? throw new JsonException($"Failed to deserialize Shine configuration from shine_config.json");
    }

    /// <summary>
    /// Writes the configuration to file
    /// </summary>
    public void Write()
    {
        string? serializedConfig = JsonSerializer.Serialize(this, SerializerOptions);
        File.WriteAllText("shine_config.json", serializedConfig);
    }
}
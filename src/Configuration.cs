// u251206_code
// u251206_documentation

using System.IO;

namespace TingenNyqvist;

public class Configuration
{
    public string TingenUserName { get; set; }

    /// <summary>Loads the Tingen NYQVIST configuration settings from the local configuration file.</summary>
    /// <remarks>
    ///     To keep things simple, the configuration is stored in a JSON file located at "./AppData/Config/nyqvist.config".<br/>
    ///     <br/>
    ///     If the configuration file does not exist, a new configuration with default values is created.
    /// </remarks>
    /// <returns>The Tingen NYQVIST configuration settings.</returns>
    internal static Configuration Load()
    {
        const string configPath = "./AppData/Config/nyqvist.config";

        if (!File.Exists(configPath))
        {
            Configuration defaultConfig = CreateDefault();
            Save(defaultConfig, configPath);
        }

        return Du.DuJson.ImportFromLocalFile<Configuration>(configPath);
    }

    /// <summary>
    /// Saves the Tingen NYQVIST configuration settings to the local configuration file.
    /// </summary>
    /// <param name="configSettings">The configuration settings.</param>
    /// <param name="configPath">The configuration file path.</param>
    private static void Save(Configuration configSettings, string configPath)
    {
        Du.DuJson.ExportToLocalFile<Configuration>(configSettings, configPath);
    }

    /// <summary>Creates a default Tingen NYQVIST configuration.</summary>
    /// <returns>The default Tingen NYQVIST configuration.</returns>
    private static Configuration CreateDefault() => new()
    {
        TingenUserName = ""
    };
}
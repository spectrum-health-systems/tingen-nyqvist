// u251206_code
// u251206_documentation

using System.IO;
using System.Text.Json;

namespace TingenNyqvist.Du;

internal class DuJson
{
    /// <summary>Export JSON data to an external file.</summary>
    /// <typeparam name="JsonObject">The JSON object type.</typeparam>
    /// <param name="jsonObject">The JSON object.</param>
    /// <param name="filePath">The export file path.</param>
    /// <param name="formatJson">Determines if the JSON data is formatted.</param>
    internal static void ExportToLocalFile<JsonObject>(JsonObject jsonObject, string filePath, bool formatJson = true)
    {
        JsonSerializerOptions jsonFormat = new JsonSerializerOptions
        {
            WriteIndented = formatJson
        };

        string fileContent = JsonSerializer.Serialize(jsonObject, jsonFormat);

        File.WriteAllText(filePath, fileContent);
    }

    /// <summary>Import JSON data from an external file.</summary>
    /// <typeparam name="JsonObject">The JSON object type.</typeparam>
    /// <param name="filePath">The import file path.</param>
    /// <returns>The contents of the file as a JSON object.</returns>
    internal static JsonObject ImportFromLocalFile<JsonObject>(string filePath)
    {
        var fileContents = File.ReadAllText(filePath);

        return JsonSerializer.Deserialize<JsonObject>(fileContents);
    }
}
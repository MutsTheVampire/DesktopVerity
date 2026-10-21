using System.IO;
using System.Text.Json;
using System.Windows;

namespace DesktopVerity;

internal class AppConfig
{
    public string FriendName { get; set; } = string.Empty;
}

internal static class ConfigManager
{
    private static readonly string FILE_PATH = Path.Combine(
        AppDomain.CurrentDomain.BaseDirectory, "config.json"
    );

    private static readonly JsonSerializerOptions SERIALIZE_OPTIONS = new() { WriteIndented = true };

    public static AppConfig Config => ((App)Application.Current).Config;

    public static void Save(AppConfig config)
    {
        string jsonText = JsonSerializer.Serialize(config, SERIALIZE_OPTIONS);
        File.WriteAllText(FILE_PATH, jsonText);
    }

    public static AppConfig Load()
    {
        if (!File.Exists(FILE_PATH)) return new();

        string jsonText = File.ReadAllText(FILE_PATH);
        return JsonSerializer.Deserialize<AppConfig>(jsonText) ?? new();
    }
}
using N52_HT1.Models;
using System.Text.Json;

namespace N52_HT1.Data.DataAcces;

public class AppFileContext : IDataContext
{
    private readonly string _filePath;

    public List<User> Users { get; private set; } = new();

    public AppFileContext(IConfiguration configuration)
    {
        _filePath = configuration["DataStorage:UsersFilePath"]
            ?? "Data/DataStorage/users.json";

        Load();
    }

    private void Load()
    {
        if (!File.Exists(_filePath))
        {
            Users = new List<User>();
            return;
        }

        var json = File.ReadAllText(_filePath);

        if (string.IsNullOrWhiteSpace(json))
        {
            Users = new List<User>();
            return;
        }

        Users = JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();
    }

    public void SaveChanges()
    {
        var directory = Path.GetDirectoryName(_filePath);

        if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
            Directory.CreateDirectory(directory);

        var json = JsonSerializer.Serialize(Users, new JsonSerializerOptions
        {
            WriteIndented = true,
        });

        File.WriteAllText(_filePath, json);
    }
}

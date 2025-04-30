using System.Text.Json;
using TodoList.Core.Models;


namespace TodoList.Core;

public class TodoDataAccess
{
    private const string FilePath = "taches.json";

    public List<TodoItem> Charger()
    {
        if (!File.Exists(FilePath)) return new List<TodoItem>();
        var json = File.ReadAllText(FilePath);
        return JsonSerializer.Deserialize<List<TodoItem>>(json) ?? new List<TodoItem>();
    }

    public void Sauvegarder(List<TodoItem> taches)
    {
        var json = JsonSerializer.Serialize(taches, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(FilePath, json);
    }
}

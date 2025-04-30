namespace TodoList.Core;
using TodoList.Core.Models;

public class TodoService
{
    private readonly TodoDataAccess _dataAccess = new();
    private List<TodoItem> _taches;

    public TodoService()
    {
        _taches = _dataAccess.Charger();
    }

    public List<TodoItem> Lister(bool inclureTerminees)
    {
        return _taches
            .Where(t => inclureTerminees || !t.IsDone)
            .OrderByDescending(t => t.Priority)
            .ThenBy(t => t.DueDate)
            .ToList();
    }

    public void Ajouter(string title, int priority, DateTime dueDate)
    {
        var tache = new TodoItem { Title = title, Priority = priority, DueDate = dueDate };
        _taches.Add(tache);
        _dataAccess.Sauvegarder(_taches);
    }

    public bool MarquerCommeTerminee(int id)
    {
        var tache = _taches.FirstOrDefault(t => t.Id == id);
        if (tache == null || tache.IsDone) return false;
        tache.IsDone = true;
        _dataAccess.Sauvegarder(_taches);
        return true;
    }
}

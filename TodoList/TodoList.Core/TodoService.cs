namespace TodoList.Core;

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
            .Where(t => inclureTerminees || !t.Terminee)
            .OrderByDescending(t => t.Priorite)
            .ThenBy(t => t.DateLimite ?? DateTime.MaxValue)
            .ToList();
    }

    public void Ajouter(string nom, int priorite, DateTime? dateLimite)
    {
        var tache = new TodoItem { Nom = nom, Priorite = priorite, DateLimite = dateLimite };
        _taches.Add(tache);
        _dataAccess.Sauvegarder(_taches);
    }

    public bool MarquerCommeTerminee(Guid id)
    {
        var tache = _taches.FirstOrDefault(t => t.Id == id);
        if (tache == null || tache.Terminee) return false;
        tache.Terminee = true;
        _dataAccess.Sauvegarder(_taches);
        return true;
    }
}

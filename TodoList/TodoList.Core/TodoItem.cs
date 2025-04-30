namespace TodoList.Core;

public class TodoItem
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Nom { get; set; } = string.Empty;
    public DateTime? DateLimite { get; set; }
    public int Priorite { get; set; }
    public bool Terminee { get; set; } = false;

    public override string ToString()
    {
        var statut = Terminee ? "[✔]" : "[ ]";
        var date = DateLimite.HasValue ? DateLimite.Value.ToString("yyyy-MM-dd") : "Aucune date";
        return $"{statut} {Nom} | Priorité: {Priorite} | Date limite: {date}";
    }
}

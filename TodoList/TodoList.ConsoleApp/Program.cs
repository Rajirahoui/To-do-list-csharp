using TodoList.Core;

var service = new TodoService();
bool afficherTerminees = true;

while (true)
{
    Console.Clear();
    Console.WriteLine("==== TODO LIST ====");
    foreach (var tache in service.Lister(afficherTerminees))
    {
        var statut = tache.IsDone ? "[✓]" : "[ ]";
        Console.WriteLine($"{statut} {tache.Id} - {tache.Title} (Priorité {tache.Priority}) - À faire pour le {tache.DueDate:yyyy-MM-dd}");
    }

    Console.WriteLine("\n1. Ajouter une tâche");
    Console.WriteLine("2. Marquer comme terminée");
    Console.WriteLine("3. Afficher/Masquer tâches terminées");
    Console.WriteLine("0. Quitter");
    Console.Write("> ");
    var choix = Console.ReadLine();

    switch (choix)
    {
        case "1":
            Console.Write("Nom de la tâche: ");
            var nom = Console.ReadLine()!;
            Console.Write("Priorité (1-5): ");
            int priorite = int.Parse(Console.ReadLine()!);
            Console.Write("Date limite (yyyy-MM-dd): ");
            var dateStr = Console.ReadLine();
            DateTime dueDate = DateTime.TryParse(dateStr, out var d) ? d : DateTime.Now.AddDays(7);
            service.Ajouter(nom, priorite, dueDate);
            break;

        case "2":
            Console.Write("ID de la tâche à terminer: ");
            if (int.TryParse(Console.ReadLine(), out var id))
            {
                if (!service.MarquerCommeTerminee(id))
                    Console.WriteLine("Tâche introuvable ou déjà terminée.");
                else
                    Console.WriteLine("Tâche terminée !");
            }
            else Console.WriteLine("ID invalide.");
            Console.ReadKey();
            break;

        case "3":
            afficherTerminees = !afficherTerminees;
            break;

        case "0":
            return;

        default:
            Console.WriteLine("Choix invalide !");
            Console.ReadKey();
            break;
    }
}

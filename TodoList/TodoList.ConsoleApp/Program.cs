using TodoList.Core;

var service = new TodoService();
bool afficherTerminees = true;

while (true)
{
    Console.Clear();
    Console.WriteLine("==== TODO LIST ====");
    foreach (var tache in service.Lister(afficherTerminees))
    {
        Console.WriteLine($"{tache.Id} - {tache}");
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
            Console.Write("Date limite (yyyy-MM-dd) (optionnelle): ");
            var dateStr = Console.ReadLine();
            DateTime? date = DateTime.TryParse(dateStr, out var d) ? d : null;
            service.Ajouter(nom, priorite, date);
            break;
        case "2":
            Console.Write("ID de la tâche à terminer: ");
            if (Guid.TryParse(Console.ReadLine(), out var id))
            {
                if (!service.MarquerCommeTerminee(id))
                    Console.WriteLine("Tâche introuvable ou déjà terminée.");
                else Console.WriteLine("Tâche terminée !");
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

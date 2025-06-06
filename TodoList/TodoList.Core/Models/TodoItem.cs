namespace TodoList.Core.Models
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime DueDate { get; set; }
        public int Priority { get; set; }
        public bool IsDone { get; set; } = false;
    }
}

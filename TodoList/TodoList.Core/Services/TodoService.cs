// Services/TodoService.cs
using TodoList.Core.Data;
using TodoList.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace TodoList.Core.Services;

public class TodoService
{
    private readonly ITodoDbContext _context;

    public TodoService(ITodoDbContext context)
    {
        _context = context;
    }

    public async Task<List<TodoItem>> GetAllSorted()
    {
        return await _context.TodoItems
            .OrderBy(t => t.IsDone)
            .ThenByDescending(t => t.Priority)
            .ThenBy(t => t.DueDate)
            .ToListAsync();
    }

    public async Task<List<TodoItem>> GetDoneTasks()
    {
        return await _context.TodoItems
            .Where(t => t.IsDone)
            .ToListAsync();
    }

    public async Task MarkAsDone(int id)
    {
        var item = await _context.TodoItems.FindAsync(id);
        if (item == null || item.IsDone) return;

        item.IsDone = true;
        await _context.SaveChangesAsync();
    }
}

// Data/ITodoDbContext.cs
using Microsoft.EntityFrameworkCore;
using TodoList.Core.Models;

namespace TodoList.Core.Data;

public interface ITodoDbContext
{
    DbSet<TodoItem> TodoItems { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}

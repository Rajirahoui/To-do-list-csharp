using Microsoft.EntityFrameworkCore;
using Moq;
using TodoList.Core.Data;
using TodoList.Core.Models;
using TodoList.Core.Services;



[Fact]
public async Task GetDoneTasks_ShouldReturnOnlyDoneTasks()
{
    // Arrange
    var data = new List<TodoItem>
    {
        new TodoItem { Title = "Tâche 1", IsDone = true },
        new TodoItem { Title = "Tâche 2", IsDone = false },
    };

    var mockSet = DbSetMockHelper.CreateMockDbSet(data);

    var mockContext = new Mock<ITodoDbContext>();
    mockContext.Setup(c => c.TodoItems).Returns(mockSet.Object);

    var service = new TodoService(mockContext.Object);

    // Act
    var result = await service.GetDoneTasks();

    // Assert
    Assert.Single(result);
    Assert.All(result, i => Assert.True(i.Done));
}

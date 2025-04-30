using Xunit;
using System;
using System.Linq;
using TodoList.Core;
namespace TodoList.Tests
{
    public class TodoServiceMemoryTests
    {
        private TodoServiceMemory GetService()
        {
            var service = new TodoServiceMemory();
            service.Ajouter("Tâche A", 3, DateTime.Now.AddDays(1));  // Tâche non terminée
            service.Ajouter("Tâche B", 1, DateTime.Now.AddDays(2));  // Tâche terminée
            service.Ajouter("Tâche C", 2, DateTime.Now.AddDays(3));  // Tâche non terminée
            return service;
        }

        [Fact]
        public void Lister_ShouldReturnOnlyNotCompletedTasks_WhenExcludeCompletedIsTrue()
        {
            // Arrange
            var service = GetService();
            service.MarquerCommeTerminee(1);  // Marquer la tâche B comme terminée

            // Act
            var list = service.Lister(false);  // Lister uniquement les tâches non terminées

            // Assert
            Assert.All(list, t => Assert.False(t.IsDone));  // Vérifie que toutes les tâches listées ne sont pas terminées
        }
   
        [Fact]
        public void Ajouter_ShouldAddNewTask()
        {
            // Arrange
            var service = new TodoServiceMemory();
            var initialCount = service.Lister(false).Count;

            // Act
            service.Ajouter("Tâche D", 4, DateTime.Now.AddDays(5));

            // Assert
            var updatedCount = service.Lister(false).Count;
            Assert.Equal(initialCount + 1, updatedCount);  // Vérifie qu'une nouvelle tâche a bien été ajoutée
        }
    }
}

using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDo;
using ToDo.Models;
using ToDo.Request;
using Xunit;

namespace Tests
{
    public class BackendTests
    {
        // GetTasks_Tests
        [Fact]
        public async Task GetTasksAsync_ReturnsCorrectValues()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "DbToDo")
                .Options;
            var db = new ApplicationContext(options);
            var toDoService = new ToDoService(db);

            var list = new List<TaskItem> { new TaskItem { Name = "Name" }, new TaskItem { Name = "Name2" } };
            db.Tasks.AddRange(list);
            db.SaveChanges();

            // Act
            var actual = await toDoService.GetTasksAsync();

            // Assert
            actual.Should().BeEquivalentTo(list);
        }
        [Fact]
        public async Task GetTasksAsync_SouldBeNull()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "DbToDo")
                .Options;
            var db = new ApplicationContext(options);
            var toDoService = new ToDoService(db);

            var taskItem = new List<TaskItem> { new TaskItem { Name = null }};
            db.Tasks.AddRange(taskItem);
            db.SaveChanges();

            // Act
            var actual = await toDoService.GetTasksAsync();

            // Assert
            actual.Should().BeEquivalentTo(taskItem);
        }


        // CreateTaskAsync_Tests
        [Fact]
        public async Task CreateTaskAsync_CountCheck()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "DbToDo")
                .Options;
            var db = new ApplicationContext(options);
            var toDoService = new ToDoService(db);

            // Act
            await toDoService.CreateTaskItemAsync(new TaskItemRequest { Name = "firstName" });
            await toDoService.CreateTaskItemAsync(new TaskItemRequest { Name = "anotherName" });

            // Assert

            // var actual = await db.Tasks.FirstAsync();
            var actual = await db.Tasks.ToListAsync();
            actual.Count.Should().Be(2);
        }

        [Fact]
        public async Task CreateTaskAsync_SouldBeNull()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "DbToDo")
                .Options;
            var db = new ApplicationContext(options);
            var toDoService = new ToDoService(db);

            // Act
            await toDoService.CreateTaskItemAsync(new TaskItemRequest { Name = null });

            // Assert
            var actual = await db.Tasks.FirstAsync();
            actual.Name.Should().BeEquivalentTo(null);
        }
        [Fact]
        public async Task CreateTaskAsync_CorectValues()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "DbToDo")
                .Options;
            var db = new ApplicationContext(options);
            var toDoService = new ToDoService(db);

            // Act
            await toDoService.CreateTaskItemAsync(new TaskItemRequest { Name = "firstName" });

            // Assert
            var actual = await db.Tasks.FirstAsync();
            actual.Name.Should().BeEquivalentTo("firstName");
        }
    }
}

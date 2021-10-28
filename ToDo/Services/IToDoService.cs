using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Models;
using ToDo.Request;

namespace ToDo
{
    public interface IToDoService
    {
        Task CreateTaskItemAsync(TaskItemRequest taskItemRequest);
        Task ReadTaskItemAsync(int TaskId);
        Task UpdateTaskItemAsync(int TaskId, TaskItemRequest taskItemRequest);
        Task DeleteTaskItemAsync (int TaskId);
        Task<IEnumerable<TaskItem>> GetTasksAsync();
        Task<TaskItem> GetTaskItemAsync(int TaskId);
    }
}

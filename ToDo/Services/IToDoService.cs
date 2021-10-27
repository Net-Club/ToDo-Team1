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
        Task ReadTaskItemAsync(TaskItem taskItem);
        Task UpdateTaskItemAsync(TaskItem taskItem);
        Task DeleteTaskItemAsync (int TaskId);
        Task<IEnumerable<TaskItem>> GetTasksAsync();
        Task<TaskItem> GetTaskItemAsync(int TaskId);
    }
}

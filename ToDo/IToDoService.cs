using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Models;

namespace ToDo
{
    public interface IToDoService
    {
        Task CreateTaskItemAsync(TaskItem taskItem);
        Task ReadTaskItemAsync(Guid TaskId);
        Task UpdateTaskItemAsync(TaskItem taskItem);
        Task DeleteTaskItemAsync (int TaskId);
    }
}

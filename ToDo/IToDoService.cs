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
        void Read();
        void Update(); 
        Task DeleteTaskItemAsync (int TaskId);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDo
{
    public interface IToDoService
    {
        void Create();
        void Read();
        void Update(); 
        Task DeleteTaskItemAsync (int TaskId);
    }
}

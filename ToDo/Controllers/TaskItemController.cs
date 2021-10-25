using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskItemController : ControllerBase
    {
        private readonly IToDoService _toDoService;
        public TaskItemController(IToDoService toDoService)
        {
            _toDoService = toDoService;
        }

        [HttpDelete("{TaskId:int}")]
        public async Task DeleteTaskItem (int TaskId)
        {
            await _toDoService.DeleteTaskItemAsync(TaskId);
        }
    }
}

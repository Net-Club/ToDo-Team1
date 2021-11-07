using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Models;

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

        [HttpGet]
        public async Task ReadTaskItem(int TaskId)
        {
            await _toDoService.GetTaskItemAsync(TaskId);
        }

        [HttpPut]
        public async Task UpdateTaskItem(TaskItem taskItem)
        {
            await _toDoService.UpdateTaskItemAsync(taskItem);
        }

        [HttpDelete("{TaskId:int}")]
        public async Task DeleteTaskItem (int TaskId)
        {
            await _toDoService.DeleteTaskItemAsync(TaskId);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTaskItem()
        {
            TaskItem newTask = new TaskItem();
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
           await _toDoService.CreateTaskItemAsync(newTask);

           return Ok();
        }

    }
}

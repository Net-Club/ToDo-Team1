using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Models;

namespace ToDo
{
    public class ToDoService : IToDoService
    {
        private readonly ApplicationContext _context;

        public ToDoService (ApplicationContext context)
        {
            _context = context;
        }

        public async Task<TaskItem> GetTaskItemAsync (int TaskId)
        {
            var task = await _context.Tasks.FindAsync(TaskId);
            return task;
        }
        public void Create()
        {
            throw new NotImplementedException();
        }

        public async Task ReadTaskItemAsync(Guid TaskId)
        {
            await _context.Tasks.FindAsync(TaskId);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTaskItemAsync(TaskItem taskItem)
        {
            _context.Entry(taskItem).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new NotImplementedException();
            }
        }

        public async Task DeleteTaskItemAsync(int TaskId)
        {
            var task = await GetTaskItemAsync(TaskId);
            if (task == null)
            {
                throw new NullReferenceException();
            }

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
        }
    }
}

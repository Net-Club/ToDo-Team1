using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDo.Models
{
    public enum CategorySelector
    {
        Work,
        Home,
        Stady,
        SadGorod
    }
    public enum PrioritySelector
    {
        Critical,
        Important,
        Medium,
        Low
    }
    public class Category
    {
        public int CategoryID { get; set; }
        public CategorySelector CategoryName { get; set; }
        public PrioritySelector PriorityName { get; set; }

        public List<Task> Tasks { get; set; }
    }
}

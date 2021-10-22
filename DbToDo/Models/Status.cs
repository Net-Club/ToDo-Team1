using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDo.Models
{
    public enum StatusEnum
    {
        Inprogress,
        Done,
        NotStarted

    }
    public class Status
    {
        public int StatusId { get; set; }
        public StatusEnum StatusEnum { get; set; }

        public List<Task> Tasks { get; set; }
    }
}


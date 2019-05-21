using System;
using System.Collections.Generic;
using System.Text;

namespace ToDo.Core.Dtos
{
    public class AddTaskDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; }
    }
}

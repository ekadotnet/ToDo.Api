using System;
using System.Collections.Generic;
using System.Text;
using ToDo.Core.Dtos;

using ToDo.Data.Models;

namespace ToDo.Core.Interfaces
{
    public interface IToDoTaskService
    {
        IEnumerable<ShowTaskDto> GetTasks();
        ShowTaskDto GetTask(int id);
        void Add(AddTaskDto addTaskDto);
        void Update(UpdateTaskDto updateTaskDto);
        void Delete(int id);
    }
}

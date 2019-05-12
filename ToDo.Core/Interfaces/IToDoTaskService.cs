using System;
using System.Collections.Generic;
using System.Text;
using ToDo.Data.Models;

namespace ToDo.Core.Interfaces
{
    public interface IToDoTaskService
    {
        void Add(ToDoTask toDoTask);
        void Update(ToDoTask toDoTask);
        void Delete(ToDoTask toDoTask);
    }
}

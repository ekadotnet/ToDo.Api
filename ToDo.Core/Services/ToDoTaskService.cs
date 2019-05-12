using System;
using System.Collections.Generic;
using System.Text;
using ToDo.Data;
using ToDo.Data.Models;
using ToDo.Core.Interfaces;

namespace ToDo.Core.Services
{
    public class ToDoTaskService : IToDoTaskService
    {
        private readonly Repository<ToDoTask> _repository;

        public ToDoTaskService(Repository<ToDoTask> repository)
        {
            _repository = repository;
        }

        public void Add(ToDoTask toDoTask)
        {
            _repository.Add(toDoTask);
        }

        public void Update(ToDoTask toDoTask)
        {
            _repository.Update(toDoTask);
        }

        public void Delete(ToDoTask toDoTask)
        {
            _repository.Delete(toDoTask);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using ToDo.Data;
using ToDo.Data.Models;
using ToDo.Core.Interfaces;
using ToDo.Data.Dtos;

namespace ToDo.Core.Services
{
    public class ToDoTaskService : IToDoTaskService
    {
        private readonly IRepository<ToDoTask> _repository;

        public ToDoTaskService(IRepository<ToDoTask> repository)
        {
            _repository = repository;
        }



        public IEnumerable<ShowTaskDto> GetTasks()
        {
            IEnumerable<ToDoTask> tasks = _repository.Get();
           var showTaskDto = new List<ShowTaskDto>();
            showTaskDto = tasks.Select(x => new ShowTaskDto()
            {
                Id = x.Id,
                Description = x.Description,
                DueDate = x.DueDate,
                IsCompleted = x.IsCompleted,
                Name = x.Name
            }).ToList();

            return showTaskDto;
        }

        public ShowTaskDto GetTask(int id)
        {
            IEnumerable<ToDoTask> tasks = _repository.Get();
            var task = tasks.FirstOrDefault(x => x.Id == id);
            if (task != null)
            {

                var showTaskDto = new ShowTaskDto()
                {
                    Id = task.Id,
                    Description = task.Description,
                    DueDate = task.DueDate,
                    IsCompleted = task.IsCompleted,
                    Name = task.Name
                };

                return showTaskDto;
            }

            return null;
        }

        public void Add(AddTaskDto addTaskDto)
        {
            ToDoTask task = new ToDoTask()
            {
                Description = addTaskDto.Description,
                DueDate = addTaskDto.DueDate,
                IsCompleted = addTaskDto.IsCompleted,
                Name = addTaskDto.Name
            };
            _repository.Add(task);
        }

        public void Update(UpdateTaskDto updateTaskDto)
        {
            ToDoTask task = new ToDoTask()
            {
                Id = updateTaskDto.Id,
                Description = updateTaskDto.Description,
                DueDate = updateTaskDto.DueDate,
                IsCompleted = updateTaskDto.IsCompleted,
                Name = updateTaskDto.Name
            };
            _repository.Update(task);
        }

        public void Delete(DeleteTaskDto deleteTaskDto)
        {
            ToDoTask task = new ToDoTask()
            {
                Id = deleteTaskDto.Id,
                Description = deleteTaskDto.Description,
                DueDate = deleteTaskDto.DueDate,
                IsCompleted = deleteTaskDto.IsCompleted,
                Name = deleteTaskDto.Name
            };
            _repository.Delete(task);
        }
    }
}

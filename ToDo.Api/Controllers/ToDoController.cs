using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDo.Core.Interfaces;
using ToDo.Data.Dtos;
using ToDo.Data.Models;


namespace ToDo.Api.Controllers
{
    [Route("api/toDo")]
    public class ToDoController : Controller
    {
       private readonly IToDoTaskService _toDoTaskServices;
        
        public ToDoController(IToDoTaskService toDoTaskServices)
        {
            _toDoTaskServices = toDoTaskServices;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(_toDoTaskServices.GetTasks());
        }
        [HttpGet("/{id}")]
        public IActionResult Get(int id)
        {
            var taskDto = _toDoTaskServices.GetTask(id);
            if (taskDto != null)
            {
                return new JsonResult(taskDto);
            }

            return BadRequest();
        }

        [HttpPost]
        public IActionResult Add([FromBody]AddTaskDto taskDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _toDoTaskServices.Add(taskDto);
            return Ok();
        }
        [HttpPut]
        public IActionResult Update([FromBody] UpdateTaskDto taskDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _toDoTaskServices.Update(taskDto);
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete([FromBody] DeleteTaskDto taskDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _toDoTaskServices.Delete(taskDto);
            return Ok();
        }



    }
}

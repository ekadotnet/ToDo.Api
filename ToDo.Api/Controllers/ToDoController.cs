using Microsoft.AspNetCore.Mvc;
using ToDo.Core.Dtos;
using ToDo.Core.Interfaces;



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
        [HttpGet("{id}")]
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
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var task = _toDoTaskServices.GetTask(id);
            if (task == null)
            {
                return BadRequest();
            }

            _toDoTaskServices.Delete(id);
            return Ok();
        }
    }
}

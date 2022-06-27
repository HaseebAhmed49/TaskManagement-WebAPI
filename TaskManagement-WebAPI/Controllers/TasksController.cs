using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagement_WebAPI.Data.Models;
using TaskManagement_WebAPI.Data.Services;

namespace TaskManagement_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private TasksService _tasksService;

        public TasksController(TasksService tasksService)
        {
            _tasksService = tasksService;
        }

        [HttpGet("get-all-tasks")]
        public IActionResult GetAllTasks()
        {
            try
            {
                var tasks = _tasksService.GetAllTasks();
                return (tasks.Count>0) ? Ok(tasks) : BadRequest("No Tasks Found");
            }
            catch(Exception ex)
            {
                return StatusCode(500,ex.Message);
            }
        }

        [HttpGet("get-task-by-id/{id}")]
        public IActionResult GetTaskById(int id)
        {
            try
            {
                var task = _tasksService.GetTaskById(id);
                return (task!=null) ? Ok(task) : BadRequest("No Tasks Found");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }



        [HttpPost("add-task")]
        public IActionResult AddTask([FromBody]TaskDataVM task)
        {
            try
            {
                if (String.IsNullOrEmpty(task.taskName)) return BadRequest("Task Name shouldn't be empty");
                _tasksService.AddTasks(task);
                return Ok(task);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("update-task-by-id/{id}")]
        public IActionResult UpdateTask(int id, [FromBody]TaskDataVM taskDataVM)
        {
            try
            {
                if (id <= 0) return BadRequest("Id can't be -ve 0r 0");
                if (String.IsNullOrEmpty(taskDataVM.taskName)) return BadRequest("Task Name shouldn't be empty");
                var _taskDetails =_tasksService.UpdateTaskDetails(id,taskDataVM);
                return Ok(_taskDetails);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("delete-task-by-id/{id}")]
        public IActionResult DeleteTask(int id)
        {
            try
            {
                if (id <= 0) return BadRequest("Id can't be -ve 0r 0");
                _tasksService.DeleteTask(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


    }
}

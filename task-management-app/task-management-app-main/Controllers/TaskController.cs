
using Microsoft.AspNetCore.Mvc;


namespace TaskManagementApp.Controllers
{
    [ApiController]
    [Route("api")]
    public class TaskController : ControllerBase
    {
        
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }
    
    [HttpGet("Task")]
     public async Task<ActionResult<ServiceResponse<List<GetTaskDto>>>> GetAllTask(){
         return Ok(await _taskService.GetAllTasks());
    }

    [HttpPost("Task")]
     public async Task<ActionResult<ServiceResponse<TaskModel>>> AddNewTask(AddTaskDto newTask){
         return Ok(await _taskService.AddTask(newTask));
    }

    [HttpPatch("Task/{Id}")]
     public async Task<ActionResult<ServiceResponse<TaskModel>>> UpdateTaskById(int Id, UpdateTaskDto updatedTask){
         return Ok(await _taskService.UpdateTaskById(Id,updatedTask));
    }

     [HttpDelete("Task/{Id}")]
     public async Task<ActionResult<ServiceResponse<TaskModel>>> DeleteTaskById(int Id){
         return Ok(await _taskService.DeleteTaskById(Id));
    }

    [HttpGet("Task/{Id}")]
     public async Task<ActionResult<ServiceResponse<TaskModel>>> GetTaskById(int Id){
         return Ok(await _taskService.GetTaskById(Id));
    }
    }
}
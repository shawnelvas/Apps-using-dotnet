

namespace TaskManagementApp.Services
{
    public interface ITaskService
    {
       Task<ServiceResponse<List<GetTaskDto>>> GetAllTasks();

       Task<ServiceResponse<GetTaskDto>> GetTaskById(int Id);

       Task<ServiceResponse<GetTaskDto>> UpdateTaskById(int Id, UpdateTaskDto updatedTask);

       Task<ServiceResponse<GetTaskDto>> AddTask(AddTaskDto newTask);

       Task<ServiceResponse<List<GetTaskDto>>> DeleteTaskById(int Id);
    }
}
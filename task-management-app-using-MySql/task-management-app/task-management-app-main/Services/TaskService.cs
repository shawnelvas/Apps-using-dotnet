

namespace TaskManagementApp.Services
{
    public class TaskService : ITaskService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public TaskService(IMapper mapper, DataContext context)
        {
            _mapper=mapper;
            _context = context;
        }


        public async Task<ServiceResponse<List<GetTaskDto>>> GetAllTasks(){
            var serviceResponse = new ServiceResponse<List<GetTaskDto>>();
            var dbTasks = await _context.Tasks.ToListAsync();
            serviceResponse.Data=dbTasks.Select(c=> _mapper.Map<GetTaskDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetTaskDto>> GetTaskById(int Id)
        {
            
            var serviceResponse = new ServiceResponse<GetTaskDto>();
        
            try{

                var task = await _context.Tasks.FirstOrDefaultAsync(c=>c.Id == Id);
                if(task is null)
                    throw new Exception($"Task with Id:{Id} Not Found.");
                
                serviceResponse.Data= _mapper.Map<GetTaskDto>(task);
                return serviceResponse;


            }catch(Exception e){
                serviceResponse.Success=false;
                serviceResponse.Message=e.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetTaskDto>>> DeleteTaskById(int Id)
        {
            var serviceResponse = new ServiceResponse<List<GetTaskDto>>();

            try{
                var task=await _context.Tasks.FirstOrDefaultAsync(c=>c.Id == Id);
                if(task is null)
                    throw new Exception($"Task with Id:{Id} Not Found.");


            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
            
            serviceResponse.Data=_context.Tasks.Select(c=> _mapper.Map<GetTaskDto>(c)).ToList();
            serviceResponse.Message=$"Task with Id:{Id} Deleted.";

            }catch(Exception e){

                serviceResponse.Success=false;
                serviceResponse.Message=e.Message;
            }
            

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetTaskDto>> AddTask(AddTaskDto newTask)
        {
            var serviceResponse = new ServiceResponse<GetTaskDto>();
            var task = _mapper.Map<TaskModel>(newTask);
            
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();

            serviceResponse.Data= _mapper.Map<GetTaskDto>(task);
            serviceResponse.Message="New Task Added Successfully";

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetTaskDto>> UpdateTaskById(int Id, UpdateTaskDto updatedTask)
        {
             var serviceResponse = new ServiceResponse<GetTaskDto>();

            try{
                var task=await _context.Tasks.FirstOrDefaultAsync(c=>c.Id == Id);
                if(task is null)
                    throw new Exception($"Task with Id:{Id} Not Found.");

                task.Title=updatedTask.Title;
                task.Description=updatedTask.Description;
                task.Status=updatedTask.Status;

                await _context.SaveChangesAsync();

                serviceResponse.Data= _mapper.Map<GetTaskDto>(task);
                serviceResponse.Message=$"Task with Id:{Id} Updated.";

            }catch(Exception e){

                serviceResponse.Success=false;
                serviceResponse.Message=e.Message;
            }
            

            return serviceResponse;
            
        }
    }
}
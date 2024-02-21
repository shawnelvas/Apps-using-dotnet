


namespace TaskManagementApp
{
    public class AutoMapperProfile : Profile
    {
          public AutoMapperProfile()
          {
          CreateMap<TaskModel,GetTaskDto>();
          CreateMap<AddTaskDto,TaskModel>();
          
          }
    }
}
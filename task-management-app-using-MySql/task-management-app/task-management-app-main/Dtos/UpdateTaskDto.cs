

namespace TaskManagementApp.Dtos
{
    public class UpdateTaskDto
    {
       
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public Status Status { get; set; } 
    }
}
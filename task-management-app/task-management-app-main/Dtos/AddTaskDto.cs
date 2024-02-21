
namespace TaskManagementApp.Dtos
{
    public class AddTaskDto
    {
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public Status Status { get; set; } = Status.New;
    }
}
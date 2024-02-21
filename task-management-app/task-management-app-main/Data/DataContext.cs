

namespace TaskManagementApp.Data
{
    public class DataContext : DbContext
    {
         public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<TaskModel> Tasks => Set<TaskModel>();
    }
}
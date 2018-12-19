using TaskManager.Entities;
using System.Data.Entity;

namespace TaskManager.Repositories
{
    public class TaskManagerDbContext : DbContext
    {
        public TaskManagerDbContext():base("name=TaskManagerDb")
        {
        }

        public DbSet<ParentTask> ParentTasks { get; set; }
        public DbSet<ProjectTask> Tasks { get; set; }

    }
}

using Microsoft.EntityFrameworkCore;

namespace Task_Manager.Models
{
    public class TaskManagerDbContext(DbContextOptions<TaskManagerDbContext> options) :DbContext(options)
    {
        public DbSet<JobInfo> JobInfos { get; set; }
    }
}

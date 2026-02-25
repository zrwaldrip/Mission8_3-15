using Microsoft.EntityFrameworkCore;

namespace Mission8_3_15.Models;

public class TaskContext : DbContext
{
    public TaskContext(DbContextOptions<TaskContext> options) : base(options)
    {
        
    }
    
    public DbSet<Task> Tasks { get; set; }
}
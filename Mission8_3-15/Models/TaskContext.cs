using Microsoft.EntityFrameworkCore;

namespace Mission8_3_15.Models;

public class TaskContext : DbContext
{
    public TaskContext(DbContextOptions<TaskContext> options) : base(options)
    {
    }
    
    public DbSet<TaskItem> Tasks { get; set; }
    
    // ADD THIS LINE to fix the red errors
    public DbSet<Category> Categories { get; set; } 
}
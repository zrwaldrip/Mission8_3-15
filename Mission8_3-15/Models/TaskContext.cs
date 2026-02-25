using Microsoft.EntityFrameworkCore;

namespace Mission8_3_15.Models;

public class TaskContext : DbContext
{
    public TaskContext(DbContextOptions<TaskContext> options) : base(options)
    {
    }
    
    public DbSet<Task> Tasks { get; set; }
    
    // ADD THIS LINE to fix the red errors
    public DbSet<Category> Categories { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(
            new Category { CategoryId = 1, CategoryName = "Home" },
            new Category { CategoryId = 2, CategoryName = "School" },
            new Category { CategoryId = 3, CategoryName = "Work" },
            new Category { CategoryId = 4, CategoryName = "Church" }
            // Add as many more as you need right here!
        );
    }
}
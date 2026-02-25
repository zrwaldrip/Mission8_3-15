using System.ComponentModel.DataAnnotations;

namespace Mission8_3_15.Models;

public class TaskItem
{
    [Key]
    [Required]
    public int TaskId { get; set; }
    [Required]
    public string TaskName { get; set; }
    
    public DateOnly? DueDate { get; set; }
    
    [Required]
    public int Quadrant { get; set; }
    
    public string? Category { get; set; }
    
    [Required]
    public bool Completed { get; set; }
    
    
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; // Add this

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
    
    // Foreign Key linking to the Category model
    [ForeignKey("Category")]
    public int? CategoryId { get; set; }
    public Category? Category { get; set; }
    
    [Required]
    public bool Completed { get; set; }
}
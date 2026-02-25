namespace Mission8_3_15.Models;

public interface ITaskRepository
{
    List<TaskItem> Tasks { get; }
    List<Category> Categories { get; }
    
    void UpdateTask(TaskItem newTask);
        
    // Add these to match what you just wrote in EFTaskRepository
    void SaveTask(TaskItem editTask);
    void DeleteTask(TaskItem task);
}
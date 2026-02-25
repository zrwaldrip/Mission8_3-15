namespace Mission8_3_15.Models;

public class EFTaskRepository : ITaskRepository
{
    private TaskContext _context;

    public EFTaskRepository(TaskContext temp)
    {
        _context = temp;
    }

    public List<TaskItem> Tasks => _context.Tasks.ToList();
    public List<Category> Categories => _context.Categories.ToList();

    public void SaveTask(TaskItem newTask)
    {
        _context.Tasks.Add(newTask);
        _context.SaveChanges();
    }

    public void DeleteTask(TaskItem task)
    {
        _context.Tasks.Remove(task);
        _context.SaveChanges();
    }

    public void UpdateTask(TaskItem editTask)
    {
        _context.Tasks.Update(editTask);
        _context.SaveChanges();
    }
    
}
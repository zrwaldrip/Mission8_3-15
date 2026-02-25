namespace Mission8_3_15.Models
{
    public interface iTasksRepository
    {
        IQueryable<Task> Tasks { get; }
        // Note: HomeController references Categories, so you need it here
        IQueryable<Category> Categories { get; } 
        
        void SaveTask(Task task);
        void UpdateTask(Task task);
        void DeleteTask(Task task);
    }
}
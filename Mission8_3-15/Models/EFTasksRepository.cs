namespace Mission8_3_15.Models
{
    public class EFTasksRepository : iTasksRepository
    {
        private TaskContext _context;

        public EFTasksRepository(TaskContext temp)
        {
            _context = temp;
        }

        public IQueryable<Task> Tasks => _context.Tasks;
        
        // You will need a Categories DbSet in your TaskContext for this to work
        public IQueryable<Category> Categories => _context.Categories; 

        public void SaveTask(Task task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
        }

        public void UpdateTask(Task task)
        {
            _context.Tasks.Update(task);
            _context.SaveChanges();
        }

        public void DeleteTask(Task task)
        {
            _context.Tasks.Remove(task);
            _context.SaveChanges();
        }
    }
}
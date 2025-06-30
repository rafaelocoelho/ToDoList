using ToDoList.Infra.Contexts;
using ToDoList.Infra.Repositories;

namespace ToDoList.Infra.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private ITaskRepository _taskRepository;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public ITaskRepository Tasks => _taskRepository ??= new TaskRepository(_context);

        
        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

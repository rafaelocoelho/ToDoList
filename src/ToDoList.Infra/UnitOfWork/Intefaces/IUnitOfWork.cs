using ToDoList.Infra.Repositories;

namespace ToDoList.Infra.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ITaskRepository Tasks { get; }
        Task<int> CompleteAsync();
    }
}

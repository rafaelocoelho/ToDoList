using Microsoft.Extensions.DependencyInjection;
using ToDoList.Application.Services;
using ToDoList.Core.Services;
using ToDoList.Core.Services.Interfaces;
using ToDoList.Infra.Repositories;
using ToDoList.Infra.UnitOfWork;

namespace ToDoList.IoC
{
    public static class Bootstrapper
    {
        public static void AddIoC(this IServiceCollection services)
        {

            services.AddRepositories();
            services.AddServices();
        }

        private static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        private static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<ITaskService, TaskService>();
        }
    }
}

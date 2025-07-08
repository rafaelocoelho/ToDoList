using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SQLitePCL;
using ToDoList.Infra.Contexts;
using ToDoList.Infra.Repositories;
using ToDoList.Infra.UnitOfWork;

namespace ToDoList.Infra
{
    public static class Bootstrapper
    {

        public static void Addinfra(this IServiceCollection services, IConfiguration configuration)
        {
            Batteries.Init();

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(configuration.GetConnectionString("DefaultConnection"),
                    assembly => assembly.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddRepositories();
        }

        private static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<IUnitOfWork, Infra.UnitOfWork.UnitOfWork>();
        }
    }
}

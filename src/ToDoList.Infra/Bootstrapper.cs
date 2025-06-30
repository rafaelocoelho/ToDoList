using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToDoList.Infra.Contexts;
using SQLitePCL;

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
        }
    }
}

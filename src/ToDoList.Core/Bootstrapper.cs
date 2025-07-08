using Microsoft.Extensions.DependencyInjection;

namespace ToDoList.Core
{
    public static class Bootstrapper
    {
        public static void AddCore(this IServiceCollection services)
        {
            services.AddScoped<ITaskService, TaskService>();
        }
    }
}

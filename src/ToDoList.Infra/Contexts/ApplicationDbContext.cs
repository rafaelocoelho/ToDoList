using Microsoft.EntityFrameworkCore;
using ToDoList.Infra.Mappers;

namespace ToDoList.Infra.Contexts
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TaskMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}

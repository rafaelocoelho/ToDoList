using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ToDoList.Infra.Mappers
{
    public class TaskMap : IEntityTypeConfiguration<Domain.Entities.Task>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Task> builder)
        {
            builder.ToTable("tasks");

            builder.HasKey(t => t.Id)
                .HasName("id");

            builder.Property(t => t.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(t => t.Title)
                .HasColumnName("title")
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(t => t.Description)
                .HasColumnName("description")
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(t => t.CreatedAt)
                .HasColumnName("created_at")
                .IsRequired()
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(t => t.DueDate)
                .HasColumnName("due_date")
                .IsRequired(false);

            builder.Property(t => t.Status)
                .HasColumnName("status")
                .IsRequired()
                .HasConversion<string>();
        }
    }
}

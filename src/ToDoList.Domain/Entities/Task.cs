namespace ToDoList.Domain.Entities
{
    public class Task : Base
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? DueDate { get; set; }
        public Enums.TaskStatus Status { get; set; } = Enums.TaskStatus.Pending;

        public override bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}

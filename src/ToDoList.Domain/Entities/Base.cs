namespace ToDoList.Domain.Entities
{
    public abstract class Base
    {
        public Guid Id { get; set; }

        internal List<string> _errors = new List<string>();
        public IReadOnlyList<string> Errors => _errors.AsReadOnly();

        public abstract bool IsValid();
    }
}

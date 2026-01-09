using Domain.Entities.Task;

namespace Domain.Entities.Tags
{
    public class Tag : Entity
    {
        public required string Title { get; set; }

        public ICollection<TodoTask> TodoTasks { get; set; }
    }
}

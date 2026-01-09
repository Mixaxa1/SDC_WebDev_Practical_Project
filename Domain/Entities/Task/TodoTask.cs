using Domain.Entities.List;
using Domain.Entities.Tags;

namespace Domain.Entities.Task
{
    public class TodoTask : Entity
    {
        public TodoList List { get; set; }
        public Guid ListId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime DueAt { get; set; }
        public TaskState Status { get; set; }
        public ICollection<Tag> Tags { get; set; } = new List<Tag>();
    }
}

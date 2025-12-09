using Domain.Entities.List;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public ICollection<Tag>? Tags { get; set; }
    }
}

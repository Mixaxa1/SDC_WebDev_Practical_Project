using Newtonsoft.Json;

namespace WebApp.Models.TodoTask
{
    public class CreateTodoTaskModel
    {
        public Guid Id { get; set; }
        public Guid ListId {get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueAt { get; set; }
        public string Status { get; set; }
    }
}

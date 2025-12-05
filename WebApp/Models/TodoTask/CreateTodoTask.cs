namespace WebApp.Models.TodoTask
{
    public class CreateTodoTask
    {
        public Guid ListId {get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueAt { get; set; }
    }
}

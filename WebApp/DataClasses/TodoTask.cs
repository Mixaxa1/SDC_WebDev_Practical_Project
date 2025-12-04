namespace WebApp.DataClasses
{
    public class TodoTask
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime DueAt { get; set; }
        public TaskState Status { get; set; }
        public IEnumerable<String> Tags { get; set; }
    }
}

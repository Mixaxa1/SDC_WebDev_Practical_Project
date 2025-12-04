namespace WebApi.Models
{
    public class TodoTaskModel
    {
        public Guid Id { get; set; }
        public int ListId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime DueAt { get; set; }
        public int Status { get; set; }

    }
}

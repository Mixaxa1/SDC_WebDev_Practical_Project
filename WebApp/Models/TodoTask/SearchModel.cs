namespace WebApp.Models.TodoTask
{
    public class SearchModel
    {
        public string? Title { get; set; }
        public Guid? TagId { get; set; }
        public DateTime? CreatedAfter { get; set; }
        public DateTime? CreatedBefore { get; set; }
        public DateTime? DueAfter { get; set; }
        public DateTime? DueBefore { get; set; }
    }
}

using WebApp.Models.TaskTag;
using WebApp.Models.TodoTask;

namespace WebApp.ViewModels
{
    public class SearchViewModel
    {
        public string? Title { get; set; }
        public DateTime? CreatedAfter { get; set; }
        public DateTime? CreatedBefore { get; set; }
        public DateTime? DueAfter { get; set; }
        public DateTime? DueBefore { get; set; }
        public Guid? TagId { get; set; }
        public List<TagModel> Tags { get; set; } = new List<TagModel>();
        public List<TodoTaskModel> SearchResults { get; set; } = new List<TodoTaskModel>();
    }
}

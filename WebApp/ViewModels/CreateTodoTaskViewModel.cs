using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WebApp.Models.TaskTag;

namespace WebApp.ViewModels
{
    public class CreateTodoTaskViewModel
    {
        public Guid Id { get; set; }
        public Guid ListId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DueAt { get; set; }
        public string Status { get; set; }
        public List<TagModel> SelectedTags { get; set; }
        public List<TagModel> TagSelectionOptions { get; set; }
    }
}

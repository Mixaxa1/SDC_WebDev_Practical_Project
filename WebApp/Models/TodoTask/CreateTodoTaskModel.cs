using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using WebApp.Models.TaskTag;

namespace WebApp.Models.TodoTask
{
    public class CreateTodoTaskModel
    {
        public Guid Id { get; set; }
        public Guid ListId {get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DueAt { get; set; }
        public string Status { get; set; }
        public ICollection<TagModel> Tags { get; set; }
    }
}

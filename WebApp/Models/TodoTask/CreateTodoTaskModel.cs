using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace WebApp.Models.TodoTask
{
    public class CreateTodoTaskModel
    {
        public Guid Id { get; set; }
        public Guid ListId {get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        [BindProperty, DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm}", ApplyFormatInEditMode = true)]
        public DateTime? DueAt { get; set; }
        public string Status { get; set; }
    }
}

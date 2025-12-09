using Domain.Entities.Task;

namespace Application.TaskLogic.RequestDto
{
    public class CreateTodoTaskRequestDto
    {
        public Guid Id { get; set; }
        public Guid ListId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueAt { get; set; }
        public string? Status { get; set; }
    }
}

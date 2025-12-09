using Application.TaskLogic.ResponceDto;

namespace Application.ListLogic.ResponseDto
{
    public class TodoListResponceDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<TodoTaskResponceDto> Tasks { get; set; }
    }
}


namespace Application.ListLogic.RequestDto
{
    public class CreateTodoListRequestDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}

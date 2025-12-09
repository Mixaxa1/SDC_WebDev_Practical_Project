using Application.ListLogic.ResponseDto;
using Database;
using Database.EntityServices.Interfaces;
using Domain.Entities.List;
using MediatR;

namespace Application.ListLogic.Commands.CreateList
{
    public class CreateTodoListHandler : IRequestHandler<CreateTodoListCommand, TodoListResponceDto?>
    {
        private readonly ITodoListDbService _todoListService;
        private readonly AppDbContext _dbContext;

        public CreateTodoListHandler(ITodoListDbService todoListService, AppDbContext dbContext)
        {
            _todoListService = todoListService;
            _dbContext = dbContext;
        }

        public async Task<TodoListResponceDto?> Handle(CreateTodoListCommand request, CancellationToken cancellationToken)
        {
            var list = new TodoList() { Id = Guid.NewGuid(), Title = request.dto.Title, Description = request.dto.Description };

            await _todoListService.CreateAsync(list);
            await _dbContext.SaveChangesAsync();

            return new TodoListResponceDto() 
            { 
                Id = list.Id, 
                Title = list.Title, 
                Description = 
                list.Description 
            };
        }
    }
}

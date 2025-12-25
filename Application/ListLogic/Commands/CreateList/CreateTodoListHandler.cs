using Application.Abstraction.Repositories;
using Application.ListLogic.ResponseDto;
using Domain.Entities.List;
using MediatR;

namespace Application.ListLogic.Commands.CreateList
{
    public class CreateTodoListHandler : IRequestHandler<CreateTodoListCommand, TodoListResponceDto?>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateTodoListHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<TodoListResponceDto?> Handle(CreateTodoListCommand request, CancellationToken cancellationToken)
        {
            var list = new TodoList() { Id = Guid.NewGuid(), Title = request.dto.Title, Description = request.dto.Description };

            await _unitOfWork.TodoListRepository.CreateAsync(list);
            await _unitOfWork.SaveChangesAsync();

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

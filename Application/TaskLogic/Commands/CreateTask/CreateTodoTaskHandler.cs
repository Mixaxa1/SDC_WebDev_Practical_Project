using Application.Abstraction.Repositories;
using Application.TaskLogic.ResponceDto;
using Domain.Entities.Task;
using MediatR;

namespace Application.TaskLogic.Commands.CreateTask
{
    public class CreateTodoTaskHandler : IRequestHandler<CreateTodoTaskCommand, TodoTaskResponceDto?>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateTodoTaskHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<TodoTaskResponceDto?> Handle(CreateTodoTaskCommand request, CancellationToken cancellationToken)
        {
            var list = await _unitOfWork.TodoListRepository.GetByIdAsync(request.dto.ListId);

            if (list == null)
            {
                return null;
            }

            var task = new TodoTask()
            {
                Id = Guid.NewGuid(),
                List = list,
                Title = request.dto.Title,
                Description = request.dto.Description,
                CreatedAt = DateTime.UtcNow,
                DueAt = request.dto.DueAt,
                Status = TaskState.NotStarted
            };

            await _unitOfWork.TodoTaskRepository.CreateAsync(task);
            await _unitOfWork.SaveChangesAsync();

            return new TodoTaskResponceDto()
            {
                Id = task.Id,
                ListId = list.Id,
                Title = task.Title,
                Description = task.Description,
                CreatedAt = task.CreatedAt,
                DueAt = task.DueAt,
                Status = task.Status.ToString()
            };
        }
    }
}

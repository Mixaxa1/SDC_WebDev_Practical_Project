using Application.Abstraction.Repositories;
using Application.TaskLogic.ResponceDto;
using MediatR;

namespace Application.TaskLogic.Queries.GetTaskById
{
    public class GetTaskByIdHandler : IRequestHandler<GetTaskByIdQuery, TodoTaskResponceDto?>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTaskByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<TodoTaskResponceDto?> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
        {
            var task = await _unitOfWork.TodoTaskRepository.GetByIdAsync(request.id);

            if (task == null)
            {
                return null;
            }

            return new TodoTaskResponceDto()
            {
                Id = task.Id,
                ListId = task.ListId,
                Title = task.Title,
                Description = task.Description,
                CreatedAt = task.CreatedAt,
                DueAt = task.DueAt,
                Status = task.Status.ToString(),
            };
        }
    }
}

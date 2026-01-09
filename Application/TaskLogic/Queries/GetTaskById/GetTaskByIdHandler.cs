using Application.Abstraction.Repositories;
using Application.TagLogic.ResponceDto;
using Application.TaskLogic.ResponceDto;
using Domain.Entities.List;
using Domain.Entities.Task;
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
            TodoTask? task;

            if (request.withIncludes)
            {
                task = await _unitOfWork.TodoTaskRepository.GetByIdWithIncludesAsync(request.id, x => x.Tags);
            }
            else
            {
                task = await _unitOfWork.TodoTaskRepository.GetByIdWithIncludesAsync(request.id);
            }

            if (task == null)
            {
                return null;
            }

            var result = new TodoTaskResponceDto()
            {
                Id = task.Id,
                ListId = task.ListId,
                Title = task.Title,
                Description = task.Description,
                CreatedAt = task.CreatedAt,
                DueAt = task.DueAt,
                Status = task.Status.ToString(),
            };

            if (request.withIncludes)
            {
                foreach(var tag in task.Tags)
                {
                    result.Tags.Add(new TagResponceDto()
                    {
                        Id = tag.Id,
                        Title = tag.Title
                    });
                }
            }

            return result;
        }
    }
}

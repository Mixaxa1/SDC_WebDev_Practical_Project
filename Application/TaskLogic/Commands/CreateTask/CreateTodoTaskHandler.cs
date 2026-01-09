using Application.Abstraction.Repositories;
using Application.TagLogic.ResponceDto;
using Application.TaskLogic.ResponceDto;
using Domain.Entities.Tags;
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
                Status = TaskState.NotStarted,
                Tags = new List<Tag>()
            };

            Tag dbTag;
            foreach (var tag in request.dto.Tags)
            {
                dbTag = await _unitOfWork.TagRepository.GetByIdAsync(tag.Id);
                if (dbTag != null)
                {
                    task.Tags.Add(dbTag);
                }
            }

            await _unitOfWork.TodoTaskRepository.CreateAsync(task);
            await _unitOfWork.SaveChangesAsync();

            var result = new TodoTaskResponceDto()
            {
                Id = task.Id,
                ListId = list.Id,
                Title = task.Title,
                Description = task.Description,
                CreatedAt = task.CreatedAt,
                DueAt = task.DueAt,
                Status = task.Status.ToString(),
                Tags = new List<TagResponceDto>()
            };

            foreach (var tag in task.Tags)
            {
                result.Tags.Add(new TagResponceDto()
                {
                    Id = tag.Id,
                    Title = tag.Title
                });
            }

            return result;
        }
    }
}

using Application.TaskLogic.ResponceDto;
using MediatR;
using Domain.Entities.Task;
using Application.Abstraction.Repositories;
using Application.TagLogic.ResponceDto;
using Domain.Entities.Tags;

namespace Application.TaskLogic.Commands.UpdateTask
{
    public class UpdateTodoTaskHandler : IRequestHandler<UpdateTodoTaskCommand, TodoTaskResponceDto?>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateTodoTaskHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<TodoTaskResponceDto?> Handle(UpdateTodoTaskCommand command, CancellationToken cancellationToken)
        {
            var task = await _unitOfWork.TodoTaskRepository.GetByIdWithIncludesAsync(command.dto.Id, x => x.Tags);

            TaskState status;
            if (task == null || Enum.TryParse<TaskState>(command.dto.Status, true, out status))
            {
                return null;
            }

            task.Title = command.dto.Title;
            task.Description = command.dto.Description;
            task.DueAt = command.dto.DueAt;
            task.Status = status;

            var tags = new List<Tag>();
            Tag dbTag;
            foreach (var tag in command.dto.Tags)
            {
                dbTag = await _unitOfWork.TagRepository.GetByIdAsync(tag.Id);
                if (dbTag != null)
                {
                    tags.Add(dbTag);
                }
            }

            task.Tags = tags;


            _unitOfWork.TodoTaskRepository.Update(task);
            await _unitOfWork.SaveChangesAsync();

            var result = new TodoTaskResponceDto()
            {
                Id = task.Id,
                ListId = task.ListId,
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

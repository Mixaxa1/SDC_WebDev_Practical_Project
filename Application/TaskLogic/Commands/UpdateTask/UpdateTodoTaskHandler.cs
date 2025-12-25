using Application.TaskLogic.ResponceDto;
using MediatR;
using Domain.Entities.Task;
using Application.Abstraction.Repositories;

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
            var task = await _unitOfWork.TodoTaskRepository.GetByIdAsync(command.dto.Id);

            TaskState status;
            if (task == null || Enum.TryParse<TaskState>(command.dto.Status, true, out status))
            {
                return null;
            }

            task.Title = command.dto.Title;
            task.Description = command.dto.Description;
            task.DueAt = command.dto.DueAt;
            task.Status = status;

            _unitOfWork.TodoTaskRepository.Update(task);
            await _unitOfWork.SaveChangesAsync();

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

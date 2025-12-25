using Application.Abstraction.Repositories;
using Application.ListLogic.ResponseDto;
using Application.TaskLogic.ResponceDto;
using MediatR;

namespace Application.ListLogic.Commands.UpdateList
{
    public class UpdateTodoListHandler : IRequestHandler<UpdateTodoListCommand, TodoListResponceDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateTodoListHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<TodoListResponceDto?> Handle(UpdateTodoListCommand request, CancellationToken cancellationToken) 
        {
            var list = await _unitOfWork.TodoListRepository.GetByIdAsync(request.dto.Id);

            if (list == null)
            {
                return null;
            }

            list.Title = request.dto.Title;
            list.Description = request.dto.Description;

            _unitOfWork.TodoListRepository.Update(list);
            await _unitOfWork.SaveChangesAsync();

            var result = new TodoListResponceDto()
            {
                Id = list.Id,
                Title = list.Title,
                Description = list.Description,
                Tasks = new List<TodoTaskResponceDto>()
            };

            if (list.Tasks != null)
            {
                foreach (var task in list.Tasks)
                {
                    result.Tasks.Add(new TodoTaskResponceDto()
                    {
                        Id = task.Id,
                        ListId = task.ListId,
                        Title = task.Title,
                        Description = task.Description,
                        CreatedAt = task.CreatedAt,
                        DueAt = task.DueAt,
                        Status = task.Status.ToString(),
                    });
                }
            }

            return result;
        }
    }
}

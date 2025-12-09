using Application.ListLogic.ResponseDto;
using Application.TaskLogic.ResponceDto;
using Database;
using Database.EntityServices.Interfaces;
using MediatR;

namespace Application.ListLogic.Commands.UpdateList
{
    public class UpdateTodoListHandler : IRequestHandler<UpdateTodoListCommand, TodoListResponceDto>
    {
        private readonly ITodoListDbService _todoListService;
        private readonly AppDbContext _dbContext;

        public UpdateTodoListHandler(ITodoListDbService todoListService, AppDbContext dbContext)
        {
            _todoListService = todoListService;
            _dbContext = dbContext;
        }

        public async Task<TodoListResponceDto?> Handle(UpdateTodoListCommand request, CancellationToken cancellationToken) 
        {
            var list = await _todoListService.GetByIdAsync(request.dto.Id);

            if (list == null)
            {
                return null;
            }

            list.Title = request.dto.Title;
            list.Description = request.dto.Description;

            _todoListService.Update(list);
            _dbContext.SaveChanges();

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

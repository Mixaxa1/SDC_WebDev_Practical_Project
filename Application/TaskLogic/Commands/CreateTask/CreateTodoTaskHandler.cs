using Application.TaskLogic.ResponceDto;
using Database;
using Database.EntityServices;
using Database.EntityServices.Interfaces;
using Domain.Entities.Task;
using MediatR;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Application.TaskLogic.Commands.CreateTask
{
    public class CreateTodoTaskHandler : IRequestHandler<CreateTodoTaskCommand, TodoTaskResponceDto?>
    {
        private readonly ITodoListDbService _todoListDbService;
        private readonly ITodoTaskDbService _todoTaskService;
        private readonly AppDbContext _dbContext;

        public CreateTodoTaskHandler(ITodoListDbService todoListDbService, ITodoTaskDbService todoTaskService, AppDbContext dbContext)
        {
            _todoListDbService = todoListDbService;
            _todoTaskService = todoTaskService;
            _dbContext = dbContext;
        }

        public async Task<TodoTaskResponceDto?> Handle(CreateTodoTaskCommand request, CancellationToken cancellationToken)
        {
            var list = await _todoListDbService.GetByIdAsync(request.dto.ListId);

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

            await _todoTaskService.CreateAsync(task);
            await _dbContext.SaveChangesAsync();

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

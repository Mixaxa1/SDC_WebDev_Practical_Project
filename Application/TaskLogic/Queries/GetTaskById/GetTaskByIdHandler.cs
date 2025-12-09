using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.TaskLogic.ResponceDto;
using Database.EntityServices.Interfaces;
using Database;
using MediatR;

namespace Application.TaskLogic.Queries.GetTaskById
{
    public class GetTaskByIdHandler : IRequestHandler<GetTaskByIdQuery, TodoTaskResponceDto?>
    {
        private readonly ITodoTaskDbService _todoTaskService;
        private readonly AppDbContext _dbContext;

        public GetTaskByIdHandler(ITodoTaskDbService todoTaskService, AppDbContext dbContext)
        {
            _todoTaskService = todoTaskService;
            _dbContext = dbContext;
        }

        public async Task<TodoTaskResponceDto?> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
        {
            var task = await _todoTaskService.GetByIdAsync(request.id);

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

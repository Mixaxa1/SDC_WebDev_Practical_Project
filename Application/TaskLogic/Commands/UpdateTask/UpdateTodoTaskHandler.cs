using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.TaskLogic.ResponceDto;
using Database.EntityServices.Interfaces;
using Database;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Domain.Entities.Task;

namespace Application.TaskLogic.Commands.UpdateTask
{
    public class UpdateTodoTaskHandler : IRequestHandler<UpdateTodoTaskCommand, TodoTaskResponceDto?>
    {
        private readonly ITodoTaskDbService _todoTaskService;
        private readonly AppDbContext _dbContext;

        public UpdateTodoTaskHandler(ITodoTaskDbService todoTaskService, AppDbContext dbContext)
        {
            _todoTaskService = todoTaskService;
            _dbContext = dbContext;
        }

        public async Task<TodoTaskResponceDto?> Handle(UpdateTodoTaskCommand command, CancellationToken cancellationToken)
        {
            var task = await _todoTaskService.GetByIdAsync(command.dto.Id);

            TaskState status;
            if (task == null || Enum.TryParse<TaskState>(command.dto.Status, true, out status))
            {
                return null;
            }

            task.Title = command.dto.Title;
            task.Description = command.dto.Description;
            task.DueAt = command.dto.DueAt;
            task.Status = status;

            _todoTaskService.Update(task);
            await _dbContext.SaveChangesAsync();

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

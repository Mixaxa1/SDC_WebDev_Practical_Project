using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.EntityServices.Interfaces;
using Database;
using MediatR;

namespace Application.TaskLogic.Commands.DeleteTask
{
    public class DeleteTodoTaskHandler : IRequestHandler<DeleteTodoTaskCommand> 
    {
        private readonly ITodoTaskDbService _todoTaskService;
        private readonly AppDbContext _dbContext;

        public DeleteTodoTaskHandler(ITodoTaskDbService todoTaskService, AppDbContext dbContext)
        {
            _todoTaskService = todoTaskService;
            _dbContext = dbContext;
        }

        public async Task Handle(DeleteTodoTaskCommand request, CancellationToken cancellationToken)
        {
            var task = await _todoTaskService.GetByIdAsync(request.id);

            if (task == null)
            {
                return;
            }

            _todoTaskService.Delete(task);
            _dbContext.SaveChanges();
        }
    }
}

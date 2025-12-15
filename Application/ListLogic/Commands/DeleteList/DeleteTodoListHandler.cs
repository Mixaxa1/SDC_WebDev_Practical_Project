using Database;
using Database.EntityServices.Interfaces;
using MediatR;

namespace Application.ListLogic.Commands.DeleteList
{
    public class DeleteTodoListHandler : IRequestHandler<DeleteTodoListCommand>
    {
        private ITodoListDbService _todoListService;
        private AppDbContext _DbContext;

        public DeleteTodoListHandler(ITodoListDbService todoListService, AppDbContext dbContext)
        {
            _todoListService = todoListService;
            _DbContext = dbContext;
        }

        public async Task Handle(DeleteTodoListCommand request, CancellationToken cancellationToken)
        {
            var list = await _todoListService.GetByIdAsync(request.Id);

            if (list == null)
            {
                return;
            }

            _todoListService.Delete(list);
            _DbContext.SaveChanges();
        }
    }
}

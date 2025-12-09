using Application.ListLogic.ResponseDto;
using Application.TaskLogic.ResponceDto;
using Database;
using Database.EntityServices.Interfaces;
using Domain.Entities.List;
using MediatR;

namespace Application.ListLogic.Queries.GetListById
{
    public class GetTodoListByIdHandler : IRequestHandler<GetTodoListByIdQuery, TodoListResponceDto?>
    {
        private readonly ITodoListDbService _todoListService;
        private readonly AppDbContext _appDbContext;

        public GetTodoListByIdHandler(ITodoListDbService todoListService, AppDbContext appDbContext)
        {
            _todoListService = todoListService;
            _appDbContext = appDbContext;
        }

        public async Task<TodoListResponceDto?> Handle(GetTodoListByIdQuery request, CancellationToken cancellationToken)
        {
            TodoList list;

            if (request.withIncludes)
            {
                list = await _todoListService.GetByIdWithIncludesAsync(request.id, x => x.Tasks);
            }
            else
            {
                list = await _todoListService.GetByIdAsync(request.id);
            }

            if (list == null)
            {
                return null;
            }

            var result = new TodoListResponceDto()
            {
                Id = list.Id,
                Title = list.Title,
                Description = list.Description,
                Tasks = new List<TodoTaskResponceDto>()
            };

            if (request.withIncludes)
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

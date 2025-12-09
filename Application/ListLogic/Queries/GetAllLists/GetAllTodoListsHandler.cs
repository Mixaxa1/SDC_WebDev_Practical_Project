using Application.ListLogic.ResponseDto;
using Database;
using Database.EntityServices.Interfaces;
using MediatR;

namespace Application.ListLogic.Queries.GetAllLists
{
    public class GetAllTodoListsHandler : IRequestHandler<GetAllTodoListsQuery, IEnumerable<TodoListResponceDto?>>
    {
        private readonly ITodoListDbService _todoListService;
        private readonly AppDbContext _appDbContext;

        public GetAllTodoListsHandler(ITodoListDbService todoListDbService, AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _todoListService = todoListDbService;
        }

        public async Task<IEnumerable<TodoListResponceDto?>> Handle(GetAllTodoListsQuery request, CancellationToken cancellationToken)
        {
            var lists = await _todoListService.GetAllAsync();

            var results = new List<TodoListResponceDto>();
            foreach (var list in lists)
            {
                results.Add(new TodoListResponceDto()
                {
                    Id = list.Id,
                    Title = list.Title,
                    Description = list.Description
                });
            }

            return results;
        }
    }
}

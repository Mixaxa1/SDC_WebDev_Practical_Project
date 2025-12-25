using Application.Abstraction.Repositories;
using Application.ListLogic.ResponseDto;
using MediatR;

namespace Application.ListLogic.Queries.GetAllLists
{
    public class GetAllTodoListsHandler : IRequestHandler<GetAllTodoListsQuery, IEnumerable<TodoListResponceDto?>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllTodoListsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<TodoListResponceDto?>> Handle(GetAllTodoListsQuery request, CancellationToken cancellationToken)
        {
            var lists = await _unitOfWork.TodoListRepository.GetAllAsync();

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

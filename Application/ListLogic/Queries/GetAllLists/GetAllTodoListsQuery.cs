using Application.ListLogic.ResponseDto;
using MediatR;

namespace Application.ListLogic.Queries.GetAllLists
{
    public record GetAllTodoListsQuery() : IRequest<IEnumerable<TodoListResponceDto?>>;
}

using Application.ListLogic.ResponseDto;
using MediatR;

namespace Application.ListLogic.Queries.GetListById
{
    public record GetTodoListByIdQuery(Guid id, bool withIncludes) : IRequest<TodoListResponceDto?>;
}

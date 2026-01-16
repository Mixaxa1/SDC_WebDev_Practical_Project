using Application.TaskLogic.RequestDto;
using Application.TaskLogic.ResponceDto;
using MediatR;

namespace Application.TaskLogic.Queries.GetBySearch
{
    public record GetTasksBySearchQuery(GetTodoTasksBySearchDto dto) : IRequest<List<TodoTaskResponceDto>>;
}

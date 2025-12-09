using Application.ListLogic.RequestDto;
using Application.ListLogic.ResponseDto;
using MediatR;

namespace Application.ListLogic.Commands.UpdateList
{
    public record UpdateTodoListCommand(CreateTodoListRequestDto dto) : IRequest<TodoListResponceDto>;
}

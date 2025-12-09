using Application.ListLogic.RequestDto;
using Application.ListLogic.ResponseDto;
using MediatR;

namespace Application.ListLogic.Commands.CreateList
{
    public record CreateTodoListCommand(CreateTodoListRequestDto dto) : IRequest<TodoListResponceDto?>;
}

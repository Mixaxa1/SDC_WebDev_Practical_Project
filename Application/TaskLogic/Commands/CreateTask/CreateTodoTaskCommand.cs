using Application.TaskLogic.RequestDto;
using Application.TaskLogic.ResponceDto;
using MediatR;

namespace Application.TaskLogic.Commands.CreateTask
{
    public record CreateTodoTaskCommand(CreateTodoTaskRequestDto dto) : IRequest<TodoTaskResponceDto?>;
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.TaskLogic.RequestDto;
using Application.TaskLogic.ResponceDto;
using MediatR;

namespace Application.TaskLogic.Commands.UpdateTask
{
    public record UpdateTodoTaskCommand(CreateTodoTaskRequestDto dto) : IRequest<TodoTaskResponceDto?>;
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Application.TaskLogic.Commands.DeleteTask
{
    public record DeleteTodoTaskCommand(Guid id) : IRequest;
}

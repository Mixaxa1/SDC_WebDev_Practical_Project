using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.TaskLogic.ResponceDto;
using MediatR;

namespace Application.TaskLogic.Queries.GetTaskById
{
    public record GetTaskByIdQuery(Guid id) : IRequest<TodoTaskResponceDto?>;
}

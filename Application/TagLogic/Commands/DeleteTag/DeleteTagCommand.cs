using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Application.TagLogic.Commands.DeleteTag
{
    public record DeleteTagCommand(Guid id) : IRequest;
}

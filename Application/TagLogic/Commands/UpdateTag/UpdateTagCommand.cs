using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.TagLogic.RequestDto;
using Application.TagLogic.ResponceDto;
using MediatR;

namespace Application.TagLogic.Commands.UpdateTag
{
    public record UpdateTagCommand(TagRequestDto dto) : IRequest<TagResponceDto?>;
}

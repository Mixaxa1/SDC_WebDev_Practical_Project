using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.TagLogic.ResponceDto;
using MediatR;

namespace Application.TagLogic.Queris.GetAllTags
{
    public record GetAllTagsQuery() : IRequest<IEnumerable<TagResponceDto>>;
}

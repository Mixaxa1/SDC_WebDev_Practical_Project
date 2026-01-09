using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Application.TagLogic.ResponceDto;
using MediatR;

namespace Application.TagLogic.Queris.GetTagById
{
    public record GetTagByIdQuery(Guid id) : IRequest<TagResponceDto?>;
}

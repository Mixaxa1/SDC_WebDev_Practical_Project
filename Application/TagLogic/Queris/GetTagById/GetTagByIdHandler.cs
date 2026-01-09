using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Abstraction.Repositories;
using Application.TagLogic.ResponceDto;
using Domain.Entities.Tags;
using MediatR;

namespace Application.TagLogic.Queris.GetTagById
{
    public class GetTagByIdHandler : IRequestHandler<GetTagByIdQuery, TagResponceDto?>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTagByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<TagResponceDto?> Handle(GetTagByIdQuery request, CancellationToken cancellationToken)
        {
            var tag = await _unitOfWork.TagRepository.GetByIdAsync(request.id);

            if (tag == null)
            {
                return null;
            }

            return new TagResponceDto
            {
                Id = tag.Id,
                Title = tag.Title,
            };
        }
    }
}

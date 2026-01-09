using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Abstraction.Repositories;
using Application.TagLogic.ResponceDto;
using MediatR;

namespace Application.TagLogic.Queris.GetAllTags
{
    public class GetAllTagsHandler : IRequestHandler<GetAllTagsQuery, IEnumerable<TagResponceDto?>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllTagsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<TagResponceDto?>> Handle(GetAllTagsQuery request, CancellationToken cancellationToken)
        {
            var tags = await _unitOfWork.TagRepository.GetAllAsync();

            var results = new List<TagResponceDto>();
            foreach (var tag in tags)
            {
                results.Add(new TagResponceDto()
                {
                    Id = tag.Id,
                    Title = tag.Title,
                });
            }

            return results;
        }
    }
}

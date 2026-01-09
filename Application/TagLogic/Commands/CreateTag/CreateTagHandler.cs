using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Abstraction.Repositories;
using Application.TagLogic.ResponceDto;
using Domain.Entities.Tags;
using MediatR;

namespace Application.TagLogic.Commands.CreateTag
{
    public class CreateTagHandler : IRequestHandler<CreateTagCommand, TagResponceDto?>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateTagHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<TagResponceDto?> Handle(CreateTagCommand command, CancellationToken cancellationToken)
        {
            var tag = new Tag() { Id = Guid.NewGuid(), Title = command.dto.Title };

            await _unitOfWork.TagRepository.CreateAsync(tag);
            await _unitOfWork.SaveChangesAsync();

            return new TagResponceDto()
            {
                Id = tag.Id,
                Title = tag.Title,
            };
        }
    }
}

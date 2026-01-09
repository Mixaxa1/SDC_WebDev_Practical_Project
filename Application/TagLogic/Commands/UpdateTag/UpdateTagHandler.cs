using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Abstraction.Repositories;
using Application.TagLogic.ResponceDto;
using MediatR;

namespace Application.TagLogic.Commands.UpdateTag
{
    public class UpdateTagHandler : IRequestHandler<UpdateTagCommand, TagResponceDto?>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateTagHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<TagResponceDto?> Handle(UpdateTagCommand request, CancellationToken cancellationToken)
        {
            var tag = await _unitOfWork.TagRepository.GetByIdAsync(request.dto.Id);

            if (tag == null)
            {
                return null;
            }

            tag.Title = request.dto.Title;

            _unitOfWork.TagRepository.Update(tag);
            await _unitOfWork.SaveChangesAsync();

            var result = new TagResponceDto()
            {
                Id = request.dto.Id,
                Title = request.dto.Title,
            };

            return result;
        } 
    }
}

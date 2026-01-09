using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Abstraction.Repositories;
using MediatR;

namespace Application.TagLogic.Commands.DeleteTag
{
    public class DeleteTagHandler : IRequestHandler<DeleteTagCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTagHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteTagCommand command, CancellationToken cancellationToken)
        {
            var tag = await _unitOfWork.TagRepository.GetByIdAsync(command.id);

            if (tag == null)
            {
                return;
            }

            _unitOfWork.TagRepository.Delete(tag);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}

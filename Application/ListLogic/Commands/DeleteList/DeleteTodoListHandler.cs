using Application.Abstraction.Repositories;
using MediatR;

namespace Application.ListLogic.Commands.DeleteList
{
    public class DeleteTodoListHandler : IRequestHandler<DeleteTodoListCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTodoListHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteTodoListCommand request, CancellationToken cancellationToken)
        {
            var list = await _unitOfWork.TodoListRepository.GetByIdAsync(request.Id);

            if (list == null)
            {
                return;
            }

            _unitOfWork.TodoListRepository.Delete(list);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}

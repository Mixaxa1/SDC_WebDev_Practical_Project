using Application.Abstraction.Repositories;
using MediatR;

namespace Application.TaskLogic.Commands.DeleteTask
{
    public class DeleteTodoTaskHandler : IRequestHandler<DeleteTodoTaskCommand> 
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTodoTaskHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteTodoTaskCommand request, CancellationToken cancellationToken)
        {
            var task = await _unitOfWork.TodoTaskRepository.GetByIdAsync(request.id);

            if (task == null)
            {
                return;
            }

            _unitOfWork.TodoTaskRepository.Delete(task);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}

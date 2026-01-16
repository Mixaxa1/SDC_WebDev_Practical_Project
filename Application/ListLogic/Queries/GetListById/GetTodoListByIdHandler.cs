using Application.Abstraction.Repositories;
using Application.ListLogic.ResponseDto;
using Application.TagLogic.ResponceDto;
using Application.TaskLogic.ResponceDto;
using Domain.Entities.List;
using MediatR;

namespace Application.ListLogic.Queries.GetListById
{
    public class GetTodoListByIdHandler : IRequestHandler<GetTodoListByIdQuery, TodoListResponceDto?>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTodoListByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<TodoListResponceDto?> Handle(GetTodoListByIdQuery request, CancellationToken cancellationToken)
        {
            TodoList? list;

            if (request.withIncludes)
            {
                list = await _unitOfWork.TodoListRepository.GetByIdWithTasksAndTagsAsync(request.id);
            }
            else
            {
                list = await _unitOfWork.TodoListRepository.GetByIdAsync(request.id);
            }

            if (list == null)
            {
                return null;
            }

            var result = new TodoListResponceDto()
            {
                Id = list.Id,
                Title = list.Title,
                Description = list.Description,
                Tasks = new List<TodoTaskResponceDto>()
            };

            if (request.withIncludes)
            {
                TodoTaskResponceDto resultTask;
                foreach (var task in list.Tasks)
                {
                    resultTask = new TodoTaskResponceDto()
                    {
                        Id = task.Id,
                        ListId = task.ListId,
                        Title = task.Title,
                        Description = task.Description,
                        CreatedAt = task.CreatedAt,
                        DueAt = task.DueAt,
                        Status = task.Status.ToString(),
                        Tags = new List<TagResponceDto>()
                    };

                    foreach (var tag in task.Tags)
                    {
                        resultTask.Tags.Add(new TagResponceDto()
                        {
                            Id = tag.Id,
                            Title = tag.Title
                        });
                    }

                    result.Tasks.Add(resultTask);
                }
            }

            return result;
        }
    }
}

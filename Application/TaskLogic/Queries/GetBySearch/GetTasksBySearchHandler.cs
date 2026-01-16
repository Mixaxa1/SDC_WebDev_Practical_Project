using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Application.Abstraction.Repositories;
using Application.TagLogic.ResponceDto;
using Application.TaskLogic.ResponceDto;
using Domain.Entities.Task;
using LinqKit;
using MediatR;

namespace Application.TaskLogic.Queries.GetBySearch
{
    public class GetTasksBySearchHandler : IRequestHandler<GetTasksBySearchQuery, List<TodoTaskResponceDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTasksBySearchHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<TodoTaskResponceDto>> Handle(GetTasksBySearchQuery request, CancellationToken cancellationToken)
        {
            var dto = request.dto;

            var exp = PredicateBuilder.New<TodoTask>(true);

            if (dto.Title != null)
            {
                exp.And(x => x.Title.ToLower().Contains(dto.Title.ToLower()));
            }
            if (dto.TagId != null)
            {
                exp.And(x => x.Tags.Any(x => x.Id == dto.TagId));
            }
            if (dto.CreatedAfter != null)
            {
                exp.And(x => x.CreatedAt >= dto.CreatedAfter);
            }
            if (dto.CreatedBefore != null)
            {
                exp.And(x => x.CreatedAt <= dto.CreatedBefore);
            }
            if (dto.DueAfter != null)
            {
                exp.And(x => x.DueAt >= dto.DueAfter);
            }
            if (dto.DueBefore != null)
            {
                exp.And(x => x.DueAt <= dto.DueBefore);
            }

            var tasks = _unitOfWork.TodoTaskRepository.GetByExpWithIncludes(exp, x => x.Tags);
            var result = new List<TodoTaskResponceDto>();

            TodoTaskResponceDto taskDto;
            foreach (var task in tasks)
            {
                taskDto = new TodoTaskResponceDto()
                {
                    Id = task.Id,
                    ListId = task.ListId,
                    Title = task.Title,
                    Description = task.Description,
                    CreatedAt = task.CreatedAt,
                    DueAt = task.DueAt,
                    Status = task.Status.ToString(),
                };

                foreach (var tag in task.Tags)
                {
                    taskDto.Tags.Add(new TagResponceDto()
                    {
                        Id = tag.Id,
                        Title = tag.Title
                    });
                }

                result.Add(taskDto);
            }

            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstraction.Repositories
{
    public interface IUnitOfWork
    {
        ITodoListRepository TodoListRepository { get; }
        ITodoTaskRepository TodoTaskRepository { get; }
        ITagRepository TagRepository { get; }

        public Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}

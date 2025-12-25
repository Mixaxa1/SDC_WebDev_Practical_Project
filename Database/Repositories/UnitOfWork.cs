using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Abstraction.Repositories;

namespace Database.Repositories
{
    public class UnitOfWork(
        AppDbContext dbContext,
        ITodoListRepository todoListRepository,
        ITodoTaskRepository todoTaskRepository
        ) : IUnitOfWork
    {
        public ITodoListRepository TodoListRepository => todoListRepository;

        public ITodoTaskRepository TodoTaskRepository => todoTaskRepository;

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}

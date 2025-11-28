using Database.EntityServices.Interfaces;
using Domain.Entities.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.EntityServices
{
    public class TodoTaskDbService(AppDbContext dbContext) : EntityDbService<TodoTask>(dbContext), ITodoTaskDbService
    {

    }
}

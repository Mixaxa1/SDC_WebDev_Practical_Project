using Domain.Entities.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.EntityServices.Interfaces;

public interface ITodoTaskDbService : IEntityDbService<TodoTask>
{
}
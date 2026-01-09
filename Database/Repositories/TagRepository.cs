using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Abstraction.Repositories;
using Domain.Entities.Tags;

namespace Database.Repositories
{
    public class TagRepository(AppDbContext dbContext) : Repository<Tag>(dbContext), ITagRepository
    {
    }
}

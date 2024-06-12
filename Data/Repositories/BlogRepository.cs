using Infrastructure.Commons.Concrets;
using Infrastructure.Entities;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class BlogRepository : Repository<Blog>, IBlogRepositories
    {
        public BlogRepository(DbContext db) : base(db)
        {
        }
    }
}

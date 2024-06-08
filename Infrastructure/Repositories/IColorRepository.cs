using Infrastructure.Commons.Abstracts;
using Infrastructure.Commons.Concrets;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{

    public interface IColorRepository:IRepository<Color>
    {

    }
}

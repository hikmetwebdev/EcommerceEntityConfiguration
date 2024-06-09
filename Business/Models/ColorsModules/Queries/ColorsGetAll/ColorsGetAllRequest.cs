using Infrastructure.Entities;
using Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models.ColorsModules.Queries.ColorsGetAll
{
    public class ColorsGetAllRequest:IRequest<IEnumerable<Color>>
    {
    }

    
}

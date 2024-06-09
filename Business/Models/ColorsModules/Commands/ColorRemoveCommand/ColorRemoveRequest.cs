using Infrastructure.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models.ColorsModules.Commands.ColorRemoveCommand
{
    public class ColorRemoveRequest:IRequest<IEnumerable<Color>>
    {
        public int Id { get; set; }
    }
}

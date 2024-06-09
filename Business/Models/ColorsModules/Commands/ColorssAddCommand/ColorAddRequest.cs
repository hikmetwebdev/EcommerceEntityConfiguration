using Infrastructure.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models.ColorsModules.Commands.ColorssAddCommand
{
    public class ColorAddRequest:IRequest<Color>
    {
        public string Name { get; set; }
        public string HexCode { get; set; }
    }
}

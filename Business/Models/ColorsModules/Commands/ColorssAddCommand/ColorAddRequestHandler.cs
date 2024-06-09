using Infrastructure.Entities;
using Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models.ColorsModules.Commands.ColorssAddCommand
{
    public class ColorAddRequestHandler : IRequestHandler<ColorAddRequest, Color>
    {
        private readonly IColorRepository _colorRepository;

        public ColorAddRequestHandler(IColorRepository colorRepository)
        {
            _colorRepository = colorRepository;
        }

        public async Task<Color> Handle(ColorAddRequest request, CancellationToken cancellationToken)
        {
            var color = new Color
            {
                Name = request.Name,
                HexCode = request.HexCode,
            };
            _colorRepository.Add(color);
            return color;
        }
    }
}

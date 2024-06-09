using Infrastructure.Commons.Abstracts;
using Infrastructure.Entities;
using Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models.ColorsModules.Commands.ColorEditCommand
{
    public class ColorEditRequestHandler : IRequestHandler<ColorEditRequest, Color>
    {
        private readonly IColorRepository _colorRepository;

        public ColorEditRequestHandler(IColorRepository colorRepository)
        {
            _colorRepository = colorRepository;
        }

        public async Task<Color> Handle(ColorEditRequest request, CancellationToken cancellationToken)
        {
            var color = new Color()
            {
                Id = request.Id,
                Name = request.Name,
                HexCode = request.HexCode,
            };

            _colorRepository.Edit(color);

            return color;
        }
    }
}

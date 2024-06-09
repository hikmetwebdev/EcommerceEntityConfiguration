using Infrastructure.Entities;
using Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models.ColorsModules.Commands.ColorRemoveCommand
{
    public class ColorRemoveRequestHandler : IRequestHandler<ColorRemoveRequest, IEnumerable<Color>>
    {
        private readonly IColorRepository _colorRepository;

        public ColorRemoveRequestHandler(IColorRepository colorRepository)
        {
            _colorRepository = colorRepository;
        }

        public async Task<IEnumerable<Color>> Handle(ColorRemoveRequest request, CancellationToken cancellationToken)
        {
            var color = _colorRepository.Get(x => x.Id == request.Id && x.DeletedBy == null);
            _colorRepository.Remove(color);

            var colors = _colorRepository.GetAll(x => x.DeletedBy == null);
            return colors;
        }
    }
}

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
    public class ColorsGetAllRequestHandler : IRequestHandler<ColorsGetAllRequest, IEnumerable<Color>>
    {
        private readonly IColorRepository _colorRepository;

        public ColorsGetAllRequestHandler(IColorRepository colorRepository)
        {
            this._colorRepository = colorRepository;
        }

        public async Task<IEnumerable<Color>> Handle(ColorsGetAllRequest request, CancellationToken cancellationToken)
        {
            var colors = _colorRepository.GetAll(x => x.DeletedBy == null);
            return colors;
        }
    }
}

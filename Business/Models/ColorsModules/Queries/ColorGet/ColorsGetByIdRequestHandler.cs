using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Entities;
using Infrastructure.Repositories;
using MediatR;



namespace Business.Models.ColorsModules.Queries.ColorGet
{
    public class ColorsGetByIdRequestHandler : IRequestHandler<ColorsGetByIdRequest, Color>
    {
        private readonly IColorRepository _colorRepository;

        public ColorsGetByIdRequestHandler(IColorRepository colorRepository)
        {
            _colorRepository = colorRepository;
        }

        public async Task<Color> Handle(ColorsGetByIdRequest request, CancellationToken cancellationToken)
        {
          return  _colorRepository.Get(x => x.Id == request.Id && x.DeletedBy == null);
        }
    }
}

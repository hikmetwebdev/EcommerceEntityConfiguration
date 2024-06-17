using Infrastructure.Entities;
using Infrastructure.Repositories;
using MediatR;
using NuGet.Protocol.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models.BlogModules.Queries
{
    internal class BlogGetAllRequestHandler : IRequestHandler<BlogGetAllRequest, IEnumerable<BlogGetAllDTO>>
    {
        private readonly IBlogRepositories _repo;
        private readonly ICategoryRepository _catRepo;

        public BlogGetAllRequestHandler(IBlogRepositories repo, ICategoryRepository catRepo)
        {
            _repo = repo;
            _catRepo = catRepo;
        }

        public async Task<IEnumerable<BlogGetAllDTO>> Handle(BlogGetAllRequest request, CancellationToken cancellationToken)
        {
            var data = from bp in _repo.GetAll(b => b.DeletedBy == null)
                       join ct in _catRepo.GetAll() on bp.BlogCategoryId equals ct.Id
                       select new BlogGetAllDTO
                       {
                           Id = bp.Id,
                           Description = bp.Description,
                           CategoryName = ct.Name,
                           ImageUrl = bp.ImageUrl,
                       };

            return data;
        }
    }
}

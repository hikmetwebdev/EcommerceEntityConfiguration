using BigonEcommerce.Data.DataAcces;
using Infrastructure.Entities;
using Infrastructure.Services.Interfaces;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BigonWeb.Areas.AdminArea.Controllers
{
    [Area(nameof(AdminArea))]
    public class BlogController : Controller
    {
        private readonly BigondbContext _context;
        private readonly IBlogRepositories _repo;
        private readonly IFileService _fileService;
        public BlogController(BigondbContext context, IWebHostEnvironment environment, IBlogRepositories repo, IFileService fileService)
        {
            _context = context;
            _repo = repo;
            _fileService = fileService;
        }

        public IActionResult Index()
        {
            var blogs = _repo.GetAll(x=>x.DeletedBy==null);
            return View(blogs);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Blog model,IFormFile file)
        {
            
            var blog = new Blog()
            {
                Name = model.Name,
                Description = model.Description,
                BlogCategoryId = 1,
                ImageUrl = await _fileService.UploadFileAsync(file),
                Slug = model.Name,
            };
            _repo.Add(blog);
            return View();
        }
   
    }
}

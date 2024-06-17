using BigonEcommerce.Data.DataAcces;
using Infrastructure.Entities;
using Infrastructure.Services.Interfaces;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MediatR;
using Business.Models.BlogModules.Queries;

namespace BigonWeb.Areas.AdminArea.Controllers
{
    [Area(nameof(AdminArea))]
    public class BlogController : Controller
    {
        private readonly BigondbContext _context;
        private readonly IBlogRepositories _repo;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IFileService _fileService;
        IMediator _mediatr;
        public BlogController(BigondbContext context, IWebHostEnvironment environment, IBlogRepositories repo, IFileService fileService, ICategoryRepository categoryRepository, IMediator mediatr)
        {
            _context = context;
            _repo = repo;
            _fileService = fileService;
            _categoryRepository = categoryRepository;
            _mediatr = mediatr;
        }

        public async Task<IActionResult> Index(BlogGetAllRequest request)
        {
            var response = await _mediatr.Send(request);
            return View(response);
        }

        public IActionResult Create()
        {
            var categories = _categoryRepository.GetAll(c => c.DeletedBy == null);

            ViewBag.Categories = new SelectList(categories, "Id", "Name");
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

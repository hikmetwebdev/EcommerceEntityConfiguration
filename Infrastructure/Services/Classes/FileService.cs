using Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.Classes
{
    public class FileService(IHostEnvironment hostEnvironment) : IFileService
    {
        private readonly IHostEnvironment _hostEnvironment = hostEnvironment;

        public async Task<string> UploadFileAsync(IFormFile filePath)
        {
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(filePath.FileName)}";
            var phsycialPath = Path.Combine(_hostEnvironment.ContentRootPath, "wwwroot", "uploads", "images", fileName);
            using FileStream stream = new(phsycialPath, FileMode.CreateNew, FileAccess.Write);
            await filePath.CopyToAsync(stream);
            return fileName;
        }
    }
}

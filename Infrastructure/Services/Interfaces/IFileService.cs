using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.Interfaces
{
    internal interface IFileService
    {
        Task<string> UploadFileAsync(IFormFile filePath);

    }
}

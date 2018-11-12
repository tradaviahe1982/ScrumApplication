using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ScrumApplication.Utilities
{
    public interface IFileService
    {
        Task<string> Save(IFormFile formFile, string folder);
        void Delete(string filePath);
    }
}

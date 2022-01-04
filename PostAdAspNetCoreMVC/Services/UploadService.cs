using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace PostAdAspNetCoreMVC.Services
{
    public class UploadService
    {
        private IWebHostEnvironment _webHostEnvironment;
        public UploadService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public string Upload(IFormFile file)
        {
            string fileName = Guid.NewGuid().ToString() + "-" + file.FileName;
            string path = Path.Combine(_webHostEnvironment.WebRootPath, "ads", fileName);
            Stream stream = File.Create(path);
            file.CopyTo(stream);
            stream.Close();
            return "ads/" + fileName;
        }
    }
}

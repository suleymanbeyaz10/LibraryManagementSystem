using Microsoft.AspNetCore.Http;
using System;


namespace Core.Utilities.Uploaders
{
    public interface IFileUploader
    {
        string Upload(IFormFile file, string root);
        void Delete(string filePath);
        string Update(IFormFile file, string filePath, string root);
    }

}

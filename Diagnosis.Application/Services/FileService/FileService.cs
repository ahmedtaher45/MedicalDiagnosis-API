using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Application.Services.FileService
{
    public class FileService : IFileService
    {
        private readonly string _templateFolderPath;

        public static readonly string[] AllowedExtensions =
        { ".jpg", ".jpeg", ".png", ".pdf" };

        public static readonly long MaxSizeInBytes = 50 * 1024 * 1024; 
        public FileService(IWebHostEnvironment environment)
        {
            _templateFolderPath = Path.Combine(environment.ContentRootPath, "Template");

            if (!Directory.Exists(_templateFolderPath))
            {
                Directory.CreateDirectory(_templateFolderPath);
            }
        }
        public async Task<bool> DeleteFileAsync(string relativePath)
        {
            try
            {
                var fullPath = Path.Combine(_templateFolderPath, 
                                             Path.GetFileName(relativePath));

                if (File.Exists(fullPath))
                {
                    await Task.Run(() => File.Delete(fullPath));
                    return true;
                }
                return false;
            }
            catch 
            {
                return false;
            }
        }

        public async Task<byte[]> GetFileAsync(string relativePath)
        {
            var fullPath = Path.Combine(_templateFolderPath, Path.GetFileName(relativePath));

            if (!File.Exists(fullPath))
                throw new FileNotFoundException($"File not found: {relativePath}");

            return await File.ReadAllBytesAsync(fullPath);
        }

        public async Task<ICollection<byte[]>> GetMultipleFilesAsync(ICollection<string> relativePaths)
        {
            var files = new List<byte[]>();
            foreach (var pathItem in relativePaths)
            {
                var file = await GetFileAsync(pathItem);
                files.Add(file);
            }
            return files;
        }

        public bool IsValidFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return false;

            if (file.Length > MaxSizeInBytes)
                return false;

            var extension = Path.GetExtension(file.FileName).ToLowerInvariant();

            if (!AllowedExtensions.Contains(extension))
                return false;

            return true;
        }

        public async Task<string> UploadFileAsync(IFormFile file)
        {
            if (file == null || file.Length == 0) throw new ArgumentNullException("file is empty");

            var fileName = $"{Guid.NewGuid()}_{file.FileName}";

            var filePath = Path.Combine(_templateFolderPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return Path.Combine("Template", fileName);
        }

        public async Task<ICollection<string>> UploadMultipleFilesAsync(ICollection<IFormFile> files)
        {
            var filePaths = new List<string>();

            foreach (var file in files)
            {
                var path = await UploadFileAsync(file);
                filePaths.Add(path);
            }
            return filePaths;
        }
    }
}

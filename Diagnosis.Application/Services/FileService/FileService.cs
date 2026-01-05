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
            _templateFolderPath = Path.Combine(environment.WebRootPath, "uploads", "diagnosis");

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
            return $"uploads/diagnosis/{fileName}";
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

        public async Task<string> SaveBase64ImageAsync(string base64String, string? fileName = null)
        {
            try
            {
                var cleanBase64 = CleanBase64String(base64String!);

                byte[] imageBytes = Convert.FromBase64String(cleanBase64);

                var imageExtension = DetectImageExtension(imageBytes);

                fileName ??= $"{Guid.NewGuid()}{imageExtension}";
                var filePath = Path.Combine(_templateFolderPath, fileName);


                await File.WriteAllBytesAsync(filePath, imageBytes);

                return $"uploads/diagnosis/{fileName}";
            }
            catch (FormatException ex)
            {
                throw new ArgumentException("Invalid Base64 image data", ex);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private string CleanBase64String(string base64String)
        {
            if (string.IsNullOrWhiteSpace(base64String))
                throw new ArgumentException("Base64 string is null or empty");

            // ✅ إزالة data URI prefix
            if (base64String.Contains(","))
            {
                base64String = base64String.Split(',')[1];
            }

            // ✅ إزالة كل whitespace (مش بس trim)
            base64String = base64String
                .Replace("\r", "")
                .Replace("\n", "")
                .Replace(" ", "")
                .Replace("\t", "")
                .Trim();

            // ✅ Validate Base64 format
            if (!IsValidBase64String(base64String))
            {
                throw new ArgumentException("Invalid Base64 format");
            }

            return base64String;
        }

        private bool IsValidBase64String(string base64)
        {
            // Base64 length must be multiple of 4
            if (base64.Length % 4 != 0)
                return false;

            // Check for valid Base64 characters
            return System.Text.RegularExpressions.Regex.IsMatch(
                base64,
                @"^[a-zA-Z0-9\+/]*={0,2}$"
            );
        }
        private string DetectImageExtension(byte[] imageBytes)
        {
            if (imageBytes.Length < 4)
            {
                return ".jpg";
            }

            // PNG: 89 50 4E 47 0D 0A 1A 0A
            if (imageBytes[0] == 0x89 && imageBytes[1] == 0x50 &&
                imageBytes[2] == 0x4E && imageBytes[3] == 0x47)
                return ".png";

            // ✅ JPEG: FF D8 (أي byte بعدها تبدأ بـ FF)
            if (imageBytes[0] == 0xFF && imageBytes[1] == 0xD8)
            {
                // Most JPEGs have FF D8 FF
                // But some have FF D8 FF E0, FF D8 FF E1, FF D8 FF E2, etc.
                return ".jpg";
            }

            // GIF: 47 49 46 38
            if (imageBytes[0] == 0x47 && imageBytes[1] == 0x49 &&
                imageBytes[2] == 0x46 && imageBytes[3] == 0x38)
                return ".gif";

            // WebP: 52 49 46 46
            if (imageBytes[0] == 0x52 && imageBytes[1] == 0x49 &&
                imageBytes[2] == 0x46 && imageBytes[3] == 0x46)
            {
                // Verify WEBP at bytes 8-11
                if (imageBytes.Length >= 12 &&
                    imageBytes[8] == 0x57 && imageBytes[9] == 0x45 &&
                    imageBytes[10] == 0x42 && imageBytes[11] == 0x50)
                    return ".webp";
            }

            // BMP: 42 4D
            if (imageBytes[0] == 0x42 && imageBytes[1] == 0x4D)
                return ".bmp";

            return ".jpg";
        }
    }
}

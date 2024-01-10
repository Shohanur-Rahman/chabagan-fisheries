using Chabagan.Fisheries.Common.Models;
using Chabagan.Fisheries.WebApi.Services.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace Chabagan.Fisheries.WebApi.Services
{
    public class HelperService : IHelperService
    {
        public static IWebHostEnvironment _env;

        public HelperService(IWebHostEnvironment env)
        {
            _env = env;
        }
        public async Task<FileResponse?> UploadFileLocalyAndGetUrl(IFormFile? file, string? directoryName)
        {
            FileResponse vwFileResponse = new FileResponse();
            if (file != null)
            {
                string ftpDestination = (!string.IsNullOrEmpty(directoryName)) ? $"/File_Storage/Uploads/{directoryName}/" : $"/File_Storage/Uploads/";

                string fileName = $"{Guid.NewGuid().ToString()}_{file.FileName}";

                vwFileResponse.FileName = fileName;
                vwFileResponse.FilePath = $"{ftpDestination}{fileName}";
                vwFileResponse.FileSize = GetFileSizeString(file);
                vwFileResponse.FileType = Path.GetExtension(file.FileName);
                vwFileResponse.FileSizeInByte = file.Length;
                var p = $"{_env?.WebRootPath}/{ftpDestination}";

                if (!Directory.Exists($"{_env?.WebRootPath}/{ftpDestination}"))
                {
                    Directory.CreateDirectory($"{_env?.WebRootPath}/{ftpDestination}");

                }

                using (var stream = new FileStream($"{_env?.WebRootPath}/{ftpDestination}/{fileName.Trim()}", FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

            }
            return vwFileResponse;
        }

        public static string GetFileSizeString(IFormFile file)
        {
            if (file is not null)
            {

                long fileSizeInBytes = file.Length;

                // Convert to kilobytes (KB)
                double fileSizeInKB = fileSizeInBytes / 1024.0;

                // Convert to megabytes (MB)
                double fileSizeInMB = fileSizeInKB / 1024.0;

                // Convert to gigabytes (GB)
                double fileSizeInGB = fileSizeInMB / 1024.0;

                if (fileSizeInGB >= 1)
                {
                    return $"{fileSizeInGB:F3} GB";
                }
                else if (fileSizeInMB >= 1)
                {
                    return $"{fileSizeInMB:F3} MB";
                }
                else
                {
                    return $"{fileSizeInKB:F3} KB";
                }
            }
            return null!;
        }
        public void DeleteFile(string fileURL)
        {

            var path = _env?.WebRootPath + fileURL;
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        public string CreateHashPassword(string password)
        {
            string hashPassword = "";
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha256.ComputeHash(passwordBytes);
                hashPassword = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
            return hashPassword;
        }
    }
}

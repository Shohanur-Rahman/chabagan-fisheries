using Chabagan.Fisheries.Common.Models;

namespace Chabagan.Fisheries.WebApi.Services.Interfaces
{
    public interface IHelperService
    {
        Task<FileResponse?> UploadFileLocalyAndGetUrl(IFormFile? file, string? directoryName);
        void DeleteFile(string fileURL);
        string CreateHashPassword(string password);
    }
}

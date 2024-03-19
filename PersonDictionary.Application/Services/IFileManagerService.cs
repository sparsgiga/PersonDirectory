using Microsoft.AspNetCore.Http;

namespace PersonDirectory.Application.Services
{
    public interface IFileManagerService
    {
        Task<string> UploadFileAsync(IFormFile file);
        Task DeleteFileAsync(string filePath);
        Task<string> ReplaceFileAsync(IFormFile file, string existingFilePath);
        Task<byte[]> DownloadFileAsync(string filePath);
    }
}

using ANEFreeInIty_Server_API.Model.Dtos;

namespace ANEFreeInIty_Server_API.Services.Contracts;

public interface IDriveService
{
    FileDownloadDto DownloadFileService(string fileName);
    Task SaveFileServiceAsync(IFormFile file, int chunkIndex, string fileName);
}
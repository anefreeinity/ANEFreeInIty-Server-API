using ANEFreeInIty_Server_API.Extensions.Exceptions;
using ANEFreeInIty_Server_API.Model.Dtos;
using ANEFreeInIty_Server_API.Repositories.Contracts;
using ANEFreeInIty_Server_API.Services.Contracts;
using Microsoft.AspNetCore.StaticFiles;

namespace ANEFreeInIty_Server_API.Services;

public class DriveService : IDriveService
{
    private readonly IRepositoryManager _repository;

    public DriveService(IRepositoryManager repository)
    {
        _repository = repository;
    }

    public async Task SaveFileServiceAsync(IFormFile file, int chunkIndex, string fileName)
    {
        if (file == null || file.Length == 0)
        {
            throw new BadRequestException("No file uploaded.");
        }

        //Directory.GetCurrentDirectory()
        try
        {
            // var uploadPath = Path.Combine("/Users/ayanbhattacharya/Personal/Docker", "ANEFreeInIty-Server-API-Uploads", fileName);
            var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "ANEFreeInIty-Server-API-Uploads", fileName);


            var directory = Path.GetDirectoryName(uploadPath);
            if (directory != null && !Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            using (var stream = new FileStream(uploadPath, FileMode.Append))
            {
                await file.CopyToAsync(stream);
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public FileDownloadDto DownloadFileService(string fileName)
    {
        if (string.IsNullOrEmpty(fileName))
        {
            throw new BadRequestException("No file name provided.");
        }

        // var filePath = Path.Combine("/Users/ayanbhattacharya/Personal/Docker", "ANEFreeInIty-Server-API-Uploads", fileName);
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "ANEFreeInIty-Server-API-Uploads", fileName);


        if (!File.Exists(filePath))
        {
            throw new NotFoundException("File not found.");
        }

        try
        {
            var contentType = GetContentType(filePath);
            var fileBytes = File.ReadAllBytes(filePath);

            return new FileDownloadDto
            {
                ContentType = contentType,
                FileBytes = fileBytes,
                FileName = fileName
            };
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    private string GetContentType(string filePath)
    {
        var provider = new FileExtensionContentTypeProvider();

        if (!provider.TryGetContentType(filePath, out var contentType))
        {
            contentType = "application/octet-stream";
        }

        return contentType;
    }
}

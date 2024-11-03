namespace ANEFreeInIty_Server_API.Model.Dtos;

public class FileDownloadDto
{
    public string ContentType { get; set; } = string.Empty;
    public byte[] FileBytes { get; set; } = Array.Empty<byte>();
    public string FileName { get; set; } = string.Empty;
}

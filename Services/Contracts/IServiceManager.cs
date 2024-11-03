namespace ANEFreeInIty_Server_API.Services.Contracts;

public interface IServiceManager
{
    IMALService MALService { get; }
    IDriveService DriveService { get; }
}
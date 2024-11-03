using ANEFreeInIty_Server_API.Repositories.Contracts;
using ANEFreeInIty_Server_API.Services.Contracts;

namespace ANEFreeInIty_Server_API.Services;

public class ServiceManager : IServiceManager
{
    private readonly Lazy<IMALService> _malService;
    private readonly Lazy<IDriveService> _driveService;

    public IMALService MALService => _malService.Value;
    public IDriveService DriveService => _driveService.Value;

    public ServiceManager(IRepositoryManager repository)
    {
        _malService = new Lazy<IMALService>(() => new MALService(repository));
        _driveService = new Lazy<IDriveService>(() => new DriveService(repository));
    }
}

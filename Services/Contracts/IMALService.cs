namespace ANEFreeInIty_Server_API.Services.Contracts;

public interface IMALService
{
    Task<int> AddMALServiceAsync(MAL mal);
    Task<IEnumerable<MALResponse>> GetMALsServiceAsync();
    Task<MALResponse?> GetMALServiceByIdAsync(int id);
    Task UpdateMALServiceAsync(MAL mal);
    Task DeleteMALServiceAsync(int id);
}
namespace ANEFreeInIty_Server_API.Repositories.Contracts;

public interface IMALRepository : IRepositoryBase<MAL>
{
    Task<int> AddMALRepoAsync(MAL mal);
    Task<IEnumerable<MAL>> GetMALsRepoAsync();
    Task<MAL?> GetMALRepoByIdAsync(int id);
    Task UpdateMALRepoAsync(MAL mal);
    Task DeleteMALRepoAsync(int id);
}

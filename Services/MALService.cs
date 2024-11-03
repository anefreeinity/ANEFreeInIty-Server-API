using ANEFreeInIty_Server_API.Repositories.Contracts;
using ANEFreeInIty_Server_API.Services.Contracts;

namespace ANEFreeInIty_Server_API.Services;

public class MALService : IMALService
{
    private readonly IRepositoryManager _repository;

    public MALService(IRepositoryManager repository)
    {
        _repository = repository;
    }

    public async Task<int> AddMALServiceAsync(MAL mal)
    {
        return await _repository.MALRepository.AddMALRepoAsync(mal);
    }

    public async Task DeleteMALServiceAsync(int id)
    {
        await _repository.MALRepository.DeleteMALRepoAsync(id);
    }

    public async Task<MALResponse?> GetMALServiceByIdAsync(int id)
    {
        MAL? malentity = await _repository.MALRepository.GetMALRepoByIdAsync(id);
        if (malentity == null) return null;
        return new MALResponse
        {
            Id = malentity.Id,
            Name = malentity.Name,
            Genres = malentity.Genres,
            Year = malentity.Year
        };
    }

    public async Task<IEnumerable<MALResponse>> GetMALsServiceAsync()
    {
        List<MAL> malentities = (await _repository.MALRepository.GetMALsRepoAsync()).ToList();
        if (malentities == null || !malentities.Any()) return Enumerable.Empty<MALResponse>();

        return malentities.Select(mal => new MALResponse
        {
            Id = mal.Id,
            Name = mal.Name,
            Genres = mal.Genres,
            Year = mal.Year
        });
    }

    public async Task UpdateMALServiceAsync(MAL mal)
    {
        await _repository.MALRepository.UpdateMALRepoAsync(mal);
    }
}

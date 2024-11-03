using System.Data;
using ANEFreeInIty_Server_API.Repositories.Contracts;

namespace ANEFreeInIty_Server_API.Repositories;

public class MALRepository : RepositoryBase<MAL>, IMALRepository
{
    public MALRepository(IDbConnection dbConnection) : base(dbConnection) { }

    public async Task<int> AddMALRepoAsync(MAL mal)
    {
        var query = "INSERT INTO mal (name, genres, year) VALUES (@Name, @Genres, @Year) RETURNING id";
        return await ExecuteScalarAsync(query, mal);
    }

    public async Task DeleteMALRepoAsync(int id)
    {
        var query = "DELETE FROM mal WHERE id = @Id";
        await ExecuteAsync(query, new { Id = id });
    }

    public async Task<MAL?> GetMALRepoByIdAsync(int id)
    {
        var query = "SELECT * FROM mal WHERE id = @Id";
        return await QueryFirstOrDefaultAsync(query, new { Id = id });
    }

    public async Task<IEnumerable<MAL>> GetMALsRepoAsync()
    {
        var query = "SELECT * FROM mal";
        return await QueryAsync(query);
    }

    public async Task UpdateMALRepoAsync(MAL mal)
    {
        var query = "UPDATE mal SET name = @Name, genres = @Genres, year = @Year WHERE id = @Id";
        await ExecuteAsync(query, mal);
    }
}


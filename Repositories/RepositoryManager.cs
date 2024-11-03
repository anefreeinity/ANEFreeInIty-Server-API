using System.Data;
using ANEFreeInIty_Server_API.Repositories.Contracts;

namespace ANEFreeInIty_Server_API.Repositories;

public class RepositoryManager : IRepositoryManager
{
    private readonly IDbConnection _dbConnection;
    private readonly Lazy<IMALRepository> _malRepo;

    public RepositoryManager(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
        _malRepo = new Lazy<IMALRepository>(() => new MALRepository(_dbConnection));
    }

    public IMALRepository MALRepository => _malRepo.Value;
}

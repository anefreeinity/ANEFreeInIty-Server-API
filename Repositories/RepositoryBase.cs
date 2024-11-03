using System.Data;
using ANEFreeInIty_Server_API.Repositories.Contracts;
using Dapper;

namespace ANEFreeInIty_Server_API.Repositories;
public class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    private readonly IDbConnection _dbConnection;
    public RepositoryBase(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task ExecuteAsync(string query, object? parameters = null, IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null)
    {
        await _dbConnection.ExecuteAsync(query, parameters, transaction, commandTimeout, commandType);
    }

    public async Task<int> ExecuteScalarAsync(string query, object? parameters = null, IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null)
    {
        return await _dbConnection.ExecuteScalarAsync<int>(query, parameters, transaction, commandTimeout, commandType);
    }

    public async Task<IEnumerable<T>> QueryAsync(string query, object? parameters = null, IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null)
    {
        return await _dbConnection.QueryAsync<T>(query, parameters, transaction, commandTimeout, commandType);
    }

    public async Task<T?> QueryFirstOrDefaultAsync(string query, object? parameters = null, IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null)
    {
        return await _dbConnection.QueryFirstOrDefaultAsync<T>(query, parameters, transaction, commandTimeout, commandType);
    }
}

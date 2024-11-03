using System.Data;

namespace ANEFreeInIty_Server_API.Repositories.Contracts;

public interface IRepositoryBase<T>
{
    Task<IEnumerable<T>> QueryAsync(string query, object? parameters = null, IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null);
    Task<T?> QueryFirstOrDefaultAsync(string query, object? parameters = null, IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null);
    Task<int> ExecuteScalarAsync(string query, object? parameters = null, IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null);
    Task ExecuteAsync(string query, object? parameters = null, IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null);
}
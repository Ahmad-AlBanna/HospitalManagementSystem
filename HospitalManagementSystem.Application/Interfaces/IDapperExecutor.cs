using HospitalManagementSystem.Application.Common.Models;
using System.Data;

namespace HospitalManagementSystem.Application.Interfaces;

public interface IDapperExecutor
{
    Task<int> ExecuteAsync(
        string sql,
        object? parameters = null,
        CommandType commandType = CommandType.Text,
        CancellationToken cancellationToken = default);

    Task<T> ExecuteScalarAsync<T>(
        string sql,
        object? parameters = null,
        CommandType commandType = CommandType.Text,
        CancellationToken cancellationToken = default);

    Task<IEnumerable<T>> QueryAsync<T>(
        string sql,
        object? parameters = null,
        CommandType commandType = CommandType.Text,
        CancellationToken cancellationToken = default);

    Task<T?> QueryFirstOrDefaultAsync<T>(
        string sql,
        object? parameters = null,
        CommandType commandType = CommandType.Text,
        CancellationToken cancellationToken = default);

    Task<T?> QuerySingleOrDefaultAsync<T>(
        string sql,
        object? parameters = null,
        CommandType commandType = CommandType.Text,
        CancellationToken cancellationToken = default);

    Task<PagedResult<T>> QueryPagedAsync<T>(
        string sql,
        object parameters,
        int pageNumber,
        int pageSize,
        CancellationToken cancellationToken = default);

    Task<PagedResult<T>> ExecutePagedProcedureAsync<T>(
        string procedureName,
        object parameters,
        int pageNumber,
        int pageSize,
        CancellationToken cancellationToken = default);
}

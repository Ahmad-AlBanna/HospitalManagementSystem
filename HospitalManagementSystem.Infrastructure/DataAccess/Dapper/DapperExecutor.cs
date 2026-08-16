using Dapper;
using HospitalManagementSystem.Application.Common.Models;
using HospitalManagementSystem.Application.Interfaces;
using HospitalManagementSystem.Infrastructure.DataAccess.ConnectionFactory;
using System.Data;

namespace HospitalManagementSystem.Infrastructure.DataAccess;

public sealed class DapperExecutor : IDapperExecutor
{
    private readonly IConnectionFactory _connectionFactory;

    public DapperExecutor(IConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<int> ExecuteAsync(
        string sql,
        object? parameters = null,
        CommandType commandType = CommandType.Text,
        CancellationToken cancellationToken = default)
    {
        using var connection = _connectionFactory.CreateConnection();

        var command = new CommandDefinition(
            commandText: sql,
            parameters: parameters,
            commandType: commandType,
            cancellationToken: cancellationToken);

        return await connection.ExecuteAsync(command);
    }

    public async Task<T> ExecuteScalarAsync<T>(
        string sql,
        object? parameters = null,
        CommandType commandType = CommandType.Text,
        CancellationToken cancellationToken = default)
    {
        using var connection = _connectionFactory.CreateConnection();

        var command = new CommandDefinition(
            commandText: sql,
            parameters: parameters,
            commandType: commandType,
            cancellationToken: cancellationToken);

        return await connection.ExecuteScalarAsync<T>(command);
    }

    public async Task<IEnumerable<T>> QueryAsync<T>(
        string sql,
        object? parameters = null,
        CommandType commandType = CommandType.Text,
        CancellationToken cancellationToken = default)
    {
        using var connection = _connectionFactory.CreateConnection();

        var command = new CommandDefinition(
            commandText: sql,
            parameters: parameters,
            commandType: commandType,
            cancellationToken: cancellationToken);

        return await connection.QueryAsync<T>(command);
    }

    public async Task<T?> QueryFirstOrDefaultAsync<T>(
        string sql,
        object? parameters = null,
        CommandType commandType = CommandType.Text,
        CancellationToken cancellationToken = default)
    {
        using var connection = _connectionFactory.CreateConnection();

        var command = new CommandDefinition(
            commandText: sql,
            parameters: parameters,
            commandType: commandType,
            cancellationToken: cancellationToken);

        return await connection.QueryFirstOrDefaultAsync<T>(command);
    }

    public async Task<T?> QuerySingleOrDefaultAsync<T>(
        string sql,
        object? parameters = null,
        CommandType commandType = CommandType.Text,
        CancellationToken cancellationToken = default)
    {
        using var connection = _connectionFactory.CreateConnection();

        var command = new CommandDefinition(
            commandText: sql,
            parameters: parameters,
            commandType: commandType,
            cancellationToken: cancellationToken);

        return await connection.QuerySingleOrDefaultAsync<T>(command);
    }

    public async Task<PagedResult<T>> QueryPagedAsync<T>(
        string sql,
        object parameters,
        int pageNumber,
        int pageSize,
        CancellationToken cancellationToken = default)
    {
        using var connection = _connectionFactory.CreateConnection();

        var command = new CommandDefinition(
            commandText: sql,
            parameters: parameters,
            cancellationToken: cancellationToken);

        using var result = await connection.QueryMultipleAsync(command);

        var items = await result.ReadAsync<T>();
        var totalCount = await result.ReadSingleAsync<int>();

        return new PagedResult<T>
        {
            Items = items,
            PageNumber = pageNumber,
            PageSize = pageSize,
            TotalCount = totalCount
        };
    }

    public async Task<PagedResult<T>> ExecutePagedProcedureAsync<T>(
        string procedureName,
        object parameters,
        int pageNumber,
        int pageSize,
        CancellationToken cancellationToken = default)
    {
        using var connection = _connectionFactory.CreateConnection();

        var command = new CommandDefinition(
            commandText: procedureName,
            parameters: parameters,
            commandType: CommandType.StoredProcedure,
            cancellationToken: cancellationToken);

        using var result = await connection.QueryMultipleAsync(command);

        var items = await result.ReadAsync<T>();
        var totalCount = await result.ReadSingleAsync<int>();

        return new PagedResult<T>
        {
            Items = items,
            PageNumber = pageNumber,
            PageSize = pageSize,
            TotalCount = totalCount
        };
    }
}

namespace MajorVillage.Infraestructure.Dapper;

/// <summary>
/// Dapper repository app
/// </summary>
/// <typeparam name="T"></typeparam>
public class DapperRepository<T> : IDapperRepository<T> where T : class
{
    /// <summary>
    /// Mysql connection
    /// </summary>
    private readonly MySqlConnection _connection;
    /// <summary>
    /// Configuration Application
    /// </summary>
    private readonly IConfiguration _configuration;
    /// <summary>
    /// Logger application
    /// </summary>
    private readonly ILogger<DapperRepository<T>> _logger;

    /// <summary>
    /// Constructor Dapper 
    /// </summary>
    /// <param name="configuration">Configuration application</param>
    /// <param name="logger">Logger application</param>
    public DapperRepository(IConfiguration configuration,
                            ILogger<DapperRepository<T>> logger)
    {
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        _connection = new MySqlConnection(_configuration.GetConnectionString("mariadb")) ?? throw new InvalidOperationException("Do not connection dapper sqlclient");
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    /// <summary>
    /// Get by id async
    /// </summary>
    /// <param name="Id">Identifier entity</param>
    /// <param name="cancellationToken">cancellation token request</param>
    /// <returns>Get entity type <typeparamref name="T"/></returns>
    public async Task<T> GetByIdAsync(object Id, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        _logger.LogTrace("Get entity firstordefault by property {@Id}", Id);
        var result = _connection.Get<T>(id: Id, transaction: null, commandTimeout: null);
        await Task.Yield();
        return result;
    }
    /// <summary>
    /// Get all async entities
    /// </summary>
    /// <param name="predicate">Predicate specification</param>
    /// <param name="cancellationToken">cancellation token request</param>
    /// <returns>Return ienumerable entities type <typeparamref name="T"/></returns>
    public async Task<IEnumerable<T>> GetAllAsync(IPredicate predicate, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        _logger.LogTrace("GetList entities by predicate {@predicate}", predicate);
        var result = _connection.GetList<T>(predicate);
        await Task.Yield();
        return result;
    }

    /// <summary>
    /// Get count entities by specification predicate
    /// </summary>
    /// <param name="predicate">Predicate spefication</param>
    /// <param name="cancellationToken">cancellation token request</param>
    /// <returns>Return integer quantities</returns>
    public async Task<int> CountAsync(IPredicate predicate, CancellationToken cancellationToken)
    {
        var result = _connection.Count<T>(predicate);
        _logger.LogTrace("GetCount of {@counts}", result);
        cancellationToken.ThrowIfCancellationRequested();
        await Task.Yield();
        return result;
    }
    /// <summary>
    /// Get all specification async
    /// </summary>
    /// <param name="predicate">Predicate specification request</param>
    /// <param name="sort">Sort ienumerable list</param>
    /// <param name="cancellationToken">Cancellation token request</param>
    /// <returns>List entities type <typeparamref name="T"/></returns>
    public async Task<IEnumerable<T>> GetAllSpecificationAsync(IPredicate predicate, IList<ISort> sort, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        _logger.LogTrace("Get entities for especification {@predicate} {@sort}", predicate, sort);
        var result = _connection.GetList<T>(predicate, sort);
        await Task.Yield();
        return result;
    }

    /// <summary>
    /// Get multiple async
    /// </summary>
    /// <param name="predicate">Predicate specification</param>
    /// <param name="cancellationToken">Cancellation token request</param>
    /// <param name="transaction">IDb transaction</param>
    /// <param name="commandTimeout">timeout command</param>
    /// <returns>Get multiple list entities async</returns>
    public async Task<IMultipleResultReader> GetMultipleAsync(GetMultiplePredicate predicate, CancellationToken cancellationToken, IDbTransaction transaction = null, int commandTimeout = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        _logger.LogTrace("Get multiple result entities {@predicate}", predicate);
        var result = _connection.GetMultiple(predicate, transaction, commandTimeout);
        await Task.Yield();
        return result;
    }
    /// <summary>
    /// Insert entity
    /// </summary>
    /// <param name="entity">Entity type <typeparamref name="T"/></param>
    /// <param name="cancellationToken">Cancellation token request</param>
    /// <param name="transaction">IDb transaction</param>
    /// <param name="commandTimeout">Default time out </param>
    /// <returns>Boolean request</returns>
    public async Task<dynamic> InsertAsync(T entity, CancellationToken cancellationToken, IDbTransaction transaction = null, int commandTimeout = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        _logger.LogTrace("Insert entity {@entity}", entity);
        var result = _connection.Insert<T>(entity, transaction, commandTimeout);
        await Task.Yield();
        return result;
    }

    /// <summary>
    /// Inserts many entities 
    /// </summary>
    /// <param name="entities">IEnumerable entities</param>
    /// <param name="cancellationToken">Cancellation token request</param>
    /// <param name="transaction">Idb transaction</param>
    /// <param name="commandTimeout">Commando time out</param>
    /// <returns>Representation dynamic type <typeparamref name="T"/></returns>
    public async Task<dynamic> InsertsAsync(IEnumerable<T> entities, CancellationToken cancellationToken, IDbTransaction transaction = null, int commandTimeout = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        _logger.LogTrace("Inserts entities {@entities}", entities);
        var result = _connection.Insert<IEnumerable<T>>(entities, transaction, commandTimeout);
        await Task.Yield();
        return result;
    }

    /// <summary>
    /// Update entity 
    /// </summary>
    /// <param name="entity">Entity request</param>
    /// <param name="cancellationToken">Cancellation token request</param>
    /// <param name="transaction">Transaction db </param>
    /// <param name="commandTimeout">Command time out</param>
    /// <returns>Boolean request</returns>
    public async Task<bool> UpdateAsync(T entity, CancellationToken cancellationToken, IDbTransaction transaction = null, int commandTimeout = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        _logger.LogTrace("Update entity {@entity}", entity);
        var result = _connection.Update<T>(entity, transaction, commandTimeout);
        await Task.Yield();
        return result;
    }

    /// <summary>
    /// Delete async entity
    /// </summary>
    /// <param name="entity">Entity request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <param name="transaction">IdbTransaction</param>
    /// <param name="commandTimeout">Integer default timeout</param>
    /// <returns>Boolean request</returns>
    public async Task<bool> DeleteAsync(T entity, CancellationToken cancellationToken, IDbTransaction transaction = null, int commandTimeout = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        _logger.LogTrace("Delete entity {@entity}", entity);
        var result = _connection.Delete<T>(entity, transaction, commandTimeout);
        await Task.Yield();
        return result;
    }

    /// <summary>
    /// Raw request sql query string
    /// </summary>
    /// <param name="sql">query string reuqest</param>
    /// <param name="cancellationToken">Cancellation token request</param>
    /// <returns>List entities request <typeparamref name="T"/></returns>
    public async Task<IEnumerable<T>> RawSqlExecutionAsync(string sql, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        var result = await _connection.QueryAsync<T>(sql);
        await Task.Yield();
        return result;
    }

    /// <summary>
    /// Raw request async first or default result
    /// </summary>
    /// <param name="sql">query string request</param>
    /// <param name="cancellationToken">Cancellation token request</param>
    /// <returns>first or default type <typeparamref name="T"/></returns>
    public async Task<T> RawSqlExecutionFirstOrDefaultAsync(string sql, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        return await _connection.QueryFirstAsync<T>(sql);
    }
}

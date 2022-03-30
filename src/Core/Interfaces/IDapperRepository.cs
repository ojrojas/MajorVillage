namespace MajorVillage.Core.Interfaces;

/// <summary>
/// Dapper repository app
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IDapperRepository<T>
{
    /// <summary>
    /// Get count entities by specification predicate
    /// </summary>
    /// <param name="predicate">Predicate spefication</param>
    /// <param name="cancellationToken">cancellation token request</param>
    /// <returns>Return integer quantities</returns>
    Task<int> CountAsync(IPredicate predicate, CancellationToken cancellationToken);
    /// <summary>
    /// Delete async entity
    /// </summary>
    /// <param name="entity">Entity request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <param name="transaction">IdbTransaction</param>
    /// <param name="commandTimeout">Integer default timeout</param>
    /// <returns>Boolean request</returns>
    Task<bool> DeleteAsync(T entity, CancellationToken cancellationToken, IDbTransaction transaction = null, int commandTimeout = 0);
    /// <summary>
    /// Get all async entities
    /// </summary>
    /// <param name="predicate">Predicate specification</param>
    /// <param name="cancellationToken">cancellation token request</param>
    /// <returns>Return ienumerable entities type <typeparamref name="T"/></returns>
    Task<IEnumerable<T>> GetAllAsync(IPredicate predicate, CancellationToken cancellationToken);
    /// <summary>
    /// Get all specification async
    /// </summary>
    /// <param name="predicate">Predicate specification request</param>
    /// <param name="sort">Sort ienumerable list</param>
    /// <param name="cancellationToken">Cancellation token request</param>
    /// <returns>List entities type <typeparamref name="T"/></returns>
    Task<IEnumerable<T>> GetAllSpecificationAsync(IPredicate predicate, IList<ISort> sort, CancellationToken cancellationToken);
    /// <summary>
    /// Get by id async
    /// </summary>
    /// <param name="Id">Identifier entity</param>
    /// <param name="cancellationToken">cancellation token request</param>
    /// <returns>Get entity type <typeparamref name="T"/></returns>
    Task<T> GetByIdAsync(object Id, CancellationToken cancellationToken);
    /// <summary>
    /// Get multiple async
    /// </summary>
    /// <param name="predicate">Predicate specification</param>
    /// <param name="cancellationToken">Cancellation token request</param>
    /// <param name="transaction">IDb transaction</param>
    /// <param name="commandTimeout">timeout command</param>
    /// <returns>Get multiple list entities async</returns>
    Task<IMultipleResultReader> GetMultipleAsync(GetMultiplePredicate predicate, CancellationToken cancellationToken, IDbTransaction transaction = null, int commandTimeout = 0);
    /// <summary>
    /// Insert entity
    /// </summary>
    /// <param name="entity">Entity type <typeparamref name="T"/></param>
    /// <param name="cancellationToken">Cancellation token request</param>
    /// <param name="transaction">IDb transaction</param>
    /// <param name="commandTimeout">Default time out </param>
    /// <returns>Boolean request</returns>
    Task<Guid> InsertAsync(T entity, CancellationToken cancellationToken, IDbTransaction transaction = null, int commandTimeout = 0);
    /// <summary>
    /// Inserts many entities 
    /// </summary>
    /// <param name="entities">IEnumerable entities</param>
    /// <param name="cancellationToken">Cancellation token request</param>
    /// <param name="transaction">Idb transaction</param>
    /// <param name="commandTimeout">Commando time out</param>
    /// <returns>Representation dynamic type <typeparamref name="T"/></returns>
    Task<dynamic> InsertsAsync(IEnumerable<T> entities, CancellationToken cancellationToken, IDbTransaction transaction = null, int commandTimeout = 0);
    /// <summary>
    /// Raw request sql query string
    /// </summary>
    /// <param name="sql">query string reuqest</param>
    /// <param name="cancellationToken">Cancellation token request</param>
    /// <returns>List entities request <typeparamref name="T"/></returns>
    Task<IEnumerable<T>> RawSqlExecutionAsync(string sql, CancellationToken cancellationToken);
    /// <summary>
    /// Raw request async first or default result
    /// </summary>
    /// <param name="sql">query string request</param>
    /// <param name="cancellationToken">Cancellation token request</param>
    /// <returns>first or default type <typeparamref name="T"/></returns>
    Task<T> RawSqlExecutionFirstOrDefaultAsync(string sql, CancellationToken cancellationToken);
    /// <summary>
    /// Update entity 
    /// </summary>
    /// <param name="entity">Entity request</param>
    /// <param name="cancellationToken">Cancellation token request</param>
    /// <param name="transaction">Transaction db </param>
    /// <param name="commandTimeout">Command time out</param>
    /// <returns>Boolean request</returns>
    Task<bool> UpdateAsync(T entity, CancellationToken cancellationToken, IDbTransaction transaction = null, int commandTimeout = 0);
}
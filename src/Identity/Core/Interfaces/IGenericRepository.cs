namespace Core.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity, IAggregateRoot
    {
        /// <summary>
        /// Count async 
        /// </summary>
        /// <param name="cancellationToken">Cancellation token request</param>
        /// <returns>Entity type parameter <typeparamref name="T"/></returns>
        Task<int> CountAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Create async entity
        /// </summary>
        /// <param name="entity">entity model</param>
        /// <param name="cancellationToken">Cancellation token request</param>
        /// <returns>Entity type parameter <typeparamref name="T"/></returns>
        Task<T> CreateAsync(T entity, CancellationToken cancellationToken);

        /// <summary>
        /// Delete async entity
        /// </summary>
        /// <param name="entity">entity model</param>
        /// <param name="cancellationToken">Cancellation token request</param>
        /// <returns>Entity type parameter <typeparamref name="T"/></returns>
        Task<T> DeleteAsync(T entity, CancellationToken cancellationToken);

        /// <summary>
        /// Get async by id
        /// </summary>
        /// <param name="id">Guid id model</param>
        /// <param name="cancellationToken">Cancellation token request</param>
        /// <returns>Entity type parameter <typeparamref name="T"/></returns>
        Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// List enumerable items 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>list records type parameter <see cref="IEnumerable{T}"/></returns>
        Task<IEnumerable<T>> ListAsync(CancellationToken cancellationToken);

        /// <summary>
        /// List enumerable items 
        /// </summary>
        /// <param name="spec">Specified model return</param>
        /// <param name="cancellationToken"></param>
        /// <returns>list records type parameter <see cref="IEnumerable{T}"/></returns>
        Task<IEnumerable<T>> ListAsync(ISpecification<T> spec, CancellationToken cancellationToken);

        /// <summary>
        /// Update async entity
        /// </summary>
        /// <param name="entity">entity model</param>
        /// <param name="cancellationToken">Cancellation token request</param>
        /// <returns>Entity type parameter <typeparamref name="T"/></returns>
        Task<T> UpdateAsync(T entity, CancellationToken cancellationToken);

        /// <summary>
        /// Get first or default specification entity
        /// </summary>
        /// <param name="specification">Specification entity</param>
        /// <param name="cancellationToken">Cancellation token request</param>
        /// <returns>First entity found or default</returns>
        Task<T> FirstOrDefaultAsync(ISpecification<T> specification, CancellationToken cancellationToken);
    }
}

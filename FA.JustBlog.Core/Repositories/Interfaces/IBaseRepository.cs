using FA.JustBlog.Core.Models;
using System.Linq.Expressions;

namespace FA.JustBlog.Core.Repositories.Interfaces
{
    /// <summary>
    /// Represents the base repository interface for managing entities of type T.
    /// </summary>
    /// <typeparam name="T">The type of the entity.</typeparam>
    public interface IBaseRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// Retrieves a collection of entities with optional filtering, ordering, and inclusion of related properties.
        /// </summary>
        /// <param name="filter">An optional filter expression.</param>
        /// <param name="orderBy">An optional ordering function.</param>
        /// <param name="includeProps">Optional related properties to include.</param>
        /// <returns>A collection of entities that match the specified criteria.</returns>
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, params string[] includeProps);

        /// <summary>
        /// Retrieves an entity by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the entity.</param>
        /// <returns>The entity with the specified unique identifier, or null if not found.</returns>
        T? GetById(object id);

        /// <summary>
        /// Retrieves the first entity that matches the specified filter criteria.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <returns>The first entity that matches the specified filter criteria, or null if not found.</returns>
        T? FirstOrDefault(Expression<Func<T, bool>> filter);

        /// <summary>
        /// Retrieves the first entity that matches the specified filter criteria, including related properties.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <param name="includeProps">The related properties to include.</param>
        /// <returns>The first entity that matches the specified filter criteria, or null if not found.</returns>
        T? FirstOrDefaultInclude(Expression<Func<T, bool>> filter, params string[] includeProps);

        
        void Insert(T entity);

        /// <summary>
        /// Inserts multiple entities into the repository.
        /// </summary>
        /// <param name="entities">The entities to insert.</param>
        void Insert(params T[] entities);

        /// <summary>
        /// Updates an existing entity in the repository.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        void Update(T entity);

        /// <summary>
        /// Deletes an entity from the repository by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the entity to delete.</param>
        void Delete(object id);

        /// <summary>
        /// Deletes an entity from the repository.
        /// </summary>
        /// <param name="entity">The entity to delete.</param>
        void Delete(T entity);

        /// <summary>
        /// Saves changes made to the repository.
        /// </summary>
        void Save();
    }
}

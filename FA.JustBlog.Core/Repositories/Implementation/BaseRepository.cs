using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FA.JustBlog.Core.Repositories.Implementation
{
    /// <summary>
    /// Represents the base repository for entities.
    /// </summary>
    /// <typeparam name="T">The type of entity.</typeparam>
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        internal readonly DbSet<T> _dbSet;
        internal readonly JustBlogContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRepository{T}"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        public BaseRepository(JustBlogContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        /// <summary>
        /// Deletes an entity by its ID.
        /// </summary>
        /// <param name="id">The ID of the entity to delete.</param>
        public void Delete(object id)
        {
            T? entity = _dbSet.Find(id);
            if (entity != null)
            {
                entity.IsActive = false;
                entity.UpdatedAt = DateTime.Now;
                _context.Entry(entity).State = EntityState.Modified;
            }
        }

        /// <summary>
        /// Deletes an entity.
        /// </summary>
        /// <param name="entity">The entity to delete.</param>
        public void Delete(T entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            entity.IsActive = false;
            entity.UpdatedAt = DateTime.Now;
            _context.Entry(entity).State = EntityState.Modified;
        }

        /// <summary>
        /// Gets the first entity matching the specified filter.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <returns>The first matching entity.</returns>
        public T? FirstOrDefault(Expression<Func<T, bool>> filter)
        {
            return _dbSet.Where(t => t.IsActive == true).FirstOrDefault(filter);
        }

        /// <summary>
        /// Gets the first entity matching the specified filter and includes related properties.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <param name="includeProps">The related properties to include.</param>
        /// <returns>The first matching entity with included properties.</returns>
        public T? FirstOrDefaultInclude(Expression<Func<T, bool>> filter, params string[] includeProps)
        {
            var query = _dbSet.AsQueryable();
            if (includeProps.Length > 0)
            {
                foreach (var prop in includeProps)
                {
                    query = query.Include(prop);
                }
            }
            return query.FirstOrDefault(filter);
        }

        /// <summary>
        /// Gets all entities optionally filtered, ordered, and including related properties.
        /// </summary>
        /// <param name="filter">The optional filter expression.</param>
        /// <param name="orderBy">The optional order expression.</param>
        /// <param name="includeProps">The related properties to include.</param>
        /// <returns>The list of matching entities.</returns>
        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, params string[] includeProps)
        {
            IQueryable<T> query = _dbSet.Where(t => t.IsActive == true);
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (includeProps.Length > 0)
            {
                foreach (var prop in includeProps)
                {
                    query = query.Include(prop);
                }
            }
            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        /// <summary>
        /// Gets an entity by its ID.
        /// </summary>
        /// <param name="id">The ID of the entity to get.</param>
        /// <returns>The entity with the specified ID.</returns>
        public T? GetById(object id)
        {
            T? entity = _dbSet.Find(id);
            if (entity == null || entity.IsActive == false)
            {
                return null;
            }
            return entity;
        }

        /// <summary>
        /// Inserts a new entity.
        /// </summary>
        /// <param name="entity">The entity to insert.</param>
        public void Insert(T entity)
        {
            entity.InsertedAt = DateTime.Now;
            entity.UpdatedAt = DateTime.Now;
            _dbSet.Add(entity);
        }

        /// <summary>
        /// Inserts multiple entities.
        /// </summary>
        /// <param name="entities">The entities to insert.</param>
        public void Insert(params T[] entities)
        {
            for (int i = 0; i < entities.Length; i++)
            {
                _dbSet.Add(entities[i]);
            }
        }

        /// <summary>
        /// Saves changes to the database.
        /// </summary>
        public void Save()
        {
            _context.SaveChanges();
        }

        /// <summary>
        /// Updates an existing entity.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        public void Update(T entity)
        {
            entity.UpdatedAt = DateTime.Now;
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}

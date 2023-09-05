using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Repositories.Interfaces;

namespace FA.JustBlog.Core.Repositories.Implementation
{
    /// <summary>
    /// Represents a repository for managing <see cref="Category"/> entities.
    /// Inherits from the <see cref="BaseRepository{T}"/> class.
    /// Implements the <see cref="ICategoryRepository"/> interface.
    /// </summary>
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryRepository"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        public CategoryRepository(JustBlogContext context) : base(context)
        {
        }
    }
}

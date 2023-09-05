using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Repositories.Interfaces;

namespace FA.JustBlog.Core.Repositories
{
    /// <summary>
    /// Represents the interface for managing operations related to Tag entities.
    /// Inherits from the <see cref="IBaseRepository{T}"/> interface.
    /// </summary>
    public interface ITagRepository : IBaseRepository<Tag>
    {
        /// <summary>
        /// Retrieves a Tag entity based on its URL slug.
        /// </summary>
        /// <param name="urlSlug">The URL slug of the Tag entity to retrieve.</param>
        /// <returns>The Tag entity with the specified URL slug, or null if not found.</returns>
        Tag? GetTagByUrlSlug(string urlSlug);
    }
}

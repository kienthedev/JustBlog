using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Repositories.Implementation;

namespace FA.JustBlog.Core.Repositories
{
    /// <summary>
    /// TagRepository class.
    /// </summary>
    public class TagRepository : BaseRepository<Tag>, ITagRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TagRepository"/> class.
        /// </summary>
        public TagRepository(JustBlogContext context) : base(context)
        {
        }

        /// <summary>
        /// Get tag by url slug.
        /// </summary>
        /// <param name="urlSlug">url Slug.</param>
        /// <returns>Tag.</returns>
        public Tag GetTagByUrlSlug(string urlSlug)
        {
            return _dbSet.Where(t => t.UrlSlug == urlSlug).FirstOrDefault();
        }
    }
}

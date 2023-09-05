using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Repositories.Implementation;
using Microsoft.EntityFrameworkCore;

namespace FA.JustBlog.Core.Repositories
{
    /// <summary>
    /// Represents a repository for managing <see cref="Post"/> entities.
    /// Inherits from the <see cref="BaseRepository{T}"/> class.
    /// Implements the <see cref="IPostRepository"/> interface.
    /// </summary>
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PostRepository"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        public PostRepository(JustBlogContext context) : base(context)
        {
        }

        /// <summary>
        /// Finds a post using optional parameters such as year, month, and URL slug.
        /// </summary>
        /// <param name="year">The year of the post's publication.</param>
        /// <param name="month">The month of the post's publication.</param>
        /// <param name="urlSlug">The URL slug of the post.</param>
        /// <returns>The found post or null if not found.</returns>
        public Post? FindPost(int year = 0, int month = 0, string? urlSlug = null)
        {
            IQueryable<Post> query = _dbSet.Where(p => p.IsActive == true);
            if (year > 0 && month > 0)
            {
                query = query.Where(p => p.PostedOn.Year == year && p.PostedOn.Month == month);
            }
            if (!string.IsNullOrEmpty(urlSlug))
            {
                query = query.Where(p => p.UrlSlug == urlSlug);
            }
            return query.FirstOrDefault();
        }

        /// <summary>
        /// Retrieves a list of published posts.
        /// </summary>
        /// <returns>A list of published posts.</returns>
        public IList<Post> GetPublishedPosts()
        {
            return _dbSet.Where(p => p.Published == true && p.IsActive == true).ToList();
        }

        /// <summary>
        /// Retrieves a list of unpublished posts.
        /// </summary>
        /// <returns>A list of unpublished posts.</returns>
        public IList<Post> GetUnpublishedPosts()
        {
            return _dbSet.Where(p => p.Published == false && p.IsActive == true).ToList();
        }

        /// <summary>
        /// Retrieves a list of the latest posts.
        /// </summary>
        /// <param name="size">The number of posts to retrieve.</param>
        /// <returns>A list of the latest posts.</returns>
        public IList<Post> GetLastestPost(int size = 1)
        {
            return _dbSet.Where(p => p.IsActive == true).OrderByDescending(p => p.PostedOn).Take(size).ToList();
        }

        /// <summary>
        /// Retrieves a list of posts with the highest view counts.
        /// </summary>
        /// <param name="size">The number of posts to retrieve.</param>
        /// <returns>A list of posts with the highest view counts.</returns>
        public IList<Post> GetHighestPosts(int size = 1)
        {
            return _dbSet.Where(p => p.IsActive == true).OrderByDescending(p => p.ViewCount).Take(size).ToList();
        }

        /// <summary>
        /// Retrieves a list of the most viewed posts.
        /// </summary>
        /// <param name="size">The number of posts to retrieve.</param>
        /// <returns>A list of the most viewed posts.</returns>
        public IList<Post> GetMostViewedPost(int size = 1)
        {
            return _dbSet.Where(p => p.IsActive == true).Take(size).OrderByDescending(p => p.ViewCount).ToList();
        }

        /// <summary>
        /// Retrieves a list of posts by a specific category.
        /// </summary>
        /// <param name="categoryName">The name of the category.</param>
        /// <returns>A list of posts belonging to the specified category.</returns>
        public IList<Post> GetPostsByCategory(string categoryName)
        {
            return _dbSet.Where(p => p.Category.Name == categoryName && p.IsActive == true).Include(p => p.Category).ToList();
        }

        /// <summary>
        /// Retrieves a list of posts for a specific month and year.
        /// </summary>
        /// <param name="monthYear">The month and year.</param>
        /// <returns>A list of posts for the specified month and year.</returns>
        public IList<Post> GetPostsByMonth(DateTime monthYear)
        {
            return _dbSet.Where(p => p.PostedOn.Month == monthYear.Month && p.PostedOn.Year == monthYear.Year && p.IsActive == true).ToList();
        }

        /// <summary>
        /// Retrieves a list of posts containing a specific tag.
        /// </summary>
        /// <param name="tag">The tag to search for.</param>
        /// <returns>A list of posts containing the specified tag.</returns>
        public IList<Post> GetPostsByTag(string tag)
        {
            return _dbSet.Where(p => p.PostTagMaps.Any(pt => pt.Tag.Name == tag)).ToList();

        }

        /// <summary>
        /// Counts the number of posts in a specific category.
        /// </summary>
        /// <param name="categoryName">The name of the category.</param>
        /// <returns>The number of posts in the specified category.</returns>
        public int CountPostsForCategory(string categoryName)
        {
            return _dbSet.Where(p => p.Category.Name == categoryName && p.IsActive == true).Count();
        }

        /// <summary>
        /// Counts the number of posts containing a specific tag.
        /// </summary>
        /// <param name="tag">The tag to search for.</param>
        /// <returns>The number of posts containing the specified tag.</returns>
        public int CountPostsForTag(string tag)
        {
            return _context.Set<PostTagMap>().Count(pt => pt.Tag.Name == tag && pt.IsActive == true);
        }
    }
}

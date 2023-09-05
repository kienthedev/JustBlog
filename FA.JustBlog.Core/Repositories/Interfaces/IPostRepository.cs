using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FA.JustBlog.Core.Repositories
{
    /// <summary>
    /// Represents the interface for managing operations related to Post entities.
    /// Inherits from the <see cref="IBaseRepository{T}"/> interface.
    /// </summary>
    public interface IPostRepository : IBaseRepository<Post>
    {
        /// <summary>
        /// Finds a Post entity based on optional parameters such as year, month, and URL slug.
        /// </summary>
        /// <param name="year">The year of the Post's publication.</param>
        /// <param name="month">The month of the Post's publication.</param>
        /// <param name="urlSlug">The URL slug of the Post entity to find.</param>
        /// <returns>The matching Post entity, or null if not found.</returns>
        Post? FindPost(int year = 0, int month = 0, string? urlSlug = null);

        /// <summary>
        /// Retrieves a collection of published Post entities.
        /// </summary>
        /// <returns>A collection of published Post entities.</returns>
        IList<Post> GetPublishedPosts();

        /// <summary>
        /// Retrieves a collection of unpublished Post entities.
        /// </summary>
        /// <returns>A collection of unpublished Post entities.</returns>
        IList<Post> GetUnpublishedPosts();

        /// <summary>
        /// Retrieves a collection of the latest Post entities.
        /// </summary>
        /// <param name="size">The number of latest Post entities to retrieve.</param>
        /// <returns>A collection of the latest Post entities.</returns>
        IList<Post> GetLastestPost(int size = 1);

        /// <summary>
        /// Retrieves a collection of Post entities published in the specified month and year.
        /// </summary>
        /// <param name="monthYear">The month and year to filter by.</param>
        /// <returns>A collection of Post entities published in the specified month and year.</returns>
        IList<Post> GetPostsByMonth(DateTime monthYear);

        /// <summary>
        /// Retrieves a collection of the most viewed Post entities.
        /// </summary>
        /// <param name="size">The number of most viewed Post entities to retrieve.</param>
        /// <returns>A collection of the most viewed Post entities.</returns>
        IList<Post> GetMostViewedPost(int size = 1);

        /// <summary>
        /// Retrieves a collection of Post entities belonging to a specific category.
        /// </summary>
        /// <param name="categoryName">The name of the category to filter by.</param>
        /// <returns>A collection of Post entities belonging to the specified category.</returns>
        IList<Post> GetPostsByCategory(string categoryName);

        /// <summary>
        /// Retrieves the number of posts associated with a specific tag.
        /// </summary>
        /// <param name="tag">The name of the tag to count posts for.</param>
        /// <returns>The count of posts associated with the specified tag.</returns>
        int CountPostsForTag(string tag);

        /// <summary>
        /// Retrieves the number of posts associated with a specific category.
        /// </summary>
        /// <param name="categoryName">The name of the category to count posts for.</param>
        /// <returns>The count of posts associated with the specified category.</returns>
        int CountPostsForCategory(string categoryName);

        /// <summary>
        /// Retrieves a collection of the highest rated Post entities.
        /// </summary>
        /// <param name="size">The number of highest rated Post entities to retrieve.</param>
        /// <returns>A collection of the highest rated Post entities.</returns>
        IList<Post> GetHighestPosts(int size = 1);

        /// <summary>
        /// Retrieves a collection of Post entities associated with a specific tag.
        /// </summary>
        /// <param name="tag">The name of the tag to filter by.</param>
        /// <returns>A collection of Post entities associated with the specified tag.</returns>
        IList<Post> GetPostsByTag(string tag);
    }
}

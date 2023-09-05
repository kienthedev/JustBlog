using FA.JustBlog.Core.Models;

namespace FA.JustBlog.Core.Repositories.Interfaces
{
    /// <summary>
    /// Represents the interface for managing operations related to Comment entities.
    /// Inherits from the <see cref="IBaseRepository{T}"/> interface.
    /// </summary>
    public interface ICommentRepository : IBaseRepository<Comment>
    {
        /// <summary>
        /// Adds a new comment to a specified post.
        /// </summary>
        /// <param name="postId">The ID of the post to which the comment will be added.</param>
        /// <param name="commentName">The name of the commenter.</param>
        /// <param name="commentEmail">The email of the commenter.</param>
        /// <param name="commentTitle">The title of the comment.</param>
        /// <param name="commentBody">The body text of the comment.</param>
        void AddComment(int postId, string commentName, string commentEmail, string commentTitle, string commentBody);

        /// <summary>
        /// Retrieves a collection of comments for a specific post.
        /// </summary>
        /// <param name="postId">The ID of the post for which to retrieve comments.</param>
        /// <returns>A collection of comments for the specified post.</returns>
        IList<Comment> GetCommentsForPost(int postId);

        /// <summary>
        /// Retrieves a collection of comments for a specific post.
        /// </summary>
        /// <param name="post">The post for which to retrieve comments.</param>
        /// <returns>A collection of comments for the specified post.</returns>
        IList<Comment> GetCommentsForPost(Post post);
    }
}

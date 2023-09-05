using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Repositories.Interfaces;

namespace FA.JustBlog.Core.Repositories.Implementation
{
    /// <summary>
    /// Represents a repository for managing <see cref="Comment"/> entities.
    /// Inherits from the <see cref="BaseRepository{T}"/> class.
    /// Implements the <see cref="ICommentRepository"/> interface.
    /// </summary>
    public class CommentRepository : BaseRepository<Comment>, ICommentRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommentRepository"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        public CommentRepository(JustBlogContext context) : base(context)
        {
        }

        /// <summary>
        /// Adds a new comment for a specific post.
        /// </summary>
        /// <param name="postId">The ID of the post to add the comment to.</param>
        /// <param name="commentName">The name of the commenter.</param>
        /// <param name="commentEmail">The email of the commenter.</param>
        /// <param name="commentTitle">The title of the comment.</param>
        /// <param name="commentBody">The body of the comment.</param>
        public void AddComment(int postId, string commentName, string commentEmail, string commentTitle, string commentBody)
        {
            var post = _context.Posts.Find(postId);
            if (post != null)
            {
                var newComment = new Comment
                {
                    PostId = postId,
                    Name = commentName,
                    Email = commentEmail,
                    CommentHeader = commentTitle,
                    CommentText = commentBody,
                    CommentTime = DateTime.Now
                };
                _dbSet.Add(newComment);
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// Retrieves a list of comments for a specific post.
        /// </summary>
        /// <param name="postId">The ID of the post to retrieve comments for.</param>
        /// <returns>A list of comments for the specified post.</returns>
        public IList<Comment> GetCommentsForPost(int postId)
        {
            return _dbSet.Where(c => c.Post.Id == postId).ToList();
        }

        /// <summary>
        /// Retrieves a list of comments for a specific post.
        /// </summary>
        /// <param name="post">The post to retrieve comments for.</param>
        /// <returns>A list of comments for the specified post.</returns>
        public IList<Comment> GetCommentsForPost(Post post)
        {
            return _dbSet.Where(c => c.Post == post).ToList();
        }
    }
}

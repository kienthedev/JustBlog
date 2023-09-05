using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Repositories;
using FA.JustBlog.Core.Repositories.Implementation;
using FA.JustBlog.Core.Repositories.Interfaces;

namespace FA.JustBlog.UnitTest
{
    /// <summary>
    /// Unit tests for the CommentRepository class.
    /// </summary>
    public class CommentUnitTest
    {
        private JustBlogContext _context;
        private ICommentRepository _commentRepository;
        private IPostRepository _postRepository;

        [SetUp]
        public void Setup()
        {
            _context = new JustBlogContext();
            _commentRepository = new CommentRepository(_context);
            _postRepository = new PostRepository(_context);
        }

        /// <summary>
        /// Tests adding a valid comment to a post and verifying its presence in the database.
        /// </summary>
        [Test]
        public void AddComment_ValidPost_AddsCommentToDatabase()
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                int postId = 1;
                var commentName = "John";
                var commentEmail = "john@example.com";
                var commentTitle = "Test Comment";
                var commentBody = "This is a test comment.";
                _commentRepository.AddComment(postId, commentName, commentEmail, commentTitle, commentBody);

                var result = _commentRepository.FirstOrDefault(c => c.Name == commentName);
                Assert.NotNull(result);
                Assert.That(commentName, Is.EqualTo(result.Name));

                transaction.Rollback();
            } 
        }

        /// <summary>
        /// Tests getting comments for a valid post ID and verifies the count of returned comments.
        /// </summary>
        [TestCase(1, 10)]
        [TestCase(2, 0)]
        public void GetCommentsForPost_ValidPostId_ReturnsComments(int postId, int expectedCount)
        {
            var result = _commentRepository.GetCommentsForPost(postId);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.All(c => c.PostId == postId));
            Assert.AreEqual(expectedCount, result.Count());
        }

        /// <summary>
        /// Tests getting comments for an invalid post ID and verifies that an empty list is returned.
        /// </summary>
        [TestCase(-1)]
        public void GetCommentsForPost_InvalidPostId_ReturnsEmptyList(int postId)
        {
            var result = _commentRepository.GetCommentsForPost(postId);

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
        }

        /// <summary>
        /// Tests getting comments for a valid post and verifies the count of returned comments.
        /// </summary>
        [TestCase(1, 10)]
        public void GetCommentsForPost_ValidPost_ReturnsComments(int postId, int expectedCount)
        {
            var post = _postRepository.FirstOrDefault(p => p.Id == postId);
            var result = _commentRepository.GetCommentsForPost(post);

            Assert.IsNotNull(result);
            Assert.AreEqual(expectedCount, result.Count);
            Assert.IsTrue(result.All(c => c.Post == post));
        }

        /// <summary>
        /// Tests getting comments for an invalid post and verifies that an empty list is returned.
        /// </summary>
        [TestCase(-1)]
        public void GetCommentsForPost_InvalidPost_ReturnsEmptyList(int postId)
        {
            var post = _postRepository.FirstOrDefault(p => p.Id == postId);
            var result = _commentRepository.GetCommentsForPost(post);

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
        }
    }
}

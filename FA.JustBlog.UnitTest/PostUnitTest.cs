using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Repositories;

namespace FA.JustBlog.UnitTest
{
    /// <summary>
    /// Unit tests for the PostRepository class.
    /// </summary>
    public class PostUnitTest
    {
        private JustBlogContext _context;
        private IPostRepository _postRepository;

        [SetUp]
        public void Setup()
        {
            _context = new JustBlogContext();
            _postRepository = new PostRepository(_context);
        }

        /// <summary>
        /// Tests finding a post by year, month, and URL slug.
        /// </summary>
        [TestCase(2023, 7, "advancements-in-technology")]
        [TestCase(2023, 7, "summer-fashion-trends")]
        [TestCase(2023, 6, "classic-literature-masterpieces")]
        [TestCase(2023, 6, "creating-cozy-home-space")]
        [TestCase(2023, 5, "staying-active-outdoor-sports")]
        public void FindPost_ValidPostData_ReturnsPost(int year, int month, string urlSlug)
        {
            var post = _postRepository.FindPost(year, month, urlSlug);
            Assert.IsNotNull(post);
            Assert.AreEqual(year, post.PostedOn.Year);
            Assert.AreEqual(month, post.PostedOn.Month);
            Assert.AreEqual(urlSlug, post.UrlSlug);
        }

        /// <summary>
        /// Tests retrieving only published and active posts.
        /// </summary>
        [Test]
        public void GetPublishedPosts_ShouldReturnOnlyPublishedAndActivePosts()
        {
            var posts = _postRepository.GetPublishedPosts();
            Assert.IsNotNull(posts);
            Assert.That(posts, Has.Count.EqualTo(5));
            Assert.That(posts.All(p => p.Published == true && p.IsActive == true), Is.True);
        }

        /// <summary>
        /// Tests retrieving only unpublished and active posts.
        /// </summary>
        [Test]
        public void GetUnpublishedPosts_ShouldReturnOnlyUnpublishedAndActivePosts()
        {
            var posts = _postRepository.GetUnpublishedPosts();
            Assert.IsNotNull(posts);
            Assert.That(posts, Has.Count.EqualTo(0));
            Assert.That(posts.All(p => p.Published == false && p.IsActive == true), Is.True);
        }

        /// <summary>
        /// Tests retrieving the latest active post.
        /// </summary>
        [Test]
        public void GetLastestPost_ShouldReturnLatestActivePosts()
        {
            var post = _postRepository.GetLastestPost();
            Assert.That(post, Has.Count.EqualTo(1));
            Assert.That(post[0].Title, Is.EqualTo("Advancements in Technology"));
        }

        /// <summary>
        /// Tests retrieving posts by category and ensuring correct count.
        /// </summary>
        [TestCase("Beauty & Personal Care", 1)]
        [TestCase("Furniture", 1)]
        [TestCase("Health & Fitness", 1)]
        [TestCase("Toys & Games", 1)]
        [TestCase("Food & Beverages", 1)]
        [TestCase("NonExistentCategory", 0)]
        public void GetPostsByCategory_ShouldReturnCorrectNumberOfPosts(string categoryName, int expectedCount)
        {
            var posts = _postRepository.GetPostsByCategory(categoryName);
            Assert.That(posts, Has.Count.EqualTo(expectedCount));
        }

        /// <summary>
        /// Tests retrieving posts by month and ensuring correct count.
        /// </summary>
        [TestCase("2023-07-01", 2)]
        [TestCase("2023-06-01", 2)]
        [TestCase("2023-05-01", 1)]
        public void GetPostsByMonth_ShouldReturnCorrectNumberOfPosts(string monthYearString, int expectedCount)
        {
            var monthYear = DateTime.Parse(monthYearString);
            var posts = _postRepository.GetPostsByMonth(monthYear);
            Assert.That(posts, Has.Count.EqualTo(expectedCount));
        }

        /// <summary>
        /// Tests retrieving posts by tag and ensuring correct count.
        /// </summary>
        [TestCase("Skincare", 2)]
        [TestCase("Interior Design", 2)]
        [TestCase("Wellness", 2)]
        [TestCase("Toys", 2)]
        [TestCase("Cuisine", 2)]
        [TestCase("non-exist-tag", 0)]
        public void GetPostsByTag_ShouldReturnCorrectNumberOfPosts(string tag, int expectedCount)
        {
            var posts = _postRepository.GetPostsByTag(tag);
            Assert.That(posts, Has.Count.EqualTo(expectedCount));
        }

        /// <summary>
        /// Tests counting the number of posts associated with a specific category.
        /// </summary>
        [TestCase("Beauty & Personal Care", 1)]
        [TestCase("Furniture", 1)]
        [TestCase("Health & Fitness", 1)]
        [TestCase("Toys & Games", 1)]
        [TestCase("Food & Beverages", 1)]
        [TestCase("non-exist-category", 0)]
        public void CountPostsForCategory_ShouldReturnCorrectPostCount(string categoryName, int expectedCount)
        {
            var count = _postRepository.CountPostsForCategory(categoryName);
            Assert.That(count, Is.EqualTo(expectedCount));
        }

        /// <summary>
        /// Tests counting the number of posts associated with a specific tag.
        /// </summary>
        [TestCase("Skincare", 2)]
        [TestCase("Interior Design", 2)]
        [TestCase("Wellness", 2)]
        [TestCase("Toys", 2)]
        [TestCase("Cuisine", 2)]
        [TestCase("non-exist-tag", 0)]
        public void CountPostsForTag_TagExists_ReturnsCorrectCount(string tagName, int expectedCount)
        {
            var actualCount = _postRepository.CountPostsForTag(tagName);
            Assert.AreEqual(expectedCount, actualCount);
        }
    }
}

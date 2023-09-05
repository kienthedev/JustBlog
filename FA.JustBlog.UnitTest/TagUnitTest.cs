using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Repositories;

namespace FA.JustBlog.UnitTest
{
    /// <summary>
    /// Unit tests for the TagRepository class.
    /// </summary>
    public class TagUnitTest
    {
        private JustBlogContext _context;
        private ITagRepository _tagRepository;

        [SetUp]
        public void Setup()
        {
            // Initialize the context and repository for each test
            _context = new JustBlogContext();
            _tagRepository = new TagRepository(_context);
        }

        /// <summary>
        /// Tests retrieving a tag by its URL slug.
        /// </summary>
        [TestCase("skincare")]
        [TestCase("interior-design")]
        [TestCase("wellness")]
        [TestCase("non-existent-tag")]
        public void GetTagByUrlSlug_ValidUrlSlug_ReturnsCorrectTag(string urlSlug)
        {
            var tag = _tagRepository.GetTagByUrlSlug(urlSlug);
            if (urlSlug == "non-existent-tag")
            {
                Assert.IsNull(tag);
            }
            else
            {
                Assert.IsNotNull(tag);
                Assert.AreEqual(urlSlug, tag.UrlSlug);
            }
        }

        /// <summary>
        /// Tests retrieving a tag by its ID.
        /// </summary>
        [TestCase(1, "Skincare", "skincare", "Tags related to skincare and beauty routines.", 6)]
        [TestCase(2, "Interior Design", "interior-design", "Tags related to interior design and decor ideas.", 4)]
        [TestCase(3, "Wellness", "wellness", "Tags related to health and holistic wellness.", 9)]
        [TestCase(100, null, null, null, 0)]
        public void Find_TagExists_ReturnsTag(int tagId, string expectedName, string expectedUrlSlug, string expectedDescription, int expectedCount)
        {
            var result = _tagRepository.GetById(tagId);
            if (expectedName == null)
            {
                Assert.IsNull(result);
            }
            else
            {
                Assert.IsNotNull(result);
                Assert.AreEqual(expectedName, result.Name);
                Assert.AreEqual(expectedUrlSlug, result.UrlSlug);
                Assert.AreEqual(expectedDescription, result.Description);
                Assert.AreEqual(expectedCount, result.Count);
            }
        }

        /// <summary>
        /// Tests retrieving a tag by its ID from the repository.
        /// </summary>
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void FindTag_ValidTagId_ReturnsTag(int tagId)
        {
            var expectedTag = _context.Tags.FirstOrDefault(t => t.Id == tagId);
            var actualTag = _tagRepository.GetById(tagId);
            Assert.IsNotNull(actualTag);
            Assert.AreEqual(expectedTag, actualTag);
        }

        /// <summary>
        /// Tests inserting a new tag, adding it to the repository, and then deleting it.
        /// </summary>
        [Test]
        public void Insert_NewTag_AddTagToRepository_AndDeleteAfterThat()
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                var tag = new Tag
                {
                    Name = "test",
                    Count = 1,
                    Description = "test",
                    UrlSlug = "testUrl",
                };
                _tagRepository.Insert(tag);
                _tagRepository.Save();

                var result = _tagRepository.GetById(tag.Id);
                Assert.NotNull(result);
                Assert.That(tag.Id, Is.EqualTo(result.Id));

                transaction.Rollback();
            }
        }

        /// <summary>
        /// Tests updating an existing tag in the repository.
        /// </summary>
        [Test]
        public void Update_ExistingCategory_UpdatesCategoryInRepository()
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                var updatedTagName = "Updated name";
                var tagToUpdate = _tagRepository.GetById(1);

                if (tagToUpdate != null)
                {
                    tagToUpdate.Name = updatedTagName;
                    _tagRepository.Update(tagToUpdate);
                    _tagRepository.Save();
                }

                var updatedCategory = _tagRepository.GetById(1);
                Assert.NotNull(updatedCategory);
                Assert.That(updatedTagName, Is.EqualTo(updatedCategory.Name));
                transaction.Rollback();
            }
        }

        /// <summary>
        /// Tests deleting a tag from the repository.
        /// </summary>
        [Test]
        public void Delete_Tag_ShouldRemoveTagFromRepository()
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                var tag = new Tag
                {
                    Name = "test",
                    Count = 1,
                    Description = "test",
                    UrlSlug = "testUrl",
                };
                _tagRepository.Insert(tag);
                _tagRepository.Save();

                _tagRepository.Delete(tag);
                _tagRepository.Save();

                var deletedTag = _tagRepository.GetById(tag.Id);
                Assert.Null(deletedTag);

                transaction.Rollback();
            }
        }
    }
}

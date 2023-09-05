using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Repositories;
using FA.JustBlog.Core.Repositories.Implementation;
using FA.JustBlog.Core.Repositories.Interfaces;
using System.Linq.Expressions;

namespace FA.JustBlog.UnitTest
{
    public class CategoryUnitTest
    {
        private JustBlogContext _context;
        private ICategoryRepository _categoryRepository;

        [SetUp]
        public void Setup()
        {
            // Initialize the context and repository for each test
            _context = new JustBlogContext();
            _categoryRepository = new CategoryRepository(_context);
        }

        [Test]
        public void FirstOrDefault_ValidFilter_ReturnsMatchingCategory()
        {
            var categoryName = "Beauty & Personal Care";
            Expression<Func<Category, bool>> filter = c => c.Name == categoryName;
            var result = _categoryRepository.FirstOrDefault(filter);

            Assert.IsNotNull(result);
            Assert.AreEqual(categoryName, result.Name);
        }

        [Test]
        public void FirstOrDefault_InvalidFilter_ReturnsNull()
        {
            Expression<Func<Category, bool>> filter = c => c.Name == "NonExistentCategory";
            var result = _categoryRepository.FirstOrDefault(filter);

            Assert.IsNull(result);
        }

        public void GetAll_NoFilterOrOrderBy_ReturnsAllActiveCategories()
        {
            var result = _categoryRepository.GetAll();

            Assert.IsNotNull(result);
            Assert.AreEqual(5, result.Count());
            Assert.IsTrue(result.All(e => e.IsActive));
        }

        [Test]
        public void GetAll_WithFilter_ReturnsFilteredEntities()
        {
            Expression<Func<Category, bool>> filter = c => c.Name.Contains("a");
            var result = _categoryRepository.GetAll(filter);

            Assert.IsNotNull(result);
            Assert.AreEqual(4, result.Count());
            Assert.IsTrue(result.All(e => e.Name.Contains("a")));
        }
    }
}

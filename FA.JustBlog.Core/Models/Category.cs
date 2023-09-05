using System.ComponentModel.DataAnnotations;

namespace FA.JustBlog.Core.Models
{
    public class Category : BaseEntity
    {
        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets Name.
        /// </summary>
        [Required(ErrorMessage = "Category name is required.")]
        [StringLength(255)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets UrlSlug.
        /// </summary>
        [StringLength(255)]
        public string UrlSlug { get; set; }

        /// <summary>
        /// Gets or sets Description.
        /// </summary>
        [StringLength(1024)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets Posts.
        /// </summary>
        public IList<Post> Posts { get; set; } = new List<Post>();
    }
}

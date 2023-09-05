using System.ComponentModel.DataAnnotations;

namespace FA.JustBlog.Core.Models
{
    /// <summary>
    /// Tag class.
    /// </summary>
    public class Tag : BaseEntity
    {
        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets Name.
        /// </summary>
        [Required(ErrorMessage = "Tag name is required.")]
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
        /// Gets or sets Count.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Gets or sets PostTagMaps.
        /// </summary>
        public IList<PostTagMap> PostTagMaps { get; set; } = new List<PostTagMap>();
    }
}

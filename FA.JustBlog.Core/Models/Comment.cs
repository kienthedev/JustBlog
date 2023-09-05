using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FA.JustBlog.Core.Models
{
    /// <summary>
    /// Comment class.
    /// </summary>
    public class Comment : BaseEntity
    {
        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets Name.
        /// </summary>
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(255)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Email.
        /// </summary>
        [Required(ErrorMessage = "Email is required.")]
        [StringLength(255)]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets PostId.
        /// </summary>
        [Required(ErrorMessage = "Post is required.")]
        [ForeignKey("Post")]
        public int PostId { get; set; }

        /// <summary>
        /// Gets or sets Post.
        /// </summary>
        public Post Post { get; set; }

        /// <summary>
        /// Gets or sets CommentHeader.
        /// </summary>
        [StringLength(255)]
        public string CommentHeader { get; set; }

        /// <summary>
        /// Gets or sets CommentText.
        /// </summary>
        [Required(ErrorMessage = "Comment text is required.")]
        [StringLength(1024)]
        public string CommentText { get; set; }

        /// <summary>
        /// Gets or sets CommentTime.
        /// </summary>
        public DateTime CommentTime { get; set; }
    }
}

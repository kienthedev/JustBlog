namespace FA.JustBlog.Core.Models
{
    /// <summary>
    /// Base Entity class.
    /// </summary>
    public class BaseEntity
    {
        /// <summary>
        /// Gets or sets InsertedAt.
        /// </summary>
        public DateTime? InsertedAt { get; set; }

        /// <summary>
        /// Gets or sets UpdatedAt.
        /// </summary>
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// Gets or sets IsActive.
        /// </summary>
        public bool IsActive { get; set; } = true;
    }
}

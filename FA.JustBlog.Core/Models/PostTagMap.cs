namespace FA.JustBlog.Core.Models
{
    public class PostTagMap : BaseEntity
    {
        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        public int PostId { get; set; }

        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        public int TagId { get; set; }

        /// <summary>
        /// Gets or sets Id.
        /// </summary>

        public Post Post { get; set; }

        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        public Tag Tag { get; set; }
    }
}

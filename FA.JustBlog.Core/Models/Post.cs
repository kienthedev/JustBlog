// <copyright file="Post.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FA.JustBlog.Core.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Post : BaseEntity
    {
        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets Title.
        /// </summary>
        [Required(ErrorMessage = "Post title is required.")]
        [StringLength(255)]
        public string? Title { get; set; }

        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        [StringLength(255)]
        public string? ShortDescription { get; set; }

        /// <summary>
        /// Gets or sets PostContent.
        /// </summary>
        [StringLength(1024)]
        public string? PostContent { get; set; }

        /// <summary>
        /// Gets or sets UrlSlug.
        /// </summary>
        [StringLength(255)]
        public string? UrlSlug { get; set; }

        /// <summary>
        /// Gets or sets Published.
        /// </summary>
        public bool? Published { get; set; }

        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        public DateTime PostedOn { get; set; }

        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        public bool? Modified { get; set; }

        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        public int ViewCount { get; set; }

        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        public int RateCount { get; set; }

        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        public int TotalRate { get; set; }

        /// <summary>
        /// Gets rate.
        /// </summary>
        [NotMapped]
        public decimal Rate
        {
            get { return this.RateCount > 0 ? (decimal)this.TotalRate / this.RateCount : 0; }
        }

        /// <summary>
        /// Gets or sets CategoryId.
        /// </summary>
        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        /// <summary>
        /// Gets or sets Category.
        /// </summary>
        public Category? Category { get; set; }

        /// <summary>
        /// Gets or sets Comments.
        /// </summary>
        public IList<Comment>? Comments { get; set; }

        /// <summary>
        /// Gets or sets PostTagMaps.
        /// </summary>
        public IList<PostTagMap> PostTagMaps { get; set; } = new List<PostTagMap>();
    }
}

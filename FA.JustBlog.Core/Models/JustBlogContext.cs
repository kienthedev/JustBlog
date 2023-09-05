namespace FA.JustBlog.Core.Models
{
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Represents the database context for the JustBlog application.
    /// Inherits from <see cref="DbContext"/>.
    /// </summary>
    public class JustBlogContext : DbContext
    {
        private string connectionStrings = "server=  (local);database=JustBlog;uid=sa;pwd=123456;TrustServerCertificate=True";

        /// <summary>
        /// Initializes a new instance of the <see cref="JustBlogContext"/> class.
        /// </summary>
        public JustBlogContext()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JustBlogContext"/> class with specified options.
        /// </summary>
        /// <param name="options">The options for configuring the context.</param>
        public JustBlogContext(DbContextOptions<JustBlogContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the collection of categories.
        /// </summary>
        public virtual DbSet<Category> Categories { get; set; }

        /// <summary>
        /// Gets or sets the collection of posts.
        /// </summary>
        public virtual DbSet<Post> Posts { get; set; }

        /// <summary>
        /// Gets or sets the collection of tags.
        /// </summary>
        public virtual DbSet<Tag> Tags { get; set; }

        /// <summary>
        /// Gets or sets the collection of comments.
        /// </summary>
        public virtual DbSet<Comment> Comments { get; set; }

        /// <summary>
        /// Gets or sets the collection of post-tag mappings.
        /// </summary>
        public virtual DbSet<PostTagMap> PostTagMaps { get; set; }

        /// <summary>
        /// Configures the database connection and options.
        /// </summary>
        /// <param name="optionsBuilder">The builder for configuring options.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.connectionStrings);
        }

        /// <summary>
        /// Configures the model using Fluent API.
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Fluent API configurations
            modelBuilder.Entity<PostTagMap>()
                .HasKey(x => new { x.TagId, x.PostId });

            modelBuilder.Entity<PostTagMap>()
                .HasOne(x => x.Post)
                .WithMany(x => x.PostTagMaps)
                .HasForeignKey(x => x.PostId);

            modelBuilder.Entity<PostTagMap>()
                .HasOne(x => x.Tag)
                .WithMany(x => x.PostTagMaps)
                .HasForeignKey(x => x.TagId);

            // Category, Tag, Post, PostTagMap, and Comment seed data
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Beauty & Personal Care",
                    UrlSlug = "beauty-personal-care",
                    Description = "Discover skincare, makeup, and personal grooming products.",
                    InsertedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    IsActive = true,
                },
                new Category
                {
                    Id = 2,
                    Name = "Furniture",
                    UrlSlug = "furniture",
                    Description = "Furnish your spaces with stylish and functional furniture.",
                    InsertedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    IsActive = true,
                },
                new Category
                {
                    Id = 3,
                    Name = "Health & Fitness",
                    UrlSlug = "health-fitness",
                    Description = "Achieve your health and fitness goals with the right products.",
                    InsertedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    IsActive = true,
                },
                new Category
                {
                    Id = 4,
                    Name = "Toys & Games",
                    UrlSlug = "toys-games",
                    Description = "Entertain and educate with a variety of toys and games.",
                    InsertedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    IsActive = true,
                },
                new Category
                {
                    Id = 5,
                    Name = "Food & Beverages",
                    UrlSlug = "food-beverages",
                    Description = "Explore a world of delicious food and beverages.",
                    InsertedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    IsActive = true,
                });

            modelBuilder.Entity<Tag>().HasData(
                new Tag
                {
                    Id = 1,
                    Name = "Skincare",
                    UrlSlug = "skincare",
                    Description = "Tags related to skincare and beauty routines.",
                    Count = 6,
                    InsertedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    IsActive = true,
                },
                new Tag
                {
                    Id = 2,
                    Name = "Interior Design",
                    UrlSlug = "interior-design",
                    Description = "Tags related to interior design and decor ideas.",
                    Count = 4,
                    InsertedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    IsActive = true,
                },
                new Tag
                {
                    Id = 3,
                    Name = "Wellness",
                    UrlSlug = "wellness",
                    Description = "Tags related to health and holistic wellness.",
                    Count = 9,
                    InsertedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    IsActive = true,
                },
                new Tag
                {
                    Id = 4,
                    Name = "Toys",
                    UrlSlug = "toys",
                    Description = "Tags related to toys and playtime.",
                    Count = 2,
                    InsertedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    IsActive = true,
                },
                new Tag
                {
                    Id = 5,
                    Name = "Cuisine",
                    UrlSlug = "cuisine",
                    Description = "Tags related to different types of cuisines and food.",
                    Count = 11,
                    InsertedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    IsActive = true,
                });
            modelBuilder.Entity<Post>().HasData(
                new Post
                {
                    Id = 1,
                    Title = "Advancements in Technology",
                    ShortDescription = "Exploring recent technological breakthroughs.",
                    PostContent = "The world of technology is evolving rapidly...",
                    UrlSlug = "advancements-in-technology",
                    Published = true,
                    PostedOn = DateTime.Now.AddDays(-45),
                    Modified = false,
                    CategoryId = 1,
                    InsertedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    IsActive = true,
                },
                new Post
                {
                    Id = 2,
                    Title = "Summer Fashion Trends",
                    ShortDescription = "Unveiling the hottest summer fashion trends.",
                    PostContent = "Summer is here, and it's time to update your wardrobe...",
                    UrlSlug = "summer-fashion-trends",
                    Published = true,
                    PostedOn = DateTime.Now.AddDays(-60),
                    Modified = false,
                    CategoryId = 2,
                    InsertedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    IsActive = true,
                },
                new Post
                {
                    Id = 3,
                    Title = "Classic Literature Masterpieces",
                    ShortDescription = "Exploring timeless classics in literature.",
                    PostContent = "Great literature stands the test of time...",
                    UrlSlug = "classic-literature-masterpieces",
                    Published = true,
                    PostedOn = DateTime.Now.AddDays(-75),
                    Modified = false,
                    CategoryId = 3,
                    InsertedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    IsActive = true,
                },
                new Post
                {
                    Id = 4,
                    Title = "Creating a Cozy Home Space",
                    ShortDescription = "Tips for crafting a cozy and inviting home.",
                    PostContent = "Your home should be a sanctuary of comfort and warmth...",
                    UrlSlug = "creating-cozy-home-space",
                    Published = true,
                    PostedOn = DateTime.Now.AddDays(-90),
                    Modified = false,
                    CategoryId = 4,
                    InsertedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    IsActive = true,
                },
                new Post
                {
                    Id = 5,
                    Title = "Staying Active with Outdoor Sports",
                    ShortDescription = "Embracing an active lifestyle through outdoor sports.",
                    PostContent = "Outdoor sports offer not only physical benefits but also...",
                    UrlSlug = "staying-active-outdoor-sports",
                    Published = true,
                    PostedOn = DateTime.Now.AddDays(-100),
                    Modified = false,
                    CategoryId = 5,
                    InsertedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    IsActive = true,
                });
            modelBuilder.Entity<PostTagMap>().HasData(
                new PostTagMap
                {
                    PostId = 1,
                    TagId = 1,
                    InsertedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    IsActive = true,
                },
                new PostTagMap
                {
                    PostId = 1,
                    TagId = 2,
                    InsertedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    IsActive = true,
                },
                new PostTagMap
                {
                    PostId = 2,
                    TagId = 2,
                    InsertedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    IsActive = true,
                },
                new PostTagMap
                {
                    PostId = 2,
                    TagId = 3,
                    InsertedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    IsActive = true,
                },
                new PostTagMap
                {
                    PostId = 3,
                    TagId = 3,
                    InsertedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    IsActive = true,
                },
                new PostTagMap
                {
                    PostId = 3,
                    TagId = 4,
                    InsertedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    IsActive = true,
                },
                new PostTagMap
                {
                    PostId = 4,
                    TagId = 4,
                    InsertedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    IsActive = true,
                },
                new PostTagMap
                {
                    PostId = 4,
                    TagId = 5,
                    InsertedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    IsActive = true,
                },
                new PostTagMap
                {
                    PostId = 5,
                    TagId = 5,
                    InsertedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    IsActive = true,
                },
                new PostTagMap
                {
                    PostId = 5,
                    TagId = 1,
                    InsertedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    IsActive = true,
                });
            modelBuilder.Entity<Comment>().HasData(
                new Comment
                {
                    Id = 1,
                    Name = "User1",
                    Email = "user1@example.com",
                    CommentHeader = "First Comment",
                    CommentText = "This is the first comment.",
                    CommentTime = DateTime.Now,
                    PostId = 1,
                    InsertedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    IsActive = true,
                },
                new Comment
                {
                    Id = 2,
                    Name = "User2",
                    Email = "user2@example.com",
                    CommentHeader = "Insightful Thoughts",
                    CommentText = "I found this post to be quite insightful.",
                    CommentTime = DateTime.Now.AddDays(-1),
                    PostId = 1,
                    InsertedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    IsActive = true,
                },
                new Comment
                {
                    Id = 3,
                    Name = "User3",
                    Email = "user3@example.com",
                    CommentHeader = "Questions and Clarifications",
                    CommentText = "I have a few questions about the concepts discussed.",
                    CommentTime = DateTime.Now.AddDays(-2),
                    PostId = 1,
                    InsertedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    IsActive = true,
                },
                new Comment
                {
                    Id = 4,
                    Name = "User4",
                    Email = "user4@example.com",
                    CommentHeader = "Engaging Topic",
                    CommentText = "I'm fascinated by the subject of AI. Thanks for sharing!",
                    CommentTime = DateTime.Now.AddDays(-3),
                    PostId = 1,
                    InsertedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    IsActive = true,
                },
                new Comment
                {
                    Id = 5,
                    Name = "User5",
                    Email = "user5@example.com",
                    CommentHeader = "Feedback",
                    CommentText = "The post could use some more technical details.",
                    CommentTime = DateTime.Now.AddDays(-4),
                    PostId = 1,
                    InsertedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    IsActive = true,
                },
                new Comment
                {
                    Id = 6,
                    Name = "User6",
                    Email = "user6@example.com",
                    CommentHeader = "Personal Experiences",
                    CommentText = "I've been working in AI for years, and it's an exciting field.",
                    CommentTime = DateTime.Now.AddDays(-5),
                    PostId = 1,
                    InsertedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    IsActive = true,
                },
                new Comment
                {
                    Id = 7,
                    Name = "User7",
                    Email = "user7@example.com",
                    CommentHeader = "Request for More Topics",
                    CommentText = "Could you cover AI in medical applications next?",
                    CommentTime = DateTime.Now.AddDays(-6),
                    PostId = 1,
                    InsertedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    IsActive = true,
                },
                new Comment
                {
                    Id = 8,
                    Name = "User8",
                    Email = "user8@example.com",
                    CommentHeader = "Engaging Read",
                    CommentText = "I thoroughly enjoyed reading this post. Great job!",
                    CommentTime = DateTime.Now.AddDays(-7),
                    PostId = 1,
                    InsertedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    IsActive = true,
                },
                new Comment
                {
                    Id = 9,
                    Name = "User9",
                    Email = "user9@example.com",
                    CommentHeader = "AI Enthusiast",
                    CommentText = "As an AI enthusiast, I found this post to be well-written.",
                    CommentTime = DateTime.Now.AddDays(-8),
                    PostId = 1,
                    InsertedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    IsActive = true,
                },
                new Comment
                {
                    Id = 10,
                    Name = "User10",
                    Email = "user10@example.com",
                    CommentHeader = "Technical Query",
                    CommentText = "Can you elaborate more on neural networks?",
                    CommentTime = DateTime.Now.AddDays(-9),
                    PostId = 1,
                    InsertedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    IsActive = true,
                });
        }
    }
}

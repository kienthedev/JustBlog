using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FA.JustBlog.Core.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    UrlSlug = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PostContent = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    UrlSlug = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Published = table.Column<bool>(type: "bit", nullable: false),
                    PostedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modified = table.Column<bool>(type: "bit", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    UrlSlug = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PostTagMaps",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostTagMaps", x => new { x.PostId, x.TagId });
                    table.ForeignKey(
                        name: "FK_PostTagMaps_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostTagMaps_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name", "UrlSlug" },
                values: new object[,]
                {
                    { 1, "Explore the world of technology", "Technology", "technology" },
                    { 2, "Discover new places and cultures", "Travel", "travel" },
                    { 3, "Indulge in delicious cuisines", "Food", "food" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CategoryId", "Modified", "PostContent", "PostedOn", "Published", "ShortDescription", "Title", "UrlSlug" },
                values: new object[,]
                {
                    { 1, 1, false, "Entity Framework is a powerful Object-Relational Mapping (ORM) framework that enables developers to work with databases using .NET objects. It simplifies database interactions by allowing you to manipulate database records as objects, and it automatically generates SQL queries for you. With Entity Framework, you can define your data model using C# classes and then use LINQ (Language Integrated Query) to query and manipulate data.\n\nWhether you're building a simple application or a complex enterprise system, Entity Framework can help you manage the data layer efficiently. It supports various database providers, enabling you to work with different types of databases seamlessly.\n\nEntity Framework also provides features like migrations, tracking changes, and handling relationships between entities. This makes it a popular choice among .NET developers for building data-driven applications.", new DateTime(2023, 8, 28, 14, 22, 0, 942, DateTimeKind.Local).AddTicks(6590), true, "Learn about Entity Framework", "Introduction to Entity Framework", "introduction-to-ef" },
                    { 2, 2, false, "Last week, I visited a city I had never been to before, and it turned out to be an amazing experience. The city was vibrant and full of life, with bustling markets, stunning architecture, and friendly locals. I explored its hidden alleys and iconic landmarks, trying local cuisine and immersing myself in the culture.\n\nOne of the highlights was a guided tour to learn about the city's history and traditions. I visited museums, art galleries, and even took a scenic boat ride along the river. It was a truly eye-opening journey that reminded me of the beauty of discovering new places and embracing different perspectives.", new DateTime(2023, 8, 28, 14, 22, 0, 942, DateTimeKind.Local).AddTicks(6600), true, "Traveling to an unknown city", "Exploring a New City", "exploring-new-city" },
                    { 3, 3, false, "Food has a unique way of connecting people from different parts of the world. Exploring various cuisines is like embarking on a culinary adventure, allowing you to savor the flavors of different cultures.\n\nIn this post, I'll be sharing some of my favorite recipes from around the world. From the aromatic spices of Indian curries to the comforting pasta dishes of Italy, each recipe tells a story of tradition and innovation. Whether you're a seasoned chef or a beginner in the kitchen, I invite you to join me on this gastronomic journey.", new DateTime(2023, 8, 28, 14, 22, 0, 942, DateTimeKind.Local).AddTicks(6602), true, "Cooking up global delights", "Delicious Recipes from Around the World", "delicious-recipes" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Count", "Description", "Name", "UrlSlug" },
                values: new object[,]
                {
                    { 1, 3, "Coding and development topics", "Programming", "programming" },
                    { 2, 2, "Thrilling adventures and experiences", "Adventure", "adventure" },
                    { 3, 1, "Culinary delights from various cultures", "Cuisine", "cuisine" }
                });

            migrationBuilder.InsertData(
                table: "PostTagMaps",
                columns: new[] { "PostId", "TagId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 2 },
                    { 3, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PostTagMaps_TagId",
                table: "PostTagMaps",
                column: "TagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "PostTagMaps");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Tags");
        }
    }
}

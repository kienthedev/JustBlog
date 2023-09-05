using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FA.JustBlog.Core.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PostTagMaps",
                table: "PostTagMaps");

            migrationBuilder.DropIndex(
                name: "IX_PostTagMaps_TagId",
                table: "PostTagMaps");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostTagMaps",
                table: "PostTagMaps",
                columns: new[] { "TagId", "PostId" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "InsertedAt", "Name", "UpdatedAt", "UrlSlug" },
                values: new object[] { "Discover skincare, makeup, and personal grooming products.", new DateTime(2023, 8, 31, 9, 8, 36, 738, DateTimeKind.Local).AddTicks(9633), "Beauty & Personal Care", new DateTime(2023, 8, 31, 9, 8, 36, 738, DateTimeKind.Local).AddTicks(9644), "beauty-personal-care" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "InsertedAt", "Name", "UpdatedAt", "UrlSlug" },
                values: new object[] { "Furnish your spaces with stylish and functional furniture.", new DateTime(2023, 8, 31, 9, 8, 36, 738, DateTimeKind.Local).AddTicks(9646), "Furniture", new DateTime(2023, 8, 31, 9, 8, 36, 738, DateTimeKind.Local).AddTicks(9647), "furniture" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "InsertedAt", "Name", "UpdatedAt", "UrlSlug" },
                values: new object[] { "Achieve your health and fitness goals with the right products.", new DateTime(2023, 8, 31, 9, 8, 36, 738, DateTimeKind.Local).AddTicks(9649), "Health & Fitness", new DateTime(2023, 8, 31, 9, 8, 36, 738, DateTimeKind.Local).AddTicks(9649), "health-fitness" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "InsertedAt", "IsActive", "Name", "UpdatedAt", "UrlSlug" },
                values: new object[,]
                {
                    { 4, "Entertain and educate with a variety of toys and games.", new DateTime(2023, 8, 31, 9, 8, 36, 738, DateTimeKind.Local).AddTicks(9651), true, "Toys & Games", new DateTime(2023, 8, 31, 9, 8, 36, 738, DateTimeKind.Local).AddTicks(9651), "toys-games" },
                    { 5, "Explore a world of delicious food and beverages.", new DateTime(2023, 8, 31, 9, 8, 36, 738, DateTimeKind.Local).AddTicks(9653), true, "Food & Beverages", new DateTime(2023, 8, 31, 9, 8, 36, 738, DateTimeKind.Local).AddTicks(9653), "food-beverages" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommentHeader", "CommentText", "CommentTime", "Email", "InsertedAt", "IsActive", "Name", "PostId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "First Comment", "This is the first comment.", new DateTime(2023, 8, 31, 9, 8, 36, 738, DateTimeKind.Local).AddTicks(9868), "user1@example.com", new DateTime(2023, 8, 31, 9, 8, 36, 738, DateTimeKind.Local).AddTicks(9869), true, "User1", 1, new DateTime(2023, 8, 31, 9, 8, 36, 738, DateTimeKind.Local).AddTicks(9870) },
                    { 2, "Insightful Thoughts", "I found this post to be quite insightful.", new DateTime(2023, 8, 30, 9, 8, 36, 738, DateTimeKind.Local).AddTicks(9871), "user2@example.com", new DateTime(2023, 8, 31, 9, 8, 36, 738, DateTimeKind.Local).AddTicks(9872), true, "User2", 1, new DateTime(2023, 8, 31, 9, 8, 36, 738, DateTimeKind.Local).AddTicks(9873) },
                    { 3, "Questions and Clarifications", "I have a few questions about the concepts discussed.", new DateTime(2023, 8, 29, 9, 8, 36, 738, DateTimeKind.Local).AddTicks(9874), "user3@example.com", new DateTime(2023, 8, 31, 9, 8, 36, 738, DateTimeKind.Local).AddTicks(9876), true, "User3", 1, new DateTime(2023, 8, 31, 9, 8, 36, 738, DateTimeKind.Local).AddTicks(9876) },
                    { 4, "Engaging Topic", "I'm fascinated by the subject of AI. Thanks for sharing!", new DateTime(2023, 8, 28, 9, 8, 36, 738, DateTimeKind.Local).AddTicks(9878), "user4@example.com", new DateTime(2023, 8, 31, 9, 8, 36, 738, DateTimeKind.Local).AddTicks(9879), true, "User4", 1, new DateTime(2023, 8, 31, 9, 8, 36, 738, DateTimeKind.Local).AddTicks(9879) },
                    { 5, "Feedback", "The post could use some more technical details.", new DateTime(2023, 8, 27, 9, 8, 36, 738, DateTimeKind.Local).AddTicks(9881), "user5@example.com", new DateTime(2023, 8, 31, 9, 8, 36, 738, DateTimeKind.Local).AddTicks(9881), true, "User5", 1, new DateTime(2023, 8, 31, 9, 8, 36, 738, DateTimeKind.Local).AddTicks(9882) },
                    { 6, "Personal Experiences", "I've been working in AI for years, and it's an exciting field.", new DateTime(2023, 8, 26, 9, 8, 36, 738, DateTimeKind.Local).AddTicks(9884), "user6@example.com", new DateTime(2023, 8, 31, 9, 8, 36, 738, DateTimeKind.Local).AddTicks(9884), true, "User6", 1, new DateTime(2023, 8, 31, 9, 8, 36, 738, DateTimeKind.Local).AddTicks(9885) },
                    { 7, "Request for More Topics", "Could you cover AI in medical applications next?", new DateTime(2023, 8, 25, 9, 8, 36, 738, DateTimeKind.Local).AddTicks(9886), "user7@example.com", new DateTime(2023, 8, 31, 9, 8, 36, 738, DateTimeKind.Local).AddTicks(9887), true, "User7", 1, new DateTime(2023, 8, 31, 9, 8, 36, 738, DateTimeKind.Local).AddTicks(9888) },
                    { 8, "Engaging Read", "I thoroughly enjoyed reading this post. Great job!", new DateTime(2023, 8, 24, 9, 8, 36, 738, DateTimeKind.Local).AddTicks(9889), "user8@example.com", new DateTime(2023, 8, 31, 9, 8, 36, 738, DateTimeKind.Local).AddTicks(9890), true, "User8", 1, new DateTime(2023, 8, 31, 9, 8, 36, 738, DateTimeKind.Local).AddTicks(9890) },
                    { 9, "AI Enthusiast", "As an AI enthusiast, I found this post to be well-written.", new DateTime(2023, 8, 23, 9, 8, 36, 738, DateTimeKind.Local).AddTicks(9892), "user9@example.com", new DateTime(2023, 8, 31, 9, 8, 36, 738, DateTimeKind.Local).AddTicks(9892), true, "User9", 1, new DateTime(2023, 8, 31, 9, 8, 36, 738, DateTimeKind.Local).AddTicks(9893) },
                    { 10, "Technical Query", "Can you elaborate more on neural networks?", new DateTime(2023, 8, 22, 9, 8, 36, 738, DateTimeKind.Local).AddTicks(9894), "user10@example.com", new DateTime(2023, 8, 31, 9, 8, 36, 738, DateTimeKind.Local).AddTicks(9895), true, "User10", 1, new DateTime(2023, 8, 31, 9, 8, 36, 738, DateTimeKind.Local).AddTicks(9896) }
                });

            migrationBuilder.InsertData(
                table: "PostTagMaps",
                columns: new[] { "PostId", "TagId", "InsertedAt", "IsActive", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 8, 31, 9, 8, 36, 738, DateTimeKind.Local).AddTicks(9833), true, new DateTime(2023, 8, 31, 9, 8, 36, 738, DateTimeKind.Local).AddTicks(9834) },
                    { 1, 2, new DateTime(2023, 8, 31, 9, 8, 36, 738, DateTimeKind.Local).AddTicks(9835), true, new DateTime(2023, 8, 31, 9, 8, 36, 738, DateTimeKind.Local).AddTicks(9836) },
                    { 2, 2, new DateTime(2023, 8, 31, 9, 8, 36, 738, DateTimeKind.Local).AddTicks(9837), true, new DateTime(2023, 8, 31, 9, 8, 36, 738, DateTimeKind.Local).AddTicks(9837) },
                    { 2, 3, new DateTime(2023, 8, 31, 9, 8, 36, 738, DateTimeKind.Local).AddTicks(9839), true, new DateTime(2023, 8, 31, 9, 8, 36, 738, DateTimeKind.Local).AddTicks(9839) },
                    { 3, 3, new DateTime(2023, 8, 31, 9, 8, 36, 738, DateTimeKind.Local).AddTicks(9840), true, new DateTime(2023, 8, 31, 9, 8, 36, 738, DateTimeKind.Local).AddTicks(9841) }
                });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "InsertedAt", "PostContent", "PostedOn", "ShortDescription", "Title", "UpdatedAt", "UrlSlug" },
                values: new object[] { new DateTime(2023, 8, 31, 9, 8, 36, 738, DateTimeKind.Local).AddTicks(9802), "The world of technology is evolving rapidly...", new DateTime(2023, 7, 17, 9, 8, 36, 738, DateTimeKind.Local).AddTicks(9796), "Exploring recent technological breakthroughs.", "Advancements in Technology", new DateTime(2023, 8, 31, 9, 8, 36, 738, DateTimeKind.Local).AddTicks(9802), "advancements-in-technology" });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "InsertedAt", "PostContent", "PostedOn", "ShortDescription", "Title", "UpdatedAt", "UrlSlug" },
                values: new object[] { new DateTime(2023, 8, 31, 9, 8, 36, 738, DateTimeKind.Local).AddTicks(9805), "Summer is here, and it's time to update your wardrobe...", new DateTime(2023, 7, 2, 9, 8, 36, 738, DateTimeKind.Local).AddTicks(9804), "Unveiling the hottest summer fashion trends.", "Summer Fashion Trends", new DateTime(2023, 8, 31, 9, 8, 36, 738, DateTimeKind.Local).AddTicks(9806), "summer-fashion-trends" });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "InsertedAt", "PostContent", "PostedOn", "ShortDescription", "Title", "UpdatedAt", "UrlSlug" },
                values: new object[] { new DateTime(2023, 8, 31, 9, 8, 36, 738, DateTimeKind.Local).AddTicks(9808), "Great literature stands the test of time...", new DateTime(2023, 6, 17, 9, 8, 36, 738, DateTimeKind.Local).AddTicks(9807), "Exploring timeless classics in literature.", "Classic Literature Masterpieces", new DateTime(2023, 8, 31, 9, 8, 36, 738, DateTimeKind.Local).AddTicks(9809), "classic-literature-masterpieces" });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Count", "Description", "InsertedAt", "Name", "UpdatedAt", "UrlSlug" },
                values: new object[] { 6, "Tags related to skincare and beauty routines.", new DateTime(2023, 8, 31, 9, 8, 36, 738, DateTimeKind.Local).AddTicks(9765), "Skincare", new DateTime(2023, 8, 31, 9, 8, 36, 738, DateTimeKind.Local).AddTicks(9766), "skincare" });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Count", "Description", "InsertedAt", "Name", "UpdatedAt", "UrlSlug" },
                values: new object[] { 4, "Tags related to interior design and decor ideas.", new DateTime(2023, 8, 31, 9, 8, 36, 738, DateTimeKind.Local).AddTicks(9768), "Interior Design", new DateTime(2023, 8, 31, 9, 8, 36, 738, DateTimeKind.Local).AddTicks(9768), "interior-design" });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Count", "Description", "InsertedAt", "Name", "UpdatedAt", "UrlSlug" },
                values: new object[] { 9, "Tags related to health and holistic wellness.", new DateTime(2023, 8, 31, 9, 8, 36, 738, DateTimeKind.Local).AddTicks(9770), "Wellness", new DateTime(2023, 8, 31, 9, 8, 36, 738, DateTimeKind.Local).AddTicks(9771), "wellness" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Count", "Description", "InsertedAt", "IsActive", "Name", "UpdatedAt", "UrlSlug" },
                values: new object[,]
                {
                    { 4, 2, "Tags related to toys and playtime.", new DateTime(2023, 8, 31, 9, 8, 36, 738, DateTimeKind.Local).AddTicks(9772), true, "Toys", new DateTime(2023, 8, 31, 9, 8, 36, 738, DateTimeKind.Local).AddTicks(9773), "toys" },
                    { 5, 11, "Tags related to different types of cuisines and food.", new DateTime(2023, 8, 31, 9, 8, 36, 738, DateTimeKind.Local).AddTicks(9774), true, "Cuisine", new DateTime(2023, 8, 31, 9, 8, 36, 738, DateTimeKind.Local).AddTicks(9775), "cuisine" }
                });

            migrationBuilder.InsertData(
                table: "PostTagMaps",
                columns: new[] { "PostId", "TagId", "InsertedAt", "IsActive", "UpdatedAt" },
                values: new object[] { 3, 4, new DateTime(2023, 8, 31, 9, 8, 36, 738, DateTimeKind.Local).AddTicks(9842), true, new DateTime(2023, 8, 31, 9, 8, 36, 738, DateTimeKind.Local).AddTicks(9843) });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CategoryId", "InsertedAt", "IsActive", "Modified", "PostContent", "PostedOn", "Published", "RateCount", "ShortDescription", "Title", "TotalRate", "UpdatedAt", "UrlSlug", "ViewCount" },
                values: new object[] { 4, 4, new DateTime(2023, 8, 31, 9, 8, 36, 738, DateTimeKind.Local).AddTicks(9811), true, false, "Your home should be a sanctuary of comfort and warmth...", new DateTime(2023, 6, 2, 9, 8, 36, 738, DateTimeKind.Local).AddTicks(9810), true, 0, "Tips for crafting a cozy and inviting home.", "Creating a Cozy Home Space", 0, new DateTime(2023, 8, 31, 9, 8, 36, 738, DateTimeKind.Local).AddTicks(9812), "creating-cozy-home-space", 0 });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CategoryId", "InsertedAt", "IsActive", "Modified", "PostContent", "PostedOn", "Published", "RateCount", "ShortDescription", "Title", "TotalRate", "UpdatedAt", "UrlSlug", "ViewCount" },
                values: new object[] { 5, 5, new DateTime(2023, 8, 31, 9, 8, 36, 738, DateTimeKind.Local).AddTicks(9814), true, false, "Outdoor sports offer not only physical benefits but also...", new DateTime(2023, 5, 23, 9, 8, 36, 738, DateTimeKind.Local).AddTicks(9813), true, 0, "Embracing an active lifestyle through outdoor sports.", "Staying Active with Outdoor Sports", 0, new DateTime(2023, 8, 31, 9, 8, 36, 738, DateTimeKind.Local).AddTicks(9815), "staying-active-outdoor-sports", 0 });

            migrationBuilder.InsertData(
                table: "PostTagMaps",
                columns: new[] { "PostId", "TagId", "InsertedAt", "IsActive", "UpdatedAt" },
                values: new object[,]
                {
                    { 5, 1, new DateTime(2023, 8, 31, 9, 8, 36, 738, DateTimeKind.Local).AddTicks(9849), true, new DateTime(2023, 8, 31, 9, 8, 36, 738, DateTimeKind.Local).AddTicks(9850) },
                    { 4, 4, new DateTime(2023, 8, 31, 9, 8, 36, 738, DateTimeKind.Local).AddTicks(9844), true, new DateTime(2023, 8, 31, 9, 8, 36, 738, DateTimeKind.Local).AddTicks(9844) },
                    { 4, 5, new DateTime(2023, 8, 31, 9, 8, 36, 738, DateTimeKind.Local).AddTicks(9846), true, new DateTime(2023, 8, 31, 9, 8, 36, 738, DateTimeKind.Local).AddTicks(9846) },
                    { 5, 5, new DateTime(2023, 8, 31, 9, 8, 36, 738, DateTimeKind.Local).AddTicks(9847), true, new DateTime(2023, 8, 31, 9, 8, 36, 738, DateTimeKind.Local).AddTicks(9848) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PostTagMaps_PostId",
                table: "PostTagMaps",
                column: "PostId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PostTagMaps",
                table: "PostTagMaps");

            migrationBuilder.DropIndex(
                name: "IX_PostTagMaps_PostId",
                table: "PostTagMaps");

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "PostTagMaps",
                keyColumns: new[] { "PostId", "TagId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "PostTagMaps",
                keyColumns: new[] { "PostId", "TagId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "PostTagMaps",
                keyColumns: new[] { "PostId", "TagId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "PostTagMaps",
                keyColumns: new[] { "PostId", "TagId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "PostTagMaps",
                keyColumns: new[] { "PostId", "TagId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "PostTagMaps",
                keyColumns: new[] { "PostId", "TagId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "PostTagMaps",
                keyColumns: new[] { "PostId", "TagId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "PostTagMaps",
                keyColumns: new[] { "PostId", "TagId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "PostTagMaps",
                keyColumns: new[] { "PostId", "TagId" },
                keyValues: new object[] { 4, 5 });

            migrationBuilder.DeleteData(
                table: "PostTagMaps",
                keyColumns: new[] { "PostId", "TagId" },
                keyValues: new object[] { 5, 5 });

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostTagMaps",
                table: "PostTagMaps",
                columns: new[] { "PostId", "TagId" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "InsertedAt", "Name", "UpdatedAt", "UrlSlug" },
                values: new object[] { "Explore the world of technology", null, "Technology", null, "technology" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "InsertedAt", "Name", "UpdatedAt", "UrlSlug" },
                values: new object[] { "Discover new places and cultures", null, "Travel", null, "travel" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "InsertedAt", "Name", "UpdatedAt", "UrlSlug" },
                values: new object[] { "Indulge in delicious cuisines", null, "Food", null, "food" });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "InsertedAt", "PostContent", "PostedOn", "ShortDescription", "Title", "UpdatedAt", "UrlSlug" },
                values: new object[] { null, "Entity Framework is a powerful Object-Relational Mapping (ORM) framework that enables developers to work with databases using .NET objects. It simplifies database interactions by allowing you to manipulate database records as objects, and it automatically generates SQL queries for you. With Entity Framework, you can define your data model using C# classes and then use LINQ (Language Integrated Query) to query and manipulate data.\n\nWhether you're building a simple application or a complex enterprise system, Entity Framework can help you manage the data layer efficiently. It supports various database providers, enabling you to work with different types of databases seamlessly.\n\nEntity Framework also provides features like migrations, tracking changes, and handling relationships between entities. This makes it a popular choice among .NET developers for building data-driven applications.", new DateTime(2023, 8, 31, 1, 29, 32, 973, DateTimeKind.Local).AddTicks(8429), "Learn about Entity Framework", "Introduction to Entity Framework", null, "introduction-to-ef" });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "InsertedAt", "PostContent", "PostedOn", "ShortDescription", "Title", "UpdatedAt", "UrlSlug" },
                values: new object[] { null, "Last week, I visited a city I had never been to before, and it turned out to be an amazing experience. The city was vibrant and full of life, with bustling markets, stunning architecture, and friendly locals. I explored its hidden alleys and iconic landmarks, trying local cuisine and immersing myself in the culture.\n\nOne of the highlights was a guided tour to learn about the city's history and traditions. I visited museums, art galleries, and even took a scenic boat ride along the river. It was a truly eye-opening journey that reminded me of the beauty of discovering new places and embracing different perspectives.", new DateTime(2023, 8, 31, 1, 29, 32, 973, DateTimeKind.Local).AddTicks(8441), "Traveling to an unknown city", "Exploring a New City", null, "exploring-new-city" });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "InsertedAt", "PostContent", "PostedOn", "ShortDescription", "Title", "UpdatedAt", "UrlSlug" },
                values: new object[] { null, "Food has a unique way of connecting people from different parts of the world. Exploring various cuisines is like embarking on a culinary adventure, allowing you to savor the flavors of different cultures.\n\nIn this post, I'll be sharing some of my favorite recipes from around the world. From the aromatic spices of Indian curries to the comforting pasta dishes of Italy, each recipe tells a story of tradition and innovation. Whether you're a seasoned chef or a beginner in the kitchen, I invite you to join me on this gastronomic journey.", new DateTime(2023, 8, 31, 1, 29, 32, 973, DateTimeKind.Local).AddTicks(8443), "Cooking up global delights", "Delicious Recipes from Around the World", null, "delicious-recipes" });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Count", "Description", "InsertedAt", "Name", "UpdatedAt", "UrlSlug" },
                values: new object[] { 3, "Coding and development topics", null, "Programming", null, "programming" });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Count", "Description", "InsertedAt", "Name", "UpdatedAt", "UrlSlug" },
                values: new object[] { 2, "Thrilling adventures and experiences", null, "Adventure", null, "adventure" });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Count", "Description", "InsertedAt", "Name", "UpdatedAt", "UrlSlug" },
                values: new object[] { 1, "Culinary delights from various cultures", null, "Cuisine", null, "cuisine" });

            migrationBuilder.CreateIndex(
                name: "IX_PostTagMaps_TagId",
                table: "PostTagMaps",
                column: "TagId");
        }
    }
}

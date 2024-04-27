using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MentalHealthAppAPI.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn), // Adjusted for MySQL
                    UserId = table.Column<int>(nullable: false),
                    Username = table.Column<string>(type: "varchar(255)", nullable: false), // Adjusted type
                    ProfileImage = table.Column<string>(type: "text", nullable: false), // Adjusted type
                    PostTitle = table.Column<string>(type: "text", nullable: false), // Adjusted type
                    PostLabel = table.Column<string>(type: "text", nullable: false), // Adjusted type
                    PostMediaUri = table.Column<string>(type: "text", nullable: false), // Adjusted type
                    PostTime = table.Column<DateTime>(type: "datetime", nullable: false), // Adjusted type
                    Likes = table.Column<int>(nullable: false),
                    Comments = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}

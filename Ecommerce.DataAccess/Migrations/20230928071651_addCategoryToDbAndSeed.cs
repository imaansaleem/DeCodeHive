using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ecommerce.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addCategoryToDbAndSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ListPrice = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Price50 = table.Column<double>(type: "float", nullable: false),
                    Price100 = table.Column<double>(type: "float", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "DisplayOrder", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Design Patterns" },
                    { 2, 2, "Database Design" },
                    { 3, 3, "Programming Languages" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "CategoryId", "Description", "ISBN", "ListPrice", "Price", "Price100", "Price50", "Title" },
                values: new object[,]
                {
                    { 1, "Robert C. Martin", 1, "It emphasizes clean code practices and design principles", "0132350882", 99.0, 90.0, 80.0, 85.0, "Clean Code" },
                    { 2, "Robert Nystrom", 1, "It covers patterns that are useful in the creation of Games", "0990582906", 40.0, 30.0, 20.0, 25.0, "Game Programming" },
                    { 3, "Markus Winand", 2, "It provides insights to improve performance of database applications", " 3950307820", 30.0, 27.0, 20.0, 25.0, "SQL Performance" },
                    { 4, "Martin Kleppmann", 2, "It covers various aspects of databases, data storage, and distributed systems.", "1449373321", 25.0, 23.0, 20.0, 22.0, "Data-Intensive Applications" },
                    { 5, "Steve McConnell", 3, "It offers practical techniques for writing high-quality code.", "0735619670", 55.0, 50.0, 35.0, 40.0, "Code Complete" },
                    { 6, "Andrew Hunt, David Thomas", 3, "It covers programming techniques and project management.", " 020161622X", 70.0, 65.0, 55.0, 60.0, "Pragmatic Programmer" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}

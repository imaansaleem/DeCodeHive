using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ecommerce.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class DatabaseCreation : Migration
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
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                columns: new[] { "Id", "Author", "CategoryId", "Description", "ISBN", "ImageUrl", "ListPrice", "Price", "Price100", "Price50", "Title" },
                values: new object[,]
                {
                    { 1, "Robert C. Martin", 1, "<p><strong>\"Don't Make Me Think\"</strong> by Steve Krug is a timeless guide to web usability, emphasizing a <strong>common-sense approach</strong>. Krug's insights on usability <strong>testing</strong>, <strong>navigation</strong>, and <strong>accessibility </strong>make it essential for web designers and developers seeking to create <em>user-friendly </em>websites.</p>", "0132350882", "\\images\\product\\d10bc571-0a5e-407d-8546-d9557acd8434.png", 99.0, 90.0, 80.0, 85.0, "Don't Make Me Think" },
                    { 2, "Robert Nystrom", 3, "<p><strong>\"The Art of Invisibility\"</strong> is a <strong>must-read</strong> guide to <strong>online privacy</strong> and <strong>digital security</strong>. In this book, the author provides <strong>vital strategies</strong> and <strong>real-world tactics</strong> to help readers protect their <strong>online identity</strong> and maintain <strong>personal privacy</strong> in today's digital age.</p>", "0990582906", "\\images\\product\\a0b3312a-a83d-467b-a576-9fb46c51c73d.png", 40.0, 30.0, 20.0, 25.0, "The Art of Invisibility" },
                    { 3, "Markus Winand", 2, "<p><strong>\"Database Design for Mere Mortals\"</strong> is an essential <strong>guide</strong> for anyone interested in <strong>database design</strong>. It takes a <strong>practical</strong>, <strong>easy-to-follow</strong> approach to database concepts and design, making it perfect for <strong>beginners</strong> and <strong>professionals</strong> alike.</p>", " 3950307820", "\\images\\product\\cb840f66-4022-4c7d-b29d-cd568f481140.png", 30.0, 27.0, 20.0, 25.0, "Database Design Mere Mortals" },
                    { 4, "Martin Kleppmann", 2, "<p><strong>\"Fundamentals of DBMS\"</strong> provides a solid foundation in <strong>Database Management Systems (DBMS)</strong>. This book offers <strong>comprehensive insights</strong> into database concepts, making it a <strong>crucial resource</strong> for <strong>students</strong> and <strong>professionals</strong> looking to grasp the core principles of DBMS.</p>", "1449373321", "\\images\\product\\e5c35414-2b59-4310-b91c-d5ffe400e70c.png", 25.0, 23.0, 20.0, 22.0, "Fundamentals of DBMS" },
                    { 5, "Steve McConnell", 3, "<p><strong>\"A Quick Guide to C# Programming\"</strong> is a <strong>fast-track</strong> resource for learning C# programming. With its <strong>concise explanations</strong> and <strong>hands-on examples</strong>, this book is ideal for <strong>beginners</strong> and <strong>intermediate</strong> programmers looking to master C# quickly.</p>", "0735619670", "\\images\\product\\a80ba6f9-3975-4ee1-aec4-def04cc33fc7.png", 55.0, 50.0, 35.0, 40.0, "A Quick Guide to C# Programming" },
                    { 6, "Andrew Hunt", 1, "<p><strong>\"The Pragmatic Programmer\"</strong> is an <strong>indispensable resource</strong> for software developers. This book offers <strong>practical advice</strong> and <strong>timeless wisdom</strong> for becoming a more effective and efficient programmer. It is a <strong>must-read</strong> for both <strong>novice</strong> and <strong>experienced</strong> developers seeking to elevate their coding skills and practices.</p>", "020161622X", "\\images\\product\\5f2f504e-2cf1-4683-8b51-84b5e472e9ef.png", 70.0, 65.0, 55.0, 60.0, "The Pragmatic Programmer" },
                    { 7, "Alex Xu", 1, "<p>It provides a comprehensive guide for <strong>software engineers</strong> preparing for&nbsp;<em>technical interviews </em>focused on system design. It offers <strong>valuable insights</strong>, <strong>practical advice</strong>, and <strong>real-world examples</strong> to help readers tackle complex system design questions effectively.&nbsp;</p>", "978-1718501151", "\\images\\product\\efd94755-46bc-4f50-a716-d750228f5c20.png", 90.0, 85.0, 70.0, 80.0, "System Design Interview" },
                    { 8, "John Smith", 3, "<p>It is an excellent resource for those looking to learn <strong>Python </strong>from <em>scratch</em>. It covers<strong> fundamental concepts </strong>and practical examples to help <strong>beginners </strong>build a strong foundation in <strong>Python programming</strong>.&nbsp;</p>", "978-1234567890", "\\images\\product\\bcce6385-9f66-470c-8724-cb58311908e8.png", 92.0, 88.0, 80.0, 85.0, "Python Programming" },
                    { 9, "Emily Johnson", 2, "<p>&nbsp;It is an <em>indispensable </em>guide for anyone working with data &nbsp;for <strong>data professionals </strong>and <strong>analysts </strong>with the skills needed to <strong>clean, reshape, and transform data </strong>effectively using <strong>SQL. </strong>. It offers <em>practical guidance</em> on using <strong>SQL </strong>for <strong>data cleansing</strong>, <strong>transformation</strong>, and <strong>manipulation</strong>.&nbsp;</p>", "978-0987654321", "\\images\\product\\4260ed8a-af8f-4299-bd86-2a6a0518bca2.png", 83.0, 76.0, 65.0, 70.0, "Data Wrangling with SQL" }
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

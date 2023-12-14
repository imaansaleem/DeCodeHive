using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Ecommerce.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser> //all tables data is in DbContent
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        //This line will create a table using Microsoft framework
        //property: DbSet Entity: Class(Category) Table name: Categories
        public DbSet<Category>Categories{get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }

        //Already defined this function in entity framework and we are overriding one
        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
            base.OnModelCreating(modelBuilder);

			//we are telling entity framework core on category, we want to create these three records.
			modelBuilder.Entity<Category>().HasData(
				new Category { Id = 1, Name = "Design Patterns", DisplayOrder = 1 },
				new Category { Id = 2, Name = "Database Design", DisplayOrder = 2 },
				new Category { Id = 3, Name = "Programming Languages", DisplayOrder = 3 }
				);

            modelBuilder.Entity<Company>().HasData(
                new Company
                {
                    Id = 1,
                    Name = "Bookworm Haven",
                    StreetAddress = "1234 Reading Lane",
                    City = "Literaryville",
                    State = "Booktopia",
                    PostalCode = "54321",
                    PhoneNumber = "03433938724"
                },
                new Company
                {
                    Id = 2,
                    Name = "Novel Nook",
                    StreetAddress = "567 Fiction Street",
                    City = "Imaginaria",
                    State = "Storyland",
                    PostalCode = "98765",
                    PhoneNumber = "03345938724"
                },
                new Company
                {
                    Id = 3,
                    Name = "Paperback Paradise",
                    StreetAddress = "789 Adventure Avenue",
                    City = "Plotville",
                    State = "Proseville",
                    PostalCode = "24680",
                    PhoneNumber = "03332468024"
                });


            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 1,
                Title = "Don't Make Me Think",
                Author = "Robert C. Martin",
                Description = "<p><strong>\"Don't Make Me Think\"</strong> by Steve Krug is a timeless guide to web usability, emphasizing a <strong>common-sense approach</strong>. Krug's insights on usability <strong>testing</strong>, <strong>navigation</strong>, and <strong>accessibility </strong>make it essential for web designers and developers seeking to create <em>user-friendly </em>websites.</p>",
                ISBN = "0132350882",
                ListPrice = 99,
                Price = 90,
                Price50 = 85,
                Price100 = 80,
                CategoryId = 1,
                ImageUrl = "\\images\\product\\d10bc571-0a5e-407d-8546-d9557acd8434.png"
            },
            new Product
            {
                Id = 2,
                Title = "The Art of Invisibility",
                Author = "Robert Nystrom",
                Description = "<p><strong>\"The Art of Invisibility\"</strong> is a <strong>must-read</strong> guide to <strong>online privacy</strong> and <strong>digital security</strong>. In this book, the author provides <strong>vital strategies</strong> and <strong>real-world tactics</strong> to help readers protect their <strong>online identity</strong> and maintain <strong>personal privacy</strong> in today's digital age.</p>",
                ISBN = "0990582906",
                ListPrice = 40,
                Price = 30,
                Price50 = 25,
                Price100 = 20,
                CategoryId = 3,
                ImageUrl = "\\images\\product\\a0b3312a-a83d-467b-a576-9fb46c51c73d.png"
            },

            new Product
            {
                Id = 3,
                Title = "Database Design Mere Mortals",
                Author = "Markus Winand",
                Description = "<p><strong>\"Database Design for Mere Mortals\"</strong> is an essential <strong>guide</strong> for anyone interested in <strong>database design</strong>. It takes a <strong>practical</strong>, <strong>easy-to-follow</strong> approach to database concepts and design, making it perfect for <strong>beginners</strong> and <strong>professionals</strong> alike.</p>",
                ISBN = " 3950307820",
                ListPrice = 30,
                Price = 27,
                Price50 = 25,
                Price100 = 20,
                CategoryId = 2,
                ImageUrl = "\\images\\product\\cb840f66-4022-4c7d-b29d-cd568f481140.png"
            },
            new Product
            {
                Id = 4,
                Title = "Fundamentals of DBMS",
                Author = "Martin Kleppmann",
                Description = "<p><strong>\"Fundamentals of DBMS\"</strong> provides a solid foundation in <strong>Database Management Systems (DBMS)</strong>. This book offers <strong>comprehensive insights</strong> into database concepts, making it a <strong>crucial resource</strong> for <strong>students</strong> and <strong>professionals</strong> looking to grasp the core principles of DBMS.</p>",
                ISBN = "1449373321",
                ListPrice = 25,
                Price = 23,
                Price50 = 22,
                Price100 = 20,
                CategoryId = 2,
                ImageUrl = "\\images\\product\\e5c35414-2b59-4310-b91c-d5ffe400e70c.png"
            },
            new Product
            {
                Id = 5,
                Title = "A Quick Guide to C# Programming",
                Author = "Steve McConnell",
                Description = "<p><strong>\"A Quick Guide to C# Programming\"</strong> is a <strong>fast-track</strong> resource for learning C# programming. With its <strong>concise explanations</strong> and <strong>hands-on examples</strong>, this book is ideal for <strong>beginners</strong> and <strong>intermediate</strong> programmers looking to master C# quickly.</p>",
                ISBN = "0735619670",
                ListPrice = 55,
                Price = 50,
                Price50 = 40,
                Price100 = 35,
                CategoryId = 3,
                ImageUrl = "\\images\\product\\a80ba6f9-3975-4ee1-aec4-def04cc33fc7.png"
            },
            new Product
            {
                Id = 6,
                Title = "The Pragmatic Programmer",
                Author = "Andrew Hunt",
                Description = "<p><strong>\"The Pragmatic Programmer\"</strong> is an <strong>indispensable resource</strong> for software developers. This book offers <strong>practical advice</strong> and <strong>timeless wisdom</strong> for becoming a more effective and efficient programmer. It is a <strong>must-read</strong> for both <strong>novice</strong> and <strong>experienced</strong> developers seeking to elevate their coding skills and practices.</p>",
                ISBN = "020161622X",
                ListPrice = 70,
                Price = 65,
                Price50 = 60,
                Price100 = 55,
                CategoryId = 1,
                ImageUrl = "\\images\\product\\5f2f504e-2cf1-4683-8b51-84b5e472e9ef.png"
            },
            new Product
            {
                Id = 7,
                Title = "System Design Interview",
                Author = "Alex Xu",
                Description = "<p>It provides a comprehensive guide for <strong>software engineers</strong> preparing for&nbsp;<em>technical interviews </em>focused on system design. It offers <strong>valuable insights</strong>, <strong>practical advice</strong>, and <strong>real-world examples</strong> to help readers tackle complex system design questions effectively.&nbsp;</p>",
                ISBN = "978-1718501151",
                ListPrice = 90,
                Price = 85,
                Price50 = 80,
                Price100 = 70,
                CategoryId = 1,
                ImageUrl = "\\images\\product\\efd94755-46bc-4f50-a716-d750228f5c20.png"
            },
            new Product
            {
                Id = 8,
                Title = "Python Programming",
                Author = "John Smith",
                Description = "<p>It is an excellent resource for those looking to learn <strong>Python </strong>from <em>scratch</em>. It covers<strong> fundamental concepts </strong>and practical examples to help <strong>beginners </strong>build a strong foundation in <strong>Python programming</strong>.&nbsp;</p>",
                ISBN = "978-1234567890",
                ListPrice = 92,
                Price = 88,
                Price50 = 85,
                Price100 = 80,
                CategoryId = 3,
                ImageUrl = "\\images\\product\\bcce6385-9f66-470c-8724-cb58311908e8.png"
            },
            new Product
            {
                Id = 9,
                Title = "Data Wrangling with SQL",
                Author = "Emily Johnson",
                Description = "<p>&nbsp;It is an <em>indispensable </em>guide for anyone working with data &nbsp;for <strong>data professionals </strong>and <strong>analysts </strong>with the skills needed to <strong>clean, reshape, and transform data </strong>effectively using <strong>SQL. </strong>. It offers <em>practical guidance</em> on using <strong>SQL </strong>for <strong>data cleansing</strong>, <strong>transformation</strong>, and <strong>manipulation</strong>.&nbsp;</p>",
                ISBN = "978-0987654321",
                ListPrice = 83,
                Price = 76,
                Price50 = 70,
                Price100 = 65,
                CategoryId = 2,
                ImageUrl = "\\images\\product\\4260ed8a-af8f-4299-bd86-2a6a0518bca2.png"
            });

        }

    }

}

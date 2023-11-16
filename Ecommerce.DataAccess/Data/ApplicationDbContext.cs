using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.DataAccess.Data
{
    public class ApplicationDbContext : DbContext //all tables data is in DbContent
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        //This line will create a table using Microsoft framework
        //property: DbSet Entity: Class(Category) Table name: Categories
        public DbSet<Category>Categories{get; set; }
        public DbSet<Product> Products { get; set; }

        //Already defined this function in entity framework and we are overriding one
        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//we are telling entity framework core on category, we want to create these three records.
			modelBuilder.Entity<Category>().HasData(
				new Category { Id = 1, Name = "Design Patterns", DisplayOrder = 1 },
				new Category { Id = 2, Name = "Database Design", DisplayOrder = 2 },
				new Category { Id = 3, Name = "Programming Languages", DisplayOrder = 3 }
				);

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 1,
                Title = "Clean Code",
                Author = "Robert C. Martin",
                Description = "It emphasizes clean code practices and design principles",
                ISBN = "0132350882",
                ListPrice = 99,
                Price = 90,
                Price50 = 85,
                Price100 = 80,
                CategoryId = 1
            },
            new Product {
                Id = 2,
                Title = "Game Programming",
                Author = "Robert Nystrom",
                Description = "It covers patterns that are useful in the creation of Games",
                ISBN = "0990582906",
                ListPrice = 40,
                Price = 30,
                Price50 = 25,
                Price100 = 20,
                CategoryId = 1
            },

            new Product
            {
                Id = 3,
                Title = "SQL Performance",
                Author = "Markus Winand",
                Description = "It provides insights to improve performance of database applications",
                ISBN = " 3950307820",
                ListPrice = 30,
                Price = 27,
                Price50 = 25,
                Price100 = 20,
                CategoryId = 2
            },
            new Product
            {
                Id = 4,
                Title = "Data-Intensive Applications",
                Author = "Martin Kleppmann",
                Description = "It covers various aspects of databases, data storage, and distributed systems.",
                ISBN = "1449373321",
                ListPrice = 25,
                Price = 23,
                Price50 = 22,
                Price100 = 20,
                CategoryId = 2
            },
            new Product
            {
                Id = 5,
                Title = "Code Complete",
                Author = "Steve McConnell",
                Description = "It offers practical techniques for writing high-quality code.",
                ISBN = "0735619670",
                ListPrice = 55,
                Price = 50,
                Price50 = 40,
                Price100 = 35,
                CategoryId = 3
            },
            new Product
            {
                Id = 6,
                Title = "Pragmatic Programmer",
                Author = "Andrew Hunt, David Thomas",
                Description = "It covers programming techniques and project management.",
                ISBN = " 020161622X",
                ListPrice = 70,
                Price = 65,
                Price50 = 60,
                Price100 = 55,
                CategoryId = 3
            }) ;
		}

	}

}

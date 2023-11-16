using EcommerceWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceWeb.Data
{
    public class ApplicationDbContext : DbContext //all tables data is in DbContent
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        //This line will create a table using Microsoft framework
        //property: DbSet Entity: Class(Category) Table name: Categories
        public DbSet<Category>Categories{get; set; }

		//Already defined this function in entity framework and we are overriding one
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//we are telling entity framework core on category, we want to create these three records.
			modelBuilder.Entity<Category>().HasData(
				new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
				new Category { Id = 2, Name = "SciFi", DisplayOrder = 2 },
				new Category { Id = 3, Name = "History", DisplayOrder = 3 }
				);
		}

	}

}

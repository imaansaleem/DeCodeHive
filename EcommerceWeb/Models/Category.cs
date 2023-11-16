using System.ComponentModel.DataAnnotations;

namespace EcommerceWeb.Models
{
	public class Category
	{
		//primary key of table
		[Key]
		public int Id { get; set; }
		//name of the order
		[Required]
		public string Name { get; set; }
		//We have a lot of categories which category to display first on the page
		public int DisplayOrder { get; set; }
	}
}

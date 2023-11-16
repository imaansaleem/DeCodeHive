using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Models
{
	public class Category
	{
		//primary key of table
		[Key]
		public int Id { get; set; }


		//name of the order
		[Required]
		//Validations
		//max length of name can be 30 characters
		[MaxLength(30)]
		//It tells how Datamembers must be printed on screen 
		[DisplayName("Category Name")]
		public string Name { get; set; }


        [DisplayName("Display Order")]
		[Range(1,100)]
        //We have a lot of categories which category to display first on the page
        public int DisplayOrder { get; set; }
	}
}

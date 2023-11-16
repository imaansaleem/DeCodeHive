using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.ComponentModel.DataAnnotations.Schema;

//product that will contain all of the books of our website and that will have a category.
//We need CRUD operations on book

namespace Ecommerce.Models
{
    public class Product
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public string ISBN { get; set; }

        [Required]
        public string Author { get; set; }

        //We are selling in bulk so
        //So if Customr buy more books, they will get more discount for that.

        [Required]
        [Display(Name = "List Price")]
        [Range(1, 1000)]
        //list price will be a different price depending on amount of books they are buying
        public double ListPrice { get; set; }

        [Required]
        [Display(Name = "List Price")]
        [Range(1, 1000)]
        public double Price { get; set; }

        [Required]
        [Display(Name = "Price for 1-50")]
        [Range(1, 1000)]
        //Price 50 will be the price for more than 50 quantity
        public double Price50 { get; set; }

        [Required]
        [Display(Name = "Price for 100+")]
        [Range(1, 1000)]
        //Price 100 will be the price for more than 100 quantity
        public double Price100 { get; set; }


        //We just need to tell these three things to entity framework and rest of it is handled by itself
        public int CategoryId{ get; set; }

        //This Category table has a foreign key which will be Category Id
        [ForeignKey("CategoryId")]

        //navigation property to category table
        public Category Category { get; set; }
    }
}

using EcommerceWeb.Data;
using EcommerceWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceWeb.Controllers
{
	public class CategoryController : Controller
	{
		private readonly ApplicationDbContext _db;
		public CategoryController(ApplicationDbContext db)
		{
			_db = db;
		}
		public IActionResult Index()
		{
			//It will go to the database, run the command, select star from categories, retrieve that and assign it to the object right here.
			List<Category> objCategoryList  = _db.Categories.ToList();

			//And then in the view, we have to fetch that and extract and display all the categories.
			return View(objCategoryList);
		}

		//Method to invoke view of Add category button
        public IActionResult Create()
		{
			return View();
            //didn't passed object no need as it is category type, it will create itself new category object with the default values.
        }

    }
}

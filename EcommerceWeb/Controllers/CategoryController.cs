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

		//Create a new resource that is got in form if it does not exist. 
		[HttpPost]
        //when post is hit, we will be getting the category object
        //No need to write queries, entity framework is handling everything
        public IActionResult Create(Category obj)
        {
			if(obj.Name == obj.DisplayOrder.ToString())
			{
				ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
			}

            //if display and name both are valid then only it will continue to add in database
            if (ModelState.IsValid)
			{
                //Getting which object to add in database
                _db.Categories.Add(obj);

                //category inserted in data base
                _db.SaveChanges();

                //Temp data will render when we move to index page after creating data
                TempData["success"] = "Category Created Successfully";

				//return back to index page
				return RedirectToAction("Index");
            }
            return View();
        }

        //Get action
        //which id to remove
        //? shows initially id is missing
        public IActionResult Edit(int? id)
        {
            if (id == null || id==0) 
            {
                return NotFound();
            }

            Category? categoryFromDb = _db.Categories.Find(id);
            if(categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
 
        [HttpPost]
        public IActionResult Edit(Category obj)
        { 
            if (ModelState.IsValid)
            {
                //It will update obj based on id
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category Updated Successfully";
                return RedirectToAction("Index");
            }
            return View();
        }


        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Category? categoryFromDb = _db.Categories.Find(id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        //Need to specify here as method is different

        [HttpPost, ActionName("Delete")]
        //we write different method here as the parameters of both functions were same 
        public IActionResult DeletePOST(int? id)
        {
            Category? obj = _db.Categories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Category Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}

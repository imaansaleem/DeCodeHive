using Ecommerce.DataAccess.Data;
using Ecommerce.DataAccess.Repository.IRepository;
using Ecommerce.Models;
using Ecommerce.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceWeb.Areas.Admin.Controllers
{

    //Telling a controller that you belongs to this area
    [Area("Admin")]

    //if somebody is not admin then even after placing the same link he must not be ble to configure controller
    //[Authorize(Roles = SD.Role_Admin)]
    public class CategoryController :  Controller
    {
        //private readonly ApplicationDbContext _db;
        //replace all ApplicationDbContext with ICategoryRepository
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            //It will go to the database, run the command, select star from categories, retrieve that and assign it to the object right here.
            //List<Category> objCategoryList  = _db.Categories.ToList();
            List<Category> objCategoryList = _unitOfWork.Category.GetAll().ToList();

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
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
            }

            //if display and name both are valid then only it will continue to add in database
            if (ModelState.IsValid)
            {
                //Getting which object to add in database
                _unitOfWork.Category.Add(obj);

                //category inserted in data base
                _unitOfWork.Save();

                //Temp data will render when we move to index page after creating data
                Response.Cookies.Append("SuccessMessage", "Category Created Successfully");

                // Set a flag to "false" in the same cookie
                Response.Cookies.Append("SuccessMessageDisplayed", "false");

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
            if (id == null || id == 0)
            {
                return NotFound();
            }

            //Get(query so that is could be evaluated with where in IRepository)
            Category? categoryFromDb = _unitOfWork.Category.Get(u => u.Id == id);
            if (categoryFromDb == null)
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
                _unitOfWork.Category.Update(obj);
                _unitOfWork.Save();
                // Set a cookie with the success message
                Response.Cookies.Append("SuccessMessage", "Category Updated Successfully");
                // Set a flag to "false" in the same cookie
                Response.Cookies.Append("SuccessMessageDisplayed", "false");
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

            Category? categoryFromDb = _unitOfWork.Category.Get(u => u.Id == id);
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
            Category? obj = _unitOfWork.Category.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Category.Remove(obj);
            _unitOfWork.Save();
            Response.Cookies.Append("SuccessMessage", "Category Deleted Successfully");
            // Set a flag to "false" in the same cookie
            Response.Cookies.Append("SuccessMessageDisplayed", "false");
            return RedirectToAction("Index");
        }
    }
}

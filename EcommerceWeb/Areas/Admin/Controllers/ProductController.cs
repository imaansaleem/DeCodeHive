using Ecommerce.DataAccess.Data;
using Ecommerce.DataAccess.Repository.IRepository;
using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceWeb.Areas.Admin.Controllers
{

    //Telling a controller that you belongs to this area
    [Area("Admin")]
    public class ProductController :  Controller
    {
        //private readonly ApplicationDbContext _db;
        //replace all ApplicationDbContext with ICategoryRepository
        private readonly IUnitOfWork _unitOfWork;
        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            //It will go to the database, run the command, select star from categories, retrieve that and assign it to the object right here.
            List<Product> objProductList = _unitOfWork.Product.GetAll().ToList();

            //And then in the view, we have to fetch that and extract and display all the categories.
            return View(objProductList);
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
        public IActionResult Create(Product obj)
        {

            //if display and name both are valid then only it will continue to add in database
            if (ModelState.IsValid)
            {
                //Getting which object to add in database
                _unitOfWork.Product.Add(obj);

                //category inserted in data base
                _unitOfWork.Save();

                //Temp data will render when we move to index page after creating data
                TempData["success"] = "Product Created Successfully";

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
            Product? productFromDb = _unitOfWork.Product.Get(u => u.Id == id);
            if (productFromDb == null)
            {
                return NotFound();
            }
            return View(productFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Product obj)
        {
            if (ModelState.IsValid)
            {
                //It will update obj based on id
                _unitOfWork.Product.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Product Updated Successfully";
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

            Product? productFromDb = _unitOfWork.Product.Get(u => u.Id == id);
            if (productFromDb == null)
            {
                return NotFound();
            }
            return View(productFromDb);
        }

        //Need to specify here as method is different

        [HttpPost, ActionName("Delete")]
        //we write different method here as the parameters of both functions were same 
        public IActionResult DeletePOST(int? id)
        {
            Product? obj = _unitOfWork.Product.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Product.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Product Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}

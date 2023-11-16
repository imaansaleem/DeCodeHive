using Ecommerce.DataAccess.Data;
using Ecommerce.DataAccess.Repository.IRepository;
using Ecommerce.Models;
using Ecommerce.Models.ViewModels;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using NuGet.Protocol.Plugins;
using System.Drawing.Drawing2D;

namespace EcommerceWeb.Areas.Admin.Controllers
{

    //Telling a controller that you belongs to this area
    [Area("Admin")]
    public class ProductController :  Controller
    {
        //private readonly ApplicationDbContext _db;
        //replace all ApplicationDbContext with ICategoryRepository
        private readonly IUnitOfWork _unitOfWork;

        //The uploaded image url must be saved inside images folder
        //We need access to that but how
        //.net provide class to do that just create its object and call WebRootPath where you have to receive
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<Product> objProductList = _unitOfWork.Product.GetAll(includeProperties:"Category").ToList();

            return View(objProductList);
        }

        //Update + insert = upsert
        //this will be handling creating and editing data
        public IActionResult Upsert(int? id)
        {
            //Need List of Categories to make drop down
            //SelectListItem is datatype that saves id and values
            // _unitOfWork.Category.GetAll().ToList(); need to be type casted so we will use projection
            //u is random object to return a new select list item
            //what will happen is each category object here will be converted into a select list item with text and value
            //Lets do that in class View Model
            //It is designed specifically for view

            ProductVM productVM = new()
            {
                //setting datamembers
                CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                Product = new Product()
            };

            if(id == null || id == 0)
            {
                return View(productVM);
            }

            else
            {
                productVM.Product = _unitOfWork.Product.Get(u => u.Id == id);
                return View(productVM);
            }

            //Now we need to pass that in view and we cannot pass 2 objects in view at a time
            //Product object is already binded there  
            //So we created productVM class in such a way that is has product and list both and we will bind that inside view
        }

        //Create a new resource that is got in form if it does not exist. 
        [HttpPost]
        //when post is hit, we will be getting the category object
        //No need to write queries, entity framework is handling everything
        public IActionResult Upsert(ProductVM productVM, IFormFile? file)
        {
            //if display and name both are valid then only it will continue to add in database
            if (ModelState.IsValid)
            {
                //gives path of wwwroot folder
                string wwwRootPath = _webHostEnvironment.WebRootPath;

                if(file != null) 
                { 
                    //that will overwrite the current name of file that user uploaded and give random name to it
                    // + extension of file
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

                    //Path of image folder
                    string productPath = Path.Combine(wwwRootPath, @"images\product");

                    //need to delete if file exist
                    if(!string.IsNullOrEmpty(productVM.Product.ImageUrl))
                    {
                        //dont forget to remove \ from url to locate file
                        var oldImagePath = Path.Combine(wwwRootPath, productVM.Product.ImageUrl.TrimStart('\\'));

                        //delete file
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    //creating a new file
                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        //Placing image to folder by
                        file.CopyTo(fileStream);
                    }

                    //Save URL as datamember
                    productVM.Product.ImageUrl = @"\images\product\"+fileName;
                }

                if(productVM.Product.Id == 0) 
                {
                    //Getting which object to add in database
                    _unitOfWork.Product.Add(productVM.Product);
                    TempData["success"] = "Product Created Successfully";

                }
                else
                {
                    _unitOfWork.Product.Update(productVM.Product);
                    TempData["success"] = "Product Updated Successfully";
                }
                //category inserted in data base
                _unitOfWork.Save();


                //return back to index page
                return RedirectToAction("Index");
            }
            else
            {
                //just show dropdown again if not valid
                productVM.CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });
                return View(productVM);
            }
        }

        //for database filters
        #region API CALLS
        [HttpGet]
        public IActionResult GetAll() 
        {
            List<Product> objProductList = _unitOfWork.Product.GetAll(includeProperties: "Category").ToList();
            return Json(new { data = objProductList });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var productToBeDeleted = _unitOfWork.Product.Get(u=>u.Id == id);
            if (productToBeDeleted == null)
            {
                return Json(new {success = false, message = "Error while deleting"});
            }

            //delete file
            var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, productToBeDeleted.ImageUrl.TrimStart('\\'));

            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }

            _unitOfWork.Product.Remove(productToBeDeleted);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Delete Successfully"});
        }

        #endregion
    }
}

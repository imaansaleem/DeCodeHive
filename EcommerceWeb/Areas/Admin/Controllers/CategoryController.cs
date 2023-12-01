using Ecommerce.DataAccess.Data;
using Ecommerce.DataAccess.Repository.IRepository;
using Ecommerce.Models;
using Ecommerce.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceWeb.Areas.Admin.Controllers
{

    public class CategoryController :  Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _unitOfWork.Category.GetAll().ToList();
            return View(objCategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
            }

            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Add(obj);

                _unitOfWork.Save();
                Response.Cookies.Append("SuccessMessage", "Category Created Successfully");

                Response.Cookies.Append("SuccessMessageDisplayed", "false");

                return RedirectToAction("Index");
            }
            return View();
        }
        
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

using Ecommerce.DataAccess.Repository.IRepository;
using Ecommerce.Models;
using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Diagnostics;
using System.Security.Claims;

namespace EcommerceWeb.Areas.Customer.Controllers
{
    //Telling a controller that you belongs to this area
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> productList = _unitOfWork.Product.GetAll(includeProperties: "Category");
            return View(productList);
        }

        public IActionResult Details(int productId)
        {
            ShoppingCart cart = new()
            {
                Product = _unitOfWork.Product.Get(u => u.Id == productId, includeProperties: "Category"),
                Count = 1,
                ProductId = productId
            };
            return View(cart);
        }

        [HttpPost]
        //user must be logged in
        [Authorize]
        public IActionResult Details(ShoppingCart shoppingCart)
        {
            //this builtin functions contains user id of logged in person
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            //user ID is inside the claims identity
            //NameIdentifier is constant value where id is saved
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            shoppingCart.ApplicationUserId = userId;

            //if same product is added to database earlier then only change the count and not add new
            ShoppingCart cartFromDb = _unitOfWork.ShoppingCart.Get(u=>u.ApplicationUserId==userId && u.ProductId==shoppingCart.ProductId);
            //Add to shopping cart
            if(cartFromDb != null)
            {
                cartFromDb.Count += shoppingCart.Count;
                _unitOfWork.ShoppingCart.Update(cartFromDb);
            }
            else
            {
                _unitOfWork.ShoppingCart.Add(shoppingCart);
            }
            TempData["success"] = "Cart Updated Successfully";
            _unitOfWork.Save();
            return RedirectToAction("Index"); 
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

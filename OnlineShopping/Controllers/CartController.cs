using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShopping.Models;
using System.Data;

namespace OnlineShopping.Controllers
{
    [Authorize(Roles = "Guest")]
    public class CartController : Controller
    {
        CartManager cartManager = new CartManager(new EfCartDal());
        Context context = new Context();
        private readonly UserManager<AppUser> _userManager;

        public CartController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> AddCart(AddCartViewModel addCart)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            Cart cart = new Cart()
            {
                CartID = addCart.Id,
                Count = addCart.Count,
                UserID = values.Id,
                ProductID = addCart.ProductID,
                AddDateTime = DateTime.Parse(DateTime.Now.ToShortTimeString())
            };
            cartManager.TAdd(cart);
            return RedirectToAction("CartList");
        }

        public IActionResult DeleteCart(int id)
        {
            var value = cartManager.TGetByID(id);
            cartManager.TDelete(value);
            return RedirectToAction("CartList");
        }

        public async Task<IActionResult> CartList() 
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var value = cartManager.GetListByUserID().Where(x => x.UserID == values.Id).ToList();
            return View(value);
        }
    }
}

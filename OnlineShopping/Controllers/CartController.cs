using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using OnlineShopping.Models;

namespace OnlineShopping.Controllers
{
    public class CartController : Controller
    {
        CartManager cartManager = new CartManager(new EfCartDal());
        Context context = new Context();
        public IActionResult AddCart(AddCartViewModel addCart)
        {
            Cart cart = new Cart()
            {
                CartID = addCart.Id,
                Count = addCart.Count,
                UserID = "90fadbf2-c167-4a60-8c2e-879f77134ddd",
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

        public IActionResult CartList() 
        {
            var value = cartManager.GetListByUserID().Where(x => x.UserID == "90fadbf2-c167-4a60-8c2e-879f77134ddd").ToList();
            return View(value);
        }
    }
}

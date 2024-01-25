using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Newtonsoft.Json.Linq;
using OnlineShopping.Models;

namespace OnlineShopping.Controllers
{
    public class OrderController : Controller
    {
        OrderManager orderManager = new OrderManager(new EfOrderDal());
        ProductManager productManager = new ProductManager(new EfProductDal());
        CardManager cardManager = new CardManager(new EfCardDal());
        CartManager cartManager = new CartManager(new EfCartDal());
        AdressManager adressManager = new AdressManager(new EfAdressDal());
        Context context = new Context();
        MailManager mailManager = new MailManager();
        private readonly UserManager<AppUser> _userManager;

        public OrderController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> AddOrder(int id)
        {
            var value = productManager.TGetByID(id);
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            List<SelectListItem> cardvalues = (from x in cardManager.TGetList().Where(x => x.UserID == user.Id)
                                               select new SelectListItem
                                               {
                                                   Text = x.CardName,
                                                   Value = x.CardID.ToString()
                                               }).ToList();
            ViewBag.cv = cardvalues;

            List<SelectListItem> adressValue = (from x in adressManager.TGetList().Where(x => x.UserID == user.Id)
                                                select new SelectListItem
                                                {
                                                    Text = x.AdressName,
                                                    Value = x.AdressID.ToString()
                                                }).ToList();
            ViewBag.av = adressValue;
            var orderViewModel = new AddOrderViewModel
            {
                ProductID = value.ProductID,
                Price = value.DiscountedPrice != null ? value.DiscountedPrice : value.Price

            };
            return View(orderViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddOrder(AddOrderViewModel addOrder)
        {

            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            string id = user.Id;
            Order order = new Order()
            {
                ProductID = addOrder.ProductID,
                CardID = addOrder.CardID,
                AdressID = addOrder.AdressID,
                UserID = user.Id,
                OrderStatusID = 1,
                OrderDateTime = DateTime.Parse(DateTime.Now.ToShortTimeString()),
                Count = addOrder.Count,
                OrderId = addOrder.OrderId,
                OrderCode = id.Substring(0, id.Length - 28) + addOrder.ProductID + DateTime.Now.Millisecond,
                Price = addOrder.Price * addOrder.Count
            };
            if (addOrder.IsApplied == true)
            {
                
                orderManager.TAdd(order);
                var product = context.Products.Where(x => x.ProductID == order.ProductID).FirstOrDefault();
                mailManager.SendMail(user.Email, "<!Doctype html>" +
                    "<html>" +
                    "<body>" +
                    "<h5>" + "Sifarişin kodu:" + order.OrderCode + "</h5>" +
                    "<table style=\"border:1px solid black;\">" +
                    "<tr>" +
                    "<th style=\"border:1px solid black;\">Məhsulun adı</th>" +
                    "<th style=\"border:1px solid black;\">Məhsulun kodu</th>" +
                    "<th style=\"border:1px solid black;\">Say</th>" +
                    "<th style=\"border:1px solid black;\">Qiyməti</th>" +
                    "</tr>" +
                    "<tr>" +
                    "<td style=\"border:1px solid black;\">" + product.ProductName + "</td>" +
                    "<td style=\"border:1px solid black;\">" + product.ProductCode + "</td>" +
                    "<td style=\"border:1px solid black;\">" + order.Count + "</td>" +
                    "<td style=\"border:1px solid black;\">" + order.Price + " ₼" + "</td>" +
                    "</tr>" +
                    "</table>" +
                    "<br />" +
                    "<br />" +
                    
                    "ÖDƏNİLİB!" +
                    "<br />" + 
                    "<br />" +
                    order.OrderDateTime?.ToString("dd.MM.yyyy HH.mm") +
                    "<br />" +
                    "<br />" +
                    "QARABAĞ AZƏRBAYCANDIR!" +
                    "</body>" +
                    "</html>"
                    , "Satışın qəbzi");
                var value = productManager.TGetByID(order.ProductID);
                value.Stock = value.Stock - order.Count;
                productManager.TUpdate(value);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(addOrder);
            }
        }

        [HttpGet]
        public async Task<IActionResult> AddOrderFromCart(int id)
        {
            var value = cartManager.TGetByID(id);
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            List<SelectListItem> cardvalues = (from x in cardManager.TGetList().Where(x => x.UserID == user.Id)
                                               select new SelectListItem
                                               {
                                                   Text = x.CardName,
                                                   Value = x.CardID.ToString()
                                               }).ToList();
            ViewBag.cv = cardvalues;

            List<SelectListItem> adressValue = (from x in adressManager.TGetList().Where(x => x.UserID == user.Id)
                                                select new SelectListItem
                                                {
                                                    Text = x.AdressName,
                                                    Value = x.AdressID.ToString()
                                                }).ToList();
            ViewBag.av = adressValue;
            var orderViewModel = new AddOrderViewModel
            {
                ProductID = value.ProductID,
                Count = value.Count
            };
            return View(orderViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddOrderFromCart(AddOrderViewModel addOrder)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            string id = user.Id;
            Order order = new Order()
            {
                ProductID = addOrder.ProductID,
                CardID = addOrder.CardID,
                AdressID = addOrder.AdressID,
                UserID = user.Id,
                OrderStatusID = 1,
                OrderDateTime = DateTime.Parse(DateTime.Now.ToShortTimeString()),
                Count = addOrder.Count,
                OrderId = addOrder.OrderId,
                OrderCode = id.Substring(0, id.Length - 28) + addOrder.ProductID + DateTime.Now.Millisecond,
                Price = addOrder.Price * addOrder.Count

            };
            if (addOrder.IsApplied == true)
            {
                orderManager.TAdd(order);
                var product = context.Products.Where(x => x.ProductID == order.ProductID).FirstOrDefault();
                mailManager.SendMail(user.Email, "<!Doctype html>" +
                    "<html>" +
                    "<body>" +
                    "<h5>" + "Sifarişin kodu:" + order.OrderCode + "</h5>" +
                    "<table style=\"border:1px solid black;\">" +
                    "<tr>" +
                    "<th style=\"border:1px solid black;\">Məhsulun adı</th>" +
                    "<th style=\"border:1px solid black;\">Məhsulun kodu</th>" +
                    "<th style=\"border:1px solid black;\">Say</th>" +
                    "<th style=\"border:1px solid black;\">Qiyməti</th>" +
                    "</tr>" +
                    "<tr>" +
                    "<td style=\"border:1px solid black;\">" + product.ProductName + "</td>" +
                    "<td style=\"border:1px solid black;\">" + product.ProductCode + "</td>" +
                    "<td style=\"border:1px solid black;\">" + order.Count + "</td>" +
                    "<td style=\"border:1px solid black;\">" + order.Price + " ₼" + "</td>" +
                    "</tr>" +
                    "</table>" +
                    "<br />" +
                    "<br />" +

                    "ÖDƏNİLİB!" +
                    "<br />" +
                    "<br />" +
                    order.OrderDateTime?.ToString("dd.MM.yyyy HH.mm") +
                    "<br />" +
                    "<br />" +
                    "QARABAĞ AZƏRBAYCANDIR!" +
                    "</body>" +
                    "</html>"
                    , "Satışın qəbzi");
                var value = productManager.TGetByID(order.ProductID);
                value.Stock = value.Stock - order.Count;
                productManager.TUpdate(value);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(addOrder);
            }
            
        }
    }
}

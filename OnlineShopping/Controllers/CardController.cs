using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShopping.Controllers
{
    public class CardController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        CardManager cardManager = new CardManager(new EfCardDal());
        public CardController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult AddCard()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCard(Card card)
        {
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            card.UserID = value.Id;
            cardManager.TAdd(card);
            return LocalRedirect("/Account/MyAccount");
        }

        public IActionResult DeleteCard(int id)
        {
            var value = cardManager.TGetByID(id);
            cardManager.TDelete(value);
            return LocalRedirect("/Account/MyAccount");
        }
    }
}

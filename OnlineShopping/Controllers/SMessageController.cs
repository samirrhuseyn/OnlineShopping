using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShopping.Models;

namespace OnlineShopping.Controllers
{
    
    public class SMessageController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        SMessageManager sMessageManager = new SMessageManager(new EfSMessageDal());
        public SMessageController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult>  SendMessage(AddMessageViewModel addMessage)
        {
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            StoreMessage storeMessage = new StoreMessage()
            {
                MessageTitle = addMessage.MessageTitle,
                MessageBody = addMessage.MessageBody,
                UserID = value.Id,
                StoreID = value.StoreID
            };
            sMessageManager.TAdd(storeMessage);
            return LocalRedirect("/Store/StoreDetails/" + storeMessage.StoreID);
        }
    }
}

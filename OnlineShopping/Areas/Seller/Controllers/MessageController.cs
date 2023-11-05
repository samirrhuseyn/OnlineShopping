using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShopping.Areas.Seller.Controllers
{
    [Area("Seller")]
    public class MessageController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        NotificationManager notificationManager = new NotificationManager(new EfNotificationDal());
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        Context context = new Context();
        public MessageController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        
        public IActionResult Inbox()
        {
            var username = User.Identity.Name;
            var user = context.Users.Where(x => x.UserName == username).Select(x => x.Id).FirstOrDefault();
            string id = user;
            ViewBag.CountMessage = context.Messages.Where(x => x.ReceiverID == id).Where(x => x.IsRead == false).Count();
            var values = messageManager.GetMessagesByAdmin(id);
            return View(values);
        }

        public IActionResult Sentbox()
        {
            var username = User.Identity.Name;
            var user = context.Users.Where(x => x.UserName == username).Select(x => x.Id).FirstOrDefault();
            string id = user;
            ViewBag.CountMessage = context.Messages.Where(x => x.ReceiverID == id).Where(x => x.IsRead == false).Count();
            var values = messageManager.GetSentMessageByAdmin(id);
            return View(values);
        }

        [HttpGet]
        public IActionResult Compose()
        {
            var username = User.Identity.Name;
            var user = context.Users.Where(x => x.UserName == username).Select(x => x.Id).FirstOrDefault();
            string id = user;
            ViewBag.CountMessage = context.Messages.Where(x => x.ReceiverID == id).Where(x => x.IsRead == false).Count();
            return View(Tuple.Create<Message, AppUser>(new Message(), new AppUser()));
        }

        [HttpPost]
        public async Task<IActionResult> Compose([Bind(Prefix = "Message")] Message message, [Bind(Prefix = "User")] AppUser users)
        {
            var sender = await _userManager.FindByNameAsync(User.Identity.Name);
            var receiver = await _userManager.FindByEmailAsync(users.Email);
            message.SenderID = sender.Id;
            message.ReceiverID = receiver.Id;
            message.MessageDate = Convert.ToDateTime(DateTime.Now.ToShortTimeString());
            message.IsDelete = false;
            message.IsRead = false;
            messageManager.TAdd(message);
            Notification notification = new Notification()
            {
                NotificationTitle = sender.Name + " " + sender.Surname + " sənə mesaj göndərdi!",
                NotificationContent = null,
                NotificationTypeTypeID = 1,
                NotificationDate = Convert.ToDateTime(DateTime.Now.ToShortTimeString()),
                UserID = receiver.Id
            };
            notificationManager.TAdd(notification);
            return RedirectToAction("SentBox");
        }

        public IActionResult MessageDetails(int id)
        {
            var username = User.Identity.Name;
            var user = context.Users.Where(x => x.UserName == username).Select(x => x.Id).FirstOrDefault();
            string userid = user;
            ViewBag.CountMessage = context.Messages.Where(x => x.ReceiverID == userid).Where(x => x.IsRead == false).Count();
            var value = messageManager.GetMessage(id);
            value.IsRead = true;
            messageManager.TUpdate(value);
            return View(value);
        }

        public IActionResult SentMessageDetails(int id)
        {
            var username = User.Identity.Name;
            var user = context.Users.Where(x => x.UserName == username).Select(x => x.Id).FirstOrDefault();
            string userid = user;
            ViewBag.CountMessage = context.Messages.Where(x => x.ReceiverID == userid).Where(x => x.IsRead == false).Count();
            var value = messageManager.GetSentMessage(id);
            return View(value);
        }

        public IActionResult DeleteSentMessage(int id)
        {
            var value = messageManager.TGetByID(id);
			value.IsDelete = true;
			messageManager.TUpdate(value);
			return RedirectToAction("SentBox");
        }

		public IActionResult UnDeleteSentMessage(int id)
		{
			var value = messageManager.TGetByID(id);
			value.IsDelete = false;
			messageManager.TUpdate(value);
			return RedirectToAction("SentDeletedMessages");
		}

		public IActionResult DeleteInMessage(int id)
        {
            var value = messageManager.TGetByID(id);
            value.IsDelete = true;
            messageManager.TUpdate(value);
            return RedirectToAction("Inbox");
        }
        
        public IActionResult UnDeleteInMessage(int id)
        {
            var value = messageManager.TGetByID(id);
            value.IsDelete = false;
            messageManager.TUpdate(value);
            return RedirectToAction("DeletedMessages");
        }

        public IActionResult ReadMessage(int id)
        {
            var value = messageManager.TGetByID(id);
            value.IsRead = true;
            messageManager.TUpdate(value);
            return RedirectToAction("Inbox");
        }

        public IActionResult UnReadMessage(int id)
        {
            var value = messageManager.TGetByID(id);
            value.IsRead = false;
            messageManager.TUpdate(value);
            return RedirectToAction("Inbox");
        }

		public IActionResult DeletedMessages()
		{
			var username = User.Identity.Name;
			var user = context.Users.Where(x => x.UserName == username).Select(x => x.Id).FirstOrDefault();
			string userid = user;
			ViewBag.CountMessage = context.Messages.Where(x => x.ReceiverID == userid).Where(x => x.IsRead == false).Count();
			var values = messageManager.DeletedInMessage(userid);
			return View(values);
		}

        public IActionResult SentDeletedMessages()
        {
            var username = User.Identity.Name;
            var user = context.Users.Where(x => x.UserName == username).Select(x => x.Id).FirstOrDefault();
            string id = user;
            ViewBag.CountMessage = context.Messages.Where(x => x.ReceiverID == id).Where(x => x.IsRead == false).Count();
            var values = messageManager.DeletedSentMessage(id);
            return View(values);
        }
    }
}

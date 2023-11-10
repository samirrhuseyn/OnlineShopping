using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShopping.ViewComponents.SellerLayout
{
    public class NotesLayout : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        NoteManager noteManager = new NoteManager(new EfNoteDal());

        public NotesLayout(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            string id = value.Id;
            var values = noteManager.GetNoteListWithUser().Where(x => x.UserID == id);
            return View(values);
        }
    }
}

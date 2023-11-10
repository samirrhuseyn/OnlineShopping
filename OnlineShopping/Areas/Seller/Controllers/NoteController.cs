using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShopping.Areas.Seller.Models;

namespace OnlineShopping.Areas.Seller.Controllers
{
    [Area("Seller")]
    public class NoteController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        NoteManager noteManager = new NoteManager(new EfNoteDal());

        public NoteController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> AddNote(AddNoteViewModel noteModel)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            Note note = new Note()
            {
                NoteTitle = noteModel.NoteTitle,
                NoteContent = noteModel.NoteContent,
                NoteDateTime = DateTime.Parse(DateTime.Now.ToShortTimeString()),
                UserID = values.Id,
                CollapseText = "collapse"
            };
            noteManager.TAdd(note);
            return RedirectToAction("Index", "Product");
        }

        public IActionResult DeleteNote(int id)
        {
            var value = noteManager.TGetByID(id);
            noteManager.TDelete(value);
            return RedirectToAction("Index", "Product");
        }
    }
}

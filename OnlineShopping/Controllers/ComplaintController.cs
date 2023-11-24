using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShopping.Models;

namespace OnlineShopping.Controllers
{
    public class ComplaintController : Controller
    {
        ComplaintManager complaintManager = new ComplaintManager(new EfComplaintDal());
        ProductManager productManager = new ProductManager(new EfProductDal());
        private readonly UserManager<AppUser> userManager;

        public ComplaintController(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult AddComplaint()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddComplaint(AddComplaintViewModel addComplaint)
        {
            var value = productManager.GetByProductCode(addComplaint.ProductCode);
            var values = await userManager.FindByNameAsync(User.Identity.Name);
            Complaint complaint = new Complaint()
            {
                Reason = addComplaint.Reason,
                Image1 = UploadFile(addComplaint.Image1),
                Image2 = UploadFile(addComplaint.Image2),
                SalesCode = addComplaint.SalesCode,
                ProductID = value.ProductID,
                IsLooked = false,
                DateTime = Convert.ToDateTime(DateTime.Now.ToShortTimeString()),
                UserID = values.Id
            };
            complaintManager.TAdd(complaint);
            return LocalRedirect("/Complaint/Index/");
        }

        public IActionResult DeleteComplaint(int id)
        {
            var value = complaintManager.TGetByID(id);
            complaintManager.TDelete(value);
            return LocalRedirect("/Complaint/Index/");
        }

        public async Task<IActionResult> Index()
        {
            var values = await userManager.FindByNameAsync(User.Identity.Name);
            var value = complaintManager.GetComplaints().Where(x => x.UserID == values.Id).ToList();
            return View(value);
        }

        private string UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return null;

            var path = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot/ImagesFiles/ComplaintImageFiles/",
                        file.FileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return "/ImagesFiles/ComplaintImageFiles/" + file.FileName;
        }
    }
}

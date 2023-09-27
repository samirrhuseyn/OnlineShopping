using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShopping.ViewComponents.AdminStoreDetails
{
    public class CampaignListInDetails : ViewComponent
    {
        CampaignManager campaignManager = new CampaignManager(new EfCampaignDal());
        public IViewComponentResult Invoke()
        {
            int id = ViewBag.ID;
            var value = campaignManager.GetCampaignListByStoreID(id);
            return View(value);
        }
    }
}

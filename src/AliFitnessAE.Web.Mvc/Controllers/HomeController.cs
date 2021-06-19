using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using AliFitnessAE.Controllers;

namespace AliFitnessAE.Web.Controllers
{ 
    public class HomeController : AliFitnessAEControllerBase
    {
        public ActionResult Index() 
        {
            return RedirectToAction("Index", "Home", new { area = "Admin" }); 
        }
    }
}

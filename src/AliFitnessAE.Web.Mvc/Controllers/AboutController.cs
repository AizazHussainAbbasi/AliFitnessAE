using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using AliFitnessAE.Controllers;

namespace AliFitnessAE.Web.Controllers
{ 
    public class AboutController : AliFitnessAEControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}

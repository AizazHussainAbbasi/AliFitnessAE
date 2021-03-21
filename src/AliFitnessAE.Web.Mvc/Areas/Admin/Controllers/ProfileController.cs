using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Acme.SimpleTaskApp.Common;
using AliFitnessAE.AppService.Document;
using AliFitnessAE.Authorization.Users;
using AliFitnessAE.Common.Constants;
using AliFitnessAE.Controllers;
using AliFitnessAE.Crypto;
using AliFitnessAE.Sessions;
using AliFitnessAE.Web.Areas.Admin.Models.Common;
using AliFitnessAE.Web.Areas.Admin.Models.Common.Modals;
using AliFitnessAE.Web.Areas.Admin.Models.Home;
using Microsoft.AspNetCore.Mvc;

namespace AliFitnessAE.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProfileController : AliFitnessAEControllerBase
    {
        private readonly ISessionAppService _sessionAppService;
        private readonly ILookupAppService _lookupAppService;
        private readonly IDocumentAppService _documentAppService;
        private readonly UserManager _userManager;

        public ProfileController(
              ISessionAppService sessionAppService,
              ILookupAppService lookupAppService,
              IDocumentAppService documentAppService,
              UserManager userManager)
        {
            _sessionAppService = sessionAppService;
            _lookupAppService = lookupAppService;
            _documentAppService = documentAppService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var scale = new Scale(_lookupAppService);
            var photoTrackingLKDId = (_lookupAppService.GetAllLookDetail(null, LookUpDetailConst.PhotoTracking)).Result.Items.FirstOrDefault().Id;
            var businessDocumentList = (_documentAppService.GetAllBusinessDocuments(null, photoTrackingLKDId, null)).Result.Items.ToList();
            var heightInCm = _lookupAppService.GetAllLookDetail(null, LookUpDetailConst.Cm).Result.Items.First().Id;
            var model = new ProfileVModel
            {
                LoginInformations = _sessionAppService.GetCurrentLoginInformations().Result,
                UserTrackingFilter = new UserTrackingFilter() { MeasurementScale = scale, MeasurementScaleLKDId = heightInCm },
                PhotoTrackingBusinessDocumentList = businessDocumentList
            };
            //Set UserId
            string userEnycId = HttpContext.Request.Query["id"].ToString();
            if (!string.IsNullOrEmpty(userEnycId)) 
                model.UserTrackingFilter.UserIdEnyc = userEnycId; 
            else 
                model.UserTrackingFilter.UserIdEnyc = CryptoEngine.EncryptString(AbpSession.UserId.Value.ToString()); 
            return View(model);
        }
    }
}
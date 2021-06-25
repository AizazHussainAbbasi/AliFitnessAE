using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using AliFitnessAE.Controllers;
using AliFitnessAE.Web.Areas.Admin.Views.Shared.Components.DocumentUploader;
using AliFitnessAE.Web.Areas.Admin.Models.Common.Modals;
using Acme.SimpleTaskApp.Common;
using AliFitnessAE.Web.Areas.Admin.Models.Home;
using AliFitnessAE.Web.Admin.Views.Shared.Components.UserTrackingChart;
using AliFitnessAE.Authorization.Users;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using Abp.Application.Services.Dto;
using AliFitnessAE.Dto;
using AliFitnessAE.Web.Areas.Admin.Models.Common;
using AliFitnessAE.Common.Enum;
using AliFitnessAE.Common.Constants;
using AliFitnessAE.AppService;
using AliFitnessAE.Users;
using AliFitnessAE.Email;
using Abp.Net.Mail;
using Abp.Configuration;

namespace AliFitnessAE.Web.Admin.Controllers
{
    [AbpMvcAuthorize]
    [Area("Admin")]
    public class HomeController : AliFitnessAEControllerBase
    {
        private readonly ILookupAppService _lookupAppService;
        private readonly IUserAppService _userAppService;
        private readonly IUserTrackingAppService _userTrackingAppService;
        private readonly IPhotoTrackingAppService _photoTrackingAppService;
        private readonly UserManager _userManager;
        private readonly ISettingManager _settingManager;
        //private readonly IEmailService _emailService;#

        public HomeController(
             ILookupAppService lookupAppService,
             IUserAppService userAppService,
             IUserTrackingAppService userTrackingAppService,
             IPhotoTrackingAppService photoTrackingAppService,
              UserManager userManager,
              ISettingManager settingManager
            //  IEmailService emailService
            )
        {
            _lookupAppService = lookupAppService;
            _userAppService = userAppService;
            _userTrackingAppService = userTrackingAppService;
            _photoTrackingAppService = photoTrackingAppService;
            _userManager = userManager;
            _settingManager = settingManager;
            //_emailService = emailService;
        }
        public ActionResult Index()
        {
            //EmailService _emailService = new EmailService(_settingManager);
            //_emailService.Send("aizaz.abbasi1993@gmail.com", "dotnetexperts777@gmail.com", "ICES BCIT", "<h1>Test Email</h1>");
            var scale = new Scale(_lookupAppService);
            var model = new HomeIndexCommonVModel
            {
                UserTrackingFilter = new UserTrackingFilter() { MeasurementScale = scale },
            };
            if (_userManager.IsAdminUser(AbpSession.UserId.Value))
            {
                model.UserTrackingFilter.UserList = _lookupAppService.GetUserComboboxItems().Result.Items.Select(p => p.ToSelectListItem()).ToList();
                model.UserTrackingFilter.UserList.Insert(0, new SelectListItem { Value = string.Empty, Text = L("All"), Selected = true });

                //User Counts
                model.ActiveClientCount = _userAppService.GetUserCount(UserTypeConst.Client, true);
                model.UnActiveClientCount = _userAppService.GetUserCount(UserTypeConst.Client, false);
                model.ApprovedMeasurementCount = _userTrackingAppService.GetUserTrackingCount(true);
                model.UnApprovedMeasurementCount = _userTrackingAppService.GetUserTrackingCount(false);
                model.ApprovedPhotosTrackingCount= _photoTrackingAppService.GetPhotoTrackingCount(true);
                model.UnApprovedPhotosTrackingCount = _photoTrackingAppService.GetPhotoTrackingCount(false);
            }
            return View(model);
        }
        [HttpPost]
        public PartialViewResult LoadUserTrackingChartPartialView(UserTrackingFilter searchModel)
        {
            searchModel.MeasurementScale = new Scale(_lookupAppService);
            return PartialView("_UserTrackingDashboardSection", searchModel);
        }
        [HttpPost]
        public IActionResult LoadViewComponent(ViewComponentVModel model)
        {
            //if (!model.SearchModel.UserId.HasValue)
            //    model.SearchModel.UserId = (int?)AbpSession.UserId.Value;
            return ViewComponent(model.ViewComponentName, model);
        }
        [HttpPost]
        public IActionResult LoadViewComponentUserTracking(UserTrackingFilter model)
        { 
            if (model.MeasurementScale == null)
                model.MeasurementScale = new Scale(_lookupAppService);
            string measurementScaleConst = string.Empty;
            if (model.MeasurementScaleLKDId == 0)
            {
                if (model.BodyPart == EnumUserTrackingBodyPart.Height)
                    measurementScaleConst = LookUpDetailConst.Cm;
                else if (model.BodyPart == EnumUserTrackingBodyPart.Weight)
                    measurementScaleConst = LookUpDetailConst.Kg;
                else
                    measurementScaleConst = LookUpDetailConst.Cm;
                model.MeasurementScaleLKDId = _lookupAppService.GetAllLookDetail(null, measurementScaleConst).Result.Items.First().Id;
            }
            return ViewComponent("UserTrackingDetailTab", model);
        }

        [HttpPost]
        public IActionResult LoadChartViewComponent(UserTrackingChartViewModel model)
        {
            return ViewComponent("UserTrackingChart", model);
        }
    }
}

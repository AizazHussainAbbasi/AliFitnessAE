using Acme.SimpleTaskApp.Common;
using AliFitnessAE.AppService;
using AliFitnessAE.AppService.Document;
using AliFitnessAE.Authorization.Users;
using AliFitnessAE.Common.Constants;
using AliFitnessAE.Common.Enum;
using AliFitnessAE.Crypto;
using AliFitnessAE.Web.Admin.Views.UserTracking.Components.PhotoTracking;
using AliFitnessAE.Web.Areas.Admin.Models.Common.Modals;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AliFitnessAE.Web.Admin.Views.photoTracking.Components.PictureTracking
{
    public class PhotoTrackingViewComponent : AliFitnessAEViewComponent
    {
        private readonly IPhotoTrackingAppService _photoTrackingAppService;
        private readonly ILookupAppService _lookupAppService;
        private readonly IDocumentAppService _documentAppService;
        private readonly UserManager _userManager;
        public PhotoTrackingViewComponent(IPhotoTrackingAppService photoTrackingAppService,
             ILookupAppService lookupAppService,
             IDocumentAppService documentAppService,
             UserManager userManager)
        {
            _photoTrackingAppService = photoTrackingAppService;
            _lookupAppService = lookupAppService;
            _documentAppService = documentAppService;
            _userManager = userManager;
        }
        public async Task<IViewComponentResult> InvokeAsync(ViewComponentVModel model)
        {
            if (!model.SearchModel.UserId.HasValue && !string.IsNullOrWhiteSpace(model.SearchModel.UserIdEnyc))
                model.SearchModel.UserId = (!string.IsNullOrWhiteSpace(model.SearchModel.UserIdEnyc)) ? (int?)Convert.ToInt32(CryptoEngine.DecryptString(model.SearchModel.UserIdEnyc)) : null;

            var photoList = _photoTrackingAppService.GetAllPhotoTrackingPagedResult(model.SearchModel, model.BusinessEntityId);
            var result = new PhotoTrackingViewModel()
            {
                DocumentList = photoList,
                DocumentType = (model.SearchModel != null) ? model.SearchModel.DocumentType : EnumDocumentType.FrontPose
            };
            ViewBag.IsAdminLoggedIn = _userManager.IsAdminUser(AbpSession.UserId.Value);
            string view = string.IsNullOrEmpty(model.ViewName) ? "_Default" : model.ViewName;
            return await Task.FromResult((IViewComponentResult)View(view, result));
        }
    }
}
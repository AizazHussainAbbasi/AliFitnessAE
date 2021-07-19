using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using Acme.SimpleTaskApp.Common;
using AliFitnessAE.AppService.Document;
using AliFitnessAE.Authorization.Users;
using AliFitnessAE.Common.Constants;
using AliFitnessAE.Controllers;
using AliFitnessAE.Crypto;
using AliFitnessAE.Document.Dto;
using AliFitnessAE.Sessions;
using AliFitnessAE.Users;
using AliFitnessAE.Users.Dto;
using AliFitnessAE.Web.Areas.Admin.Models.Common;
using AliFitnessAE.Web.Areas.Admin.Models.Common.Modals;
using AliFitnessAE.Web.Areas.Admin.Models.Home;
using AliFitnessAE.Web.Areas.Admin.Views.Shared.Components.DocumentUploader;
using AliFitnessAE.Web.Models.Admin.Users;
using Microsoft.AspNetCore.Mvc;

namespace AliFitnessAE.Web.Areas.Admin.Controllers
{
    [AbpMvcAuthorize]
    [Area("Admin")]
    public class ProfileController : AliFitnessAEControllerBase
    {
        private readonly ISessionAppService _sessionAppService;
        private readonly ILookupAppService _lookupAppService;
        private readonly IDocumentAppService _documentAppService;
        private readonly UserManager _userManager;
        private readonly IUserAppService _userAppService;

        public ProfileController(
              ISessionAppService sessionAppService,
              ILookupAppService lookupAppService,
              IDocumentAppService documentAppService,
              UserManager userManager,
              IUserAppService userAppService)
        {
            _sessionAppService = sessionAppService;
            _lookupAppService = lookupAppService;
            _documentAppService = documentAppService;
            _userManager = userManager;
            _userAppService = userAppService;
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

            model.PersonalDetail = LoadPersonalDetail(model.UserTrackingFilter.UserIdEnyc).Result;
            return View(model);
        }
        public async Task<EditPersonalDetailViewModel> LoadPersonalDetail(string userIdEnyc)
        { 
            var userId = Convert.ToInt64(CryptoEngine.DecryptString(userIdEnyc));
            var user = await _userAppService.GetAsync(new EntityDto<long>(userId));

            var genderMasterId = (await _lookupAppService.GetAllLookUpMaster(null, "Gender")).Items.FirstOrDefault().Id;
            var genderSelectListItems = (await _lookupAppService.GetLookDetailComboboxItems(genderMasterId)).Items
                      .Select(p => p.ToSelectListItem())
                      .ToList();
            genderSelectListItems.Find(x => x.Value == user.Gender.ToString()).Selected = true;

            var personalDetailLKDId = (await _lookupAppService.GetAllLookDetail(null, LookUpDetailConst.PersonalDetail)).Items.FirstOrDefault().Id;
            var businessDocumentList = (await _documentAppService.GetAllBusinessDocuments(null, personalDetailLKDId, null)).Items.ToList();

            foreach (var businessDoc in businessDocumentList)
            {
                if (businessDoc.BusinessEntityLKDId == personalDetailLKDId)
                {
                    var photo = new List<BusinessDocumentAttachmentDto>();
                    photo.Add(_documentAppService.GetAllBusinessDocumentAttachments(null, businessDoc.Id, (int)userId).Result.Items.FirstOrDefault());
                    businessDoc.BusinessDocumentAttachmentDto = photo;
                }
            }
            var documentModel = new DocumentUploaderViewModel()
            {
                BusinessEntityId = userId,
                DocumentList = businessDocumentList 
            };

            return new EditPersonalDetailViewModel
            {
                User = user,
                Gender = genderSelectListItems,
                ProfilePhoto = documentModel
            };
        }
    }
}
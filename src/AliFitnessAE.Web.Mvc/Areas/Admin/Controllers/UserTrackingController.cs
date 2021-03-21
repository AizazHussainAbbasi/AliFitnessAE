using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using Acme.SimpleTaskApp.Common;
using AliFitnessAE.AppService;
using AliFitnessAE.AppService.Document;
using AliFitnessAE.Authorization;
using AliFitnessAE.Authorization.Users;
using AliFitnessAE.Common.Constants;
using AliFitnessAE.Common.Enum;
using AliFitnessAE.Controllers;
using AliFitnessAE.Dto;
using AliFitnessAE.Sessions;
using AliFitnessAE.Sessions.Dto;
using AliFitnessAE.Web.Areas.Admin.Models.Common.Modals;
using AliFitnessAE.Web.Models.Admin.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AliFitnessAE.Web.Admin.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_UserTracking)]
    [Area("Admin")]
    public class UserTrackingController : AliFitnessAEControllerBase
    {
        private readonly IUserTrackingAppService _userTrackingAppService;
        private readonly IPhotoTrackingAppService _photoTrackingAppService;
        private readonly ILookupAppService _lookupAppService;
        private readonly IDocumentAppService _documentAppService;
        private readonly UserManager _userManager;
        private readonly ISessionAppService _sessionAppService;
        public UserTrackingController(IUserTrackingAppService userTrackingAppService,
            IPhotoTrackingAppService photoTrackingAppService,
             ILookupAppService lookupAppService,
            IDocumentAppService documentAppService,
                        UserManager userManager,
                         ISessionAppService sessionAppService)
        {
            _userTrackingAppService = userTrackingAppService;
            _photoTrackingAppService = photoTrackingAppService;
            _lookupAppService = lookupAppService;
            _documentAppService = documentAppService;
            _userManager = userManager;
            _sessionAppService = sessionAppService;
        }

        public async Task<ActionResult> Index()
        {
            try
            {
                //Document module
                //var userTrackingLKDId = (await _lookupAppService.GetAllLookDetail(null, LookUpDetailConst.UserTracking)).Items.FirstOrDefault().Id;
                //var businessDocumentList = (await _documentAppService.GetAllBusinessDocuments(null, userTrackingLKDId, null)).Items;
                ////end

                var measurementScaleSelectListItems = _lookupAppService.GetMeasurementScaleComboboxItems().Result.Items.Select(p => p.ToSelectListItem()).ToList();
                measurementScaleSelectListItems.Find(x => x.Value == measurementScaleSelectListItems.First().Value).Selected = true;

                var scale = new Scale(_lookupAppService);

                var model = new UserTrackingListViewModel
                {
                    MeasurementScale = scale,
                    //BusinessDocumentList = businessDocumentList
                };
                if (_userManager.IsAdminUser(AbpSession.UserId.Value))
                {
                    model.UserList = _lookupAppService.GetUserComboboxItems().Result.Items.Select(p => p.ToSelectListItem()).ToList();
                    model.UserList.Insert(0, new SelectListItem { Value = string.Empty, Text = L("All"), Selected = true });
                }
                ViewBag.IsAdminLoggedIn = _userManager.IsAdminUser(AbpSession.UserId.Value);
                return View(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<ActionResult> EditModal(int UserTrackingId)
        {
            var output = await _userTrackingAppService.GetUserTrackingForEdit(new EntityDto(UserTrackingId));
            var status = _lookupAppService.GetAllStatus((int)output.StatusId).Result.Items.First();
            var scale = new Scale(_lookupAppService);
            try
            {
                var model = new EditUserTrackingModalViewModel
                {
                    MeasurementScale = scale,
                    UserTracking = output,
                    IsReadOnly = (status.StatusConst == StatusConst.Approved) ? true : false
                };

                if (_userManager.IsAdminUser(AbpSession.UserId.Value))
                {
                    model.UserList = _lookupAppService.GetUserComboboxItems().Result.Items.Select(p => p.ToSelectListItem()).ToList();
                    model.UserList.Find(x => x.Value == output.UserId.ToString()).Selected = true;
                    model.IsReadOnly = false;
                }
                return PartialView("_EditModal", model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //public async Task<UserTrackingListViewModel> GetAllUserTracking(PagedUserTrackingResultRequestDto input)
        //{
        //   var userTrackingDtoResultList = _userTrackingAppService.GetAllUserTracking(input);

        //    var measurementScaleSelectListItems = _lookupAppService.GetMeasurementScaleComboboxItems().Result.Items.Select(p => p.ToSelectListItem())
        //                             .ToList();
        //    var resultVM = new UserTrackingListViewModel()
        //    {
        //        UserTrackingDtoResultList = userTrackingDtoResultList,
        //        MeasurementScale = measurementScaleSelectListItems
        //    };
        //    return resultVM;
        //} 

        //[AbpMvcAuthorize(PermissionNames.Pages_PhotoTracking)]
        public ActionResult PhotoTracking()
        {
            var model = new PhotoTrackingIndexViewModel()
            {
                LoginInformations = _sessionAppService.GetCurrentLoginInformations().Result,
            };
            //Document module
            //var userTrackingLKDId = (await _lookupAppService.GetAllLookDetail(null, LookUpDetailConst.UserTracking)).Items.FirstOrDefault().Id;
            //var businessDocumentList = (await _documentAppService.GetAllBusinessDocuments(null, userTrackingLKDId, null)).Items;
            ////end

            //var measurementScaleSelectListItems = _lookupAppService.GetMeasurementScaleComboboxItems().Result.Items.Select(p => p.ToSelectListItem()).ToList();
            //measurementScaleSelectListItems.Find(x => x.Value == measurementScaleSelectListItems.First().Value).Selected = true;

            //var scale = new Scale(_lookupAppService); 
            //var model = new UserTrackingListViewModel
            //{
            //    //MeasurementScale = scale,
            //    //BusinessDocumentList = businessDocumentList
            //    BusinessDocumentList = businessDocumentList
            //};
            if (_userManager.IsAdminUser(AbpSession.UserId.Value))
            {
                model.UserList = _lookupAppService.GetUserComboboxItems().Result.Items.Select(p => p.ToSelectListItem()).ToList();
                model.UserList.Insert(0, new SelectListItem { Value = string.Empty, Text = L("All"), Selected = true });
            }
            return View(model);
        }
        public ActionResult CreatePhotoTrackingModal()
        {
            return PartialView("_CreatePhotoTrackingModal", new PhotoTrackingIndexViewModel());
        }
        public JsonResult DeletePhotoTracking(int id)
        {
            _photoTrackingAppService.Delete(id);
            return new JsonResult(true);
        } 
    }
}

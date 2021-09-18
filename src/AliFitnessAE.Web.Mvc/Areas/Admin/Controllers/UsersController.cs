using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using AliFitnessAE.Authorization;
using AliFitnessAE.Controllers;
using AliFitnessAE.Users;
using AliFitnessAE.Web.Models.Admin.Users;
using AliFitnessAE.AppServiceUserType;
using AliFitnessAE.AppUserTypeDto;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Acme.SimpleTaskApp.Common;
using Microsoft.AspNetCore.Authorization;
using AliFitnessAE.Users.Dto;
using AliFitnessAE.Authorization.Users;
using AliFitnessAE.Crypto;
using Microsoft.AspNetCore.Http.Extensions;
using System.Web;

namespace AliFitnessAE.Web.Admin.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_UserType)]
    [Area("Admin")]
    public class UsersController : AliFitnessAEControllerBase
    {
        private readonly IUserAppService _userAppService;
        private readonly ILookupAppService _lookupAppService;
        private readonly IUserTypeAppService _userTypeAppService;
        private readonly UserManager _userManager;

        public UsersController(IUserAppService userAppService, ILookupAppService lookupAppService, IUserTypeAppService userTypeAppService,
               UserManager userManager)
        {
            _userAppService = userAppService;
            _lookupAppService = lookupAppService;
            _userTypeAppService = userTypeAppService;
            _userManager = userManager;
        }

        public async Task<ActionResult> Index()
        {
            var roles = (await _userAppService.GetRoles()).Items;
            var userTypeSelectListItems = (await _lookupAppService.GetUserTypeComboboxItems()).Items
             .Select(p => p.ToSelectListItem())
             .ToList();
            
            var genderMasterId = (await _lookupAppService.GetAllLookUpMaster(null, "Gender")).Items.FirstOrDefault().Id;
            var genderSelectListItems = (await _lookupAppService.GetLookDetailComboboxItems(genderMasterId)).Items
                      .Select(p => p.ToSelectListItem())
                      .ToList();

            userTypeSelectListItems.Insert(0, new SelectListItem { Value = string.Empty, Text = L("Select"), Selected = true });
            genderSelectListItems.Insert(0, new SelectListItem { Value = string.Empty, Text = L("Select"), Selected = true });

            var model = new UserListViewModel
            {
                Roles = roles,
                UserType = userTypeSelectListItems,
                Gender = genderSelectListItems
            };
            ViewBag.IsAdminLoggedIn = _userManager.IsAdminUser(AbpSession.UserId.Value);
            return View(model);
        }

        public async Task<ActionResult> EditModal(long userId)
        {
            var user = await _userAppService.GetAsync(new EntityDto<long>(userId));
            var roles = (await _userAppService.GetRoles()).Items;
            var userTypeSelectListItems = (await _lookupAppService.GetUserTypeComboboxItems()).Items
             .Select(p => p.ToSelectListItem())
             .ToList();
            userTypeSelectListItems.Find(x => x.Value == user.UserTypeId.ToString()).Selected = true;

            var genderMasterId = (await _lookupAppService.GetAllLookUpMaster(null, "Gender")).Items.FirstOrDefault().Id;
            var genderSelectListItems = (await _lookupAppService.GetLookDetailComboboxItems(genderMasterId)).Items
                      .Select(p => p.ToSelectListItem())
                      .ToList();
            genderSelectListItems.Find(x => x.Value == user.Gender.ToString()).Selected = true;

            var model = new EditUserModalViewModel
            {
                User = user,
                Roles = roles,
                UserType = userTypeSelectListItems,
                Gender = genderSelectListItems
            };
            return PartialView("_EditModal", model);
        }
        public JsonResult GotoUserProfile(long userId)
        {
            string id = null;
            if (_userManager.IsAdminUser(AbpSession.UserId.Value))
            {
                id = userId.ToString();
            }
            else
                id = AbpSession.UserId.Value.ToString();
            string url = string.Format("/Admin/Profile/Index?id={0}",
                 HttpUtility.UrlEncode(CryptoEngine.EncryptString(id))); 
            return Json(new { success = true, targetUrl = url });
        }
    }
}

using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using AliFitnessAE.AppServiceUserType;
using AliFitnessAE.Authorization;
using AliFitnessAE.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AliFitnessAE.Web.Admin.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_UserType)]
    [Area("Admin")]
    public class UserTypeController : AliFitnessAEControllerBase
    {
        private readonly IUserTypeAppService _UserTypeAppService;

        public UserTypeController(IUserTypeAppService UserTypeAppService)
        {
            _UserTypeAppService = UserTypeAppService;
        }

        public ActionResult Index() => View();

        public async Task<ActionResult> EditModal(int UserTypeId)
        {
            var output = await _UserTypeAppService.GetUserTypeForEdit(new EntityDto(UserTypeId));
            return PartialView("_EditModal", output); 
        }

    }
}

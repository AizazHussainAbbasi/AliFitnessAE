using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using AliFitnessAE.AppUserTypeDto;
using AliFitnessAE.Document.Dto;
using AliFitnessAE.Dto;
using AliFitnessAE.Roles.Dto;
using AliFitnessAE.Sessions.Dto;
using AliFitnessAE.Web.Areas.Admin.Models.Common.Modals;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AliFitnessAE.Web.Models.Admin.Users
{
    public class PhotoTrackingIndexViewModel
    {
        public List<SelectListItem> UserList { get; set; }
        public GetCurrentLoginInformationsOutput LoginInformations { get; set; }
    }
}

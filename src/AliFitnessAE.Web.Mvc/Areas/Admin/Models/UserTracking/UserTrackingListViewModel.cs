using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using AliFitnessAE.AppUserTypeDto;
using AliFitnessAE.Document.Dto;
using AliFitnessAE.Dto;
using AliFitnessAE.Roles.Dto;
using AliFitnessAE.Web.Areas.Admin.Models.Common.Modals;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AliFitnessAE.Web.Models.Admin.Users
{
    public class UserTrackingListViewModel
    {
        public List<SelectListItem> UserList { get; set; }
        public Scale MeasurementScale { get; set; }
        public IReadOnlyList<BusinessDocumentDto> BusinessDocumentList { get; set; }
     }
}

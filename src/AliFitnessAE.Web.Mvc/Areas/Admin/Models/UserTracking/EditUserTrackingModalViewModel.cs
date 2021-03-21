using AliFitnessAE.AppUserTypeDto;
using AliFitnessAE.Dto;
using AliFitnessAE.Roles.Dto;
using AliFitnessAE.Users.Dto;
using AliFitnessAE.Web.Areas.Admin.Models.Common.Modals;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace AliFitnessAE.Web.Models.Admin.Users
{
    public class EditUserTrackingModalViewModel
    {
        public UserTrackingEditDto UserTracking { get; set; }
        public Scale MeasurementScale { get; set; }
        public List<SelectListItem> UserList { get; set; }
        public bool IsReadOnly { get; set; } = false;
    }
}

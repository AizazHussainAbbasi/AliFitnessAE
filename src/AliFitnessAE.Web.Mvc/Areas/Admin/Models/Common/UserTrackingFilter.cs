using AliFitnessAE.Dto;
using AliFitnessAE.Web.Areas.Admin.Models.Common.Modals;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AliFitnessAE.Web.Areas.Admin.Models.Common
{
    public class UserTrackingFilter : PagedResultRequestExtDto
    {
        public string ChartType { get; set; } = "bar";
        public Scale MeasurementScale { get; set; }
        public List<SelectListItem> UserList { get; set; }
    }
}

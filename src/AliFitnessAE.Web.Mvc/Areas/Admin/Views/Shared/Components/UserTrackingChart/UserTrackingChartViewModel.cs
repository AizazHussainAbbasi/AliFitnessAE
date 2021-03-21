using AliFitnessAE.Common.Enum;
using AliFitnessAE.Dto;
using AliFitnessAE.Sessions.Dto;
using AliFitnessAE.Web.Areas.Admin.Models.Common.Modals;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace AliFitnessAE.Web.Admin.Views.Shared.Components.UserTrackingChart
{ 
    public class UserTrackingChartViewModel : PagedResultRequestExtDto
    {
        public string ChartType { get; set; } 
        public string HtmlControlId { get; set; }
        public int MeasurementScaleLKDId { get; set; }
        public EnumUserTrackingBodyPart UserTrackingBodyPart { get; set; }
    }  
}

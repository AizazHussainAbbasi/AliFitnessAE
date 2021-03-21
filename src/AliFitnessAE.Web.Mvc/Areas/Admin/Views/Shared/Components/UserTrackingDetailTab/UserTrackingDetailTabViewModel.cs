using Abp.Application.Services.Dto;
using AliFitnessAE.Authorization.Users;
using AliFitnessAE.Common.Enum;
using AliFitnessAE.Dto;
using AliFitnessAE.Sessions.Dto;
using AliFitnessAE.StatusCore;
using AliFitnessAE.Web.Areas.Admin.Models.Common.Modals;
using AliFitnessAE.Web.Areas.Admin.Views.Shared.Components.UserTrackingChart;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace AliFitnessAE.Web.Admin.Views.Shared.Components.UserTrackingChart
{
    public class UserTrackingDetailTabViewModel : PagedResultRequestExtDto
    {
        public User User { get; set; }
        public Scale MeasurementScale { get; set; }
        public List<UserTrackingDetailVModel> UserTrackingDetail { get; set; } 
        public ChartJsVModel Chart { get; set; }
    }
    public class UserTrackingDetailVModel
    {
        public long StatusId { get; set; }
        public Status Status { get; set; }
        public DateTime CreationTime { get; set; }
        public Tuple<decimal, string> BodyPartValueAndScale { get; set; } 
        public string BodyPartProgress { get; set; }
    }
}

using Abp.Application.Services.Dto;
using AliFitnessAE.Authorization.Users;
using AliFitnessAE.Common.Enum;
using AliFitnessAE.Document.Dto;
using AliFitnessAE.Dto;
using AliFitnessAE.Sessions.Dto;
using AliFitnessAE.StatusCore;
using AliFitnessAE.Web.Areas.Admin.Models.Common.Modals;
using AliFitnessAE.Web.Areas.Admin.Views.Shared.Components.UserTrackingChart;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
 
namespace AliFitnessAE.Web.Admin.Views.UserTracking.Components.PhotoTracking
{
    public class PhotoTrackingViewModel : PagedResultRequestExtDto
    {
        public PagedResultDto<PhotoTrackingListDto> DocumentList { get; set; }  
    }  
}

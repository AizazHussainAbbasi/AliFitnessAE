using AliFitnessAE.Document.Dto;
using AliFitnessAE.Sessions.Dto;
using AliFitnessAE.Web.Areas.Admin.Models.Common;
using System.Collections.Generic;

namespace AliFitnessAE.Web.Areas.Admin.Models.Home
{
    public class ProfileVModel
    {
        public GetCurrentLoginInformationsOutput LoginInformations { get; set; } 
        public UserTrackingFilter UserTrackingFilter { get; set; }
        public List<BusinessDocumentDto> PhotoTrackingBusinessDocumentList { get; set; } 
    }
}

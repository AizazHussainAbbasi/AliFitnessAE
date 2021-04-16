using AliFitnessAE.Web.Areas.Admin.Models.Common;

namespace AliFitnessAE.Web.Areas.Admin.Models.Home
{
    public class HomeIndexCommonVModel
    {
        public int? ActiveClientCount { get; set; }
        public int? UnActiveClientCount { get; set; }
        public int? ApprovedMeasurementCount { get; set; }
        public int? UnApprovedMeasurementCount { get; set; }
        public int? ApprovedPhotosTrackingCount { get; set; }
        public int? UnApprovedPhotosTrackingCount { get; set; }
        public UserTrackingFilter UserTrackingFilter { get; set; }
    }
}

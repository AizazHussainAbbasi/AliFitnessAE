using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AliFitnessAE.Web.Areas.Admin.Views.Shared.Components.UserTrackingChart
{
    public class UserTrackingChartOutPutVModel
    {
        public string scaleText { get; set; }
        public IList<UserTrackingMeasurementListVModel> list { get; set; }
    }
    public class UserTrackingMeasurementListVModel
    {
        public int id { get; set; }
        public decimal count { get; set; }
        public DateTime date { get; set; }
    }
}

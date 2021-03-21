using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AliFitnessAE.Web.Areas.Admin.Views.Shared.Components.UserTrackingChart
{
    public class ChartJsVModel
    {
        public string HtmlControlId { get; set; }
        public ChartJs Chart { get; set; }
        public string ChartJson { get; set; }
    }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Dataset
    {
        public string label { get; set; }
        public List<decimal> data { get; set; }
        public string backgroundColor { get; set; }
        public string borderColor { get; set; }
        //public List<string> backgroundColor { get; set; }
        //public List<string> borderColor { get; set; }
        public int borderWidth { get; set; }
    }

    public class Data
    {
        public List<string> labels { get; set; }
        public List<Dataset> datasets { get; set; }
    }

    public class Ticks
    {
        public bool beginAtZero { get; set; }
    }

    public class YAx
    {
        public Ticks ticks { get; set; }
    }

    public class Scales
    {
        public List<YAx> yAxes { get; set; }
    }

    public class Options
    {
        public Scales scales { get; set; }
    }

    public class ChartJs
    {
        public string type { get; set; }
        public Data data { get; set; }
        public Options options { get; set; }
    }

}

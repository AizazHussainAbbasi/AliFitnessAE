using AliFitnessAE.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AliFitnessAE.Web.Areas.Admin.Models.Common.Modals
{
    public class ViewComponentVModel 
    {
        public string ViewComponentName { get; set; }
        public string Module { get; set; }
        public int? BusinessEntityId { get; set; } 
        public bool IsReadOnly { get; set; } = false;
        public string ViewName { get; set; }
        public PagedResultRequestExtDto SearchModel { get; set; }
    }
}

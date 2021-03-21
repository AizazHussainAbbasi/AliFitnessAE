using Abp.Application.Services.Dto;
using Acme.SimpleTaskApp.Common;
using AliFitnessAE.Common.Enum;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AliFitnessAE.Web.Areas.Admin.Models.Common.Modals
{
    public class Scale
    { 
        public Scale(ILookupAppService _lookupAppService)
        {
            ScaleHeight = _lookupAppService.GetSpecificScaleComboboxItems(EnumScale.Height).Result.Items.Select(p => p.ToSelectListItem()).ToList();
            ScaleWeight = _lookupAppService.GetSpecificScaleComboboxItems(EnumScale.Weight).Result.Items.Select(p => p.ToSelectListItem()).ToList();
            ScaleOther = _lookupAppService.GetSpecificScaleComboboxItems(EnumScale.Other).Result.Items.Select(p => p.ToSelectListItem()).ToList();
        }
        public List<SelectListItem> ScaleHeight { get; set; }
        public List<SelectListItem> ScaleWeight { get; set; }
        public List<SelectListItem> ScaleOther { get; set; }
    }
}

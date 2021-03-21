using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using AliFitnessAE.StatusCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AliFitnessAE.Common.Dto
{
    [AutoMap(typeof(Status))]
    public class StatusDto : EntityDto<int> 
    {
        public int BusinessTypeLKDId { get; set; }
        public LookUpDetailDto BusinessTypeLKD { get; set; }
        public string StatusConst { get; set; }
        public string StatusName { get; set; }
    }
}

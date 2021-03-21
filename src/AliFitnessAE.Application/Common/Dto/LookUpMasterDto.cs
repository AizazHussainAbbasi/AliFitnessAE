using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using AliFitnessAE.LookUp;

namespace AliFitnessAE.Common.Dto
{  
    [AutoMap(typeof(LookUpMaster))]
    public class LookUpMasterDto : EntityDto<int>
    {
        public string LookUpMasterConst { get; set; }
        public string LookUpMasterName { get; set; }
    }
}

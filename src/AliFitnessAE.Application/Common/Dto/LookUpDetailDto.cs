using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using AliFitnessAE.LookUp;

namespace AliFitnessAE.Common.Dto
{
    [AutoMap(typeof(LookUpDetail))] 
    public class LookUpDetailDto : EntityDto<int>
    {
        public string LookUpDetailConst { get; set; }
        public string LookUpDetailName { get; set; }
        public int LookUpDetailOrder { get; set; } 
        public int LookUpMasterId { get; set; } 
        public int ParentLookUpDetailId { get; set; } 
        public LookUpMaster LookUpMaster { get; set; } 
        public LookUpDetail ParentLookUpDetail { get; set; }
    }
}

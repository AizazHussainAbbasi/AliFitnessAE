using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Authorization.Roles;
using Abp.AutoMapper;
using AliFitnessAE.Authorization.Roles;

namespace AliFitnessAE.TopicContent.Dto
{

    [AutoMapTo(typeof(Topic))] 
    public class CreateTopicDto
    {
        [Required]
        [StringLength(AbpRoleBase.MaxNameLength)]
        public string TopicConst { get; set; }
        [Required]
        [StringLength(AbpRoleBase.MaxDisplayNameLength)]
        public string Title { get; set; }
        [Required]
         public string Body { get; set; }
        public bool Published { get; set; }
        public bool IncluedInTopMenu { get; set; }
        public bool IncluedInFooterColumn1 { get; set; }
        public bool IncluedInFooterColumn2 { get; set; }
        public bool IncluedInFooterColumn3 { get; set; } 
    }
}

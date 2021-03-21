using System;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities.Auditing;

namespace AliFitnessAE.TopicContent.Dto
{
    public class TopicListDto : AuditedEntity
    { 
        public string TopicConst { get; set; } 
        public string Title { get; set; } 
        public string Body { get; set; }
        public bool Published { get; set; }
        public bool IncluedInTopMenu { get; set; }
        public bool IncluedInFooterColumn1 { get; set; }
        public bool IncluedInFooterColumn2 { get; set; }
        public bool IncluedInFooterColumn3 { get; set; }
    }
}

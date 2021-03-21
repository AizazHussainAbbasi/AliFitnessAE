using Abp.Domain.Entities.Auditing;
using Abp.Timing;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AliFitnessAE.TopicContent
{
    [Table("Topic")]
    public class Topic : FullAuditedEntity
    {
        public const int MaxTitleLength = 256;
        public const int MaxBodyLength = 64 * 1024; //64KB
         
        public string TopicConst { get; set; }
        [Required]
        [StringLength(MaxTitleLength)]
        public string Title { get; set; }

        [StringLength(MaxBodyLength)]
        public string Body { get; set; }
        public bool Published { get; set; }
        public bool IncluedInTopMenu { get; set; }
        public bool IncluedInFooterColumn1 { get; set; }
        public bool IncluedInFooterColumn2 { get; set; }
        public bool IncluedInFooterColumn3 { get; set; }
 
        public Topic()
        {
            CreationTime = Clock.Now; 
        }

        public Topic(string title, string body = null)
            : this()
        {
            Title = title;
            Body = body;
        }
    }
}

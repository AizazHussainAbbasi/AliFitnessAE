using Abp.Domain.Entities.Auditing;
using Abp.Timing;
using AliFitnessAE.LookUp;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AliFitnessAE.StatusCore
{
    [Table("Status")]
    public class Status : FullAuditedEntity
    { 
        public int BusinessTypeLKDId { get; set; }
        [ForeignKey("BusinessTypeLKDId")]
        public LookUpDetail BusinessEntityLKD { get; set; }
        public string StatusConst{ get; set; }
        public string StatusName{ get; set; }

        public Status()
        {
            CreationTime = Clock.Now;
        }
    } 
}

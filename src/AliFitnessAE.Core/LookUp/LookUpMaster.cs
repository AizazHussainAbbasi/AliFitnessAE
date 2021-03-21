using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AliFitnessAE.LookUp
{
    [Table("LookUpMaster")]
    public class LookUpMaster : FullAuditedEntity
    {
        public string LookUpMasterConst { get; set; }
        public string LookUpMasterName { get; set; }  
    }
}

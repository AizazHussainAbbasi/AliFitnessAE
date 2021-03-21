using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AliFitnessAE.LookUp
{ 
    [Table("LookUpDetail")]
    public class LookUpDetail : FullAuditedEntity
    {
        public string LookUpDetailConst { get; set; }
        public string LookUpDetailName { get; set; }
        public int LookUpDetailOrder { get; set; }
        [ForeignKey("LookUpMasterId")]
        public LookUpMaster LookUpMaster { get; set; }
        [ForeignKey("ParentLookUpDetailId")]
        public LookUpDetail ParentLookUpDetail { get; set; }
    }
}
 
using Abp.Domain.Entities.Auditing;
using Abp.Timing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AliFitnessAE.Document
{ 
    [Table("DocumentType")]
    public class DocumentType : FullAuditedEntity
    { 
        public string DocumentTypeConst { get; set; } 
        public string DocumentTypeName { get; set; } 

        public DocumentType()
        {
            CreationTime = Clock.Now;
        } 
    }
}

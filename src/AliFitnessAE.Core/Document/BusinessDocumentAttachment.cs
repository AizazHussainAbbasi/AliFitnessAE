using Abp.Domain.Entities.Auditing;
using Abp.Timing;
using AliFitnessAE.LookUp;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AliFitnessAE.Document
{ 
    [Table("BusinessDocumentAttachment")]
    public class BusinessDocumentAttachment : FullAuditedEntity
    {
        [ForeignKey("BusinessDocumentId")]
        public BusinessDocument BusinessDocument { get; set; }
        public int BusinessDocumentId { get; set; } 
        public int BusinessEntityId { get; set; } 
        public string  FileName { get; set; }
        public string  FilePath { get; set; }
        public string FileExt { get; set; }
        public int Order { get; set; }

        public BusinessDocumentAttachment()
        {
            CreationTime = Clock.Now;
        } 
    }
}

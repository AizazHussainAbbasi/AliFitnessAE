using Abp.Domain.Entities.Auditing;
using Abp.Timing;
using AliFitnessAE.LookUp;
using System.ComponentModel.DataAnnotations.Schema;

namespace AliFitnessAE.Document
{
    [Table("BusinessDocument")]
    public class BusinessDocument : FullAuditedEntity
    {
        [ForeignKey("DocumentTypeId")]
        public DocumentType DocumentType { get; set; }
        public int DocumentTypeId { get; set; }
        [ForeignKey("BusinessEntityLKDId")]
        public LookUpDetail BusinessEntityLKD { get; set; }
        public int BusinessEntityLKDId { get; set; }
        public bool AllowMultiple { get; set; } 
        public bool IsRequired { get; set; } 
        public int DocShowOrder { get; set; }
         
        public BusinessDocument()
        {
            CreationTime = Clock.Now;
        } 
    }
}

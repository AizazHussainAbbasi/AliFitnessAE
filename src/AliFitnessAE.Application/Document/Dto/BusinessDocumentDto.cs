using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace AliFitnessAE.Document.Dto
{
    [AutoMap(typeof(BusinessDocument))]
    public class BusinessDocumentDto : EntityDto<int>
    { 
        public int DocumentTypeId { get; set; } 
        public DocumentType DocumentType { get; set; }
        public int BusinessEntityLKDId { get; set; }
        public bool AllowMultiple { get; set; }
        public bool IsRequired { get; set; }
        public IList<BusinessDocumentAttachmentDto> BusinessDocumentAttachmentDto { get; set; }
    }
}

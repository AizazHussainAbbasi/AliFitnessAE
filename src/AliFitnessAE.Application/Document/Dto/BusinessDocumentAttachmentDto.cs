using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using AliFitnessAE.Crypto;
using System;
using System.Collections.Generic;
using System.Text;

namespace AliFitnessAE.Document.Dto
{
    [AutoMap(typeof(BusinessDocumentAttachment))]
    public class BusinessDocumentAttachmentDto : EntityDto<int>
    { 
        public string picEnyc { get; set; }
        public int BusinessDocumentId { get; set; }
        public int BusinessEntityId { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string FileExt { get; set; }
        public int Order { get; set; }
        public DateTime CreationTime { get; set; }
    }
}

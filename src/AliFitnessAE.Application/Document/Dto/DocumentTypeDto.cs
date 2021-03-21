using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AliFitnessAE.Document.Dto
{ 
   [AutoMap(typeof(DocumentType))]
    public class DocumentTypeDto : EntityDto<int>
    {
        public string DocumentTypeConst { get; set; }
        public string DocumentTypeName { get; set; }
    }
}

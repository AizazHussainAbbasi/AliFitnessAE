using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Localization;
using AliFitnessAE.Document.Dto;
using Microsoft.AspNetCore.Http;

namespace AliFitnessAE.Web.Areas.Admin.Views.Shared.Components.DocumentUploader
{
    public class DocumentUploaderViewModel
    {
        public long? BusinessEntityId { get; set; }
        public IList<BusinessDocumentDto> DocumentList { get; set; }
        public bool IsReadOnly { get; set; } = false;
    }  
}

using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Localization;
using AliFitnessAE.Document.Dto;
using Microsoft.AspNetCore.Http;

namespace AliFitnessAE.Web.Areas.Admin.Views.Shared.Components.DocumentUploader
{
    public class DeleteVModel
    { 
        public int AttachmentId { get; set; }
        public int BusinessEntityId { get; set; }
        public int BusinessDocumentId { get; set; }
    }
}

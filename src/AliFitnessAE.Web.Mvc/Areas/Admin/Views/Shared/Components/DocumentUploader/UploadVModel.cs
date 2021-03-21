using Microsoft.AspNetCore.Http;

namespace AliFitnessAE.Web.Areas.Admin.Views.Shared.Components.DocumentUploader
{
    public class UploadVModel
    {
        public int BusinessEntityId { get; set; }
        public int BusinessDocumentId { get; set; }
        public int DocumentTypeId { get; set; }
        public IFormFile Image { get; set; }
    } 
}

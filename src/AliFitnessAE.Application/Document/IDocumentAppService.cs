using Abp.Application.Services;
using Abp.Application.Services.Dto;
using AliFitnessAE.Document.Dto;
using AliFitnessAE.TopicContent.Dto;
using System;
using System.Threading.Tasks;

namespace AliFitnessAE.AppService.Document
{ 
    public interface IDocumentAppService : IApplicationService
    {
        Task<ListResultDto<DocumentTypeDto>> GetAllDocumentTypes(int? id = null, string documentTypeConst = null); 
        Task<ListResultDto<BusinessDocumentDto>> GetAllBusinessDocuments(int? id = null, int? businessEntityLKDId =null, int? documentTypeId = null);
        Task<ListResultDto<BusinessDocumentAttachmentDto>> GetAllBusinessDocumentAttachments(int? id = null, int? businessDocumentId = null, int? businessEntityId = null);
        Task<BusinessDocumentAttachmentDto> CreateBusinessDocumentAttachment(BusinessDocumentAttachmentDto input);
        Task<bool> DeleteBusinessDocumentAttachment(BusinessDocumentAttachmentDto input);
    }
}

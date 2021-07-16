using Abp.Application.Services.Dto;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using AliFitnessAE.AppService.Document;
using AliFitnessAE.Document.Dto;
using System.Linq;
using System.Threading.Tasks;
using Abp.Linq.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Abp.Application.Services;
using AliFitnessAE.UserTrackingCore;
using System;
using AliFitnessAE.Crypto;

namespace AliFitnessAE.Document
{
    public class DocumentAppService : ApplicationService, IDocumentAppService
    {
        private readonly IRepository<DocumentType, int> _documentTypeRepository;
        private readonly IRepository<BusinessDocument, int> _businessDocumentRepository;
        private readonly IRepository<BusinessDocumentAttachment, int> _businessDocumentAttachmentRepository;

        public DocumentAppService(IRepository<DocumentType, int> documentTypeRepository,
            IRepository<BusinessDocument, int> businessDocumentRepository,
            IRepository<BusinessDocumentAttachment, int> businessDocumentAttachmentRepository
            )
        {
            _documentTypeRepository = documentTypeRepository;
            _businessDocumentRepository = businessDocumentRepository;
            _businessDocumentAttachmentRepository = businessDocumentAttachmentRepository;
        }

        public async Task<ListResultDto<DocumentTypeDto>> GetAllDocumentTypes(int? id = null, string documentTypeConst = null)
        {
            var documentTypeList = await _documentTypeRepository
                .GetAll()
                .WhereIf(id.HasValue, e => e.Id == id)
                .WhereIf(!string.IsNullOrEmpty(documentTypeConst), e => e.DocumentTypeConst == documentTypeConst)
                .OrderByDescending(t => t.CreationTime)
                .ToListAsync();
            return new ListResultDto<DocumentTypeDto>(
                ObjectMapper.Map<List<DocumentTypeDto>>(documentTypeList)
            );
        }
        public async Task<ListResultDto<BusinessDocumentDto>> GetAllBusinessDocuments(int? id = null, int? businessEntityLKDId = null, int? documentTypeId = null)
        {
            var documentTypeList = await _businessDocumentRepository
                 .GetAll()
                 .Include(x => x.DocumentType)
                 .WhereIf(id.HasValue, e => e.Id == id)
                 .WhereIf(businessEntityLKDId.HasValue, e => e.BusinessEntityLKDId == businessEntityLKDId)
                 .WhereIf(documentTypeId.HasValue, e => e.DocumentTypeId == documentTypeId)
                 .OrderByDescending(t => t.CreationTime)
                 .ToListAsync();
            return new ListResultDto<BusinessDocumentDto>(
                ObjectMapper.Map<List<BusinessDocumentDto>>(documentTypeList)
            );
        }
        public async Task<ListResultDto<BusinessDocumentAttachmentDto>> GetAllBusinessDocumentAttachments(int? id = null, int? businessDocumentId = null, int? businessEntityId = null)
        {
            var documentAttachmentList = await _businessDocumentAttachmentRepository
                .GetAll()
                .WhereIf(id.HasValue, e => e.Id == id)
                .WhereIf(businessDocumentId.HasValue, e => e.BusinessDocumentId == businessDocumentId)
                .WhereIf(businessEntityId.HasValue, e => e.BusinessEntityId == businessEntityId)
                //.WhereIf(businessEntityDateTime.HasValue, e => e.CreationTime == businessEntityDateTime)
                .OrderByDescending(t => t.CreationTime)
                .ToListAsync();
            var list = ObjectMapper.Map<List<BusinessDocumentAttachmentDto>>(documentAttachmentList);
            list.ForEach(x => x.picEnyc = CryptoEngine.EncryptString(x.Id.ToString()));
            return new ListResultDto<BusinessDocumentAttachmentDto>(list);
        }
        public async Task<BusinessDocumentAttachmentDto> CreateBusinessDocumentAttachment(BusinessDocumentAttachmentDto input)
        {
            try
            {
                var businessDocumentAttachment = ObjectMapper.Map<BusinessDocumentAttachment>(input);
                input.Id = await _businessDocumentAttachmentRepository.InsertAndGetIdAsync(businessDocumentAttachment);
                return input;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> DeleteBusinessDocumentAttachment(BusinessDocumentAttachmentDto input)
        {
            try
            {
                var businessDocumentAttachment = ObjectMapper.Map<BusinessDocumentAttachment>(input);
                await _businessDocumentAttachmentRepository.DeleteAsync(input.Id);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

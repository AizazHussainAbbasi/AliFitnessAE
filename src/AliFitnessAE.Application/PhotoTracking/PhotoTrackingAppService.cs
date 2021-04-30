
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.IdentityFramework;
using Acme.SimpleTaskApp.Common;
using AliFitnessAE.AppService.Document;
using AliFitnessAE.Authorization;
using AliFitnessAE.Authorization.Users;
using AliFitnessAE.Common.Constants;
using AliFitnessAE.Common.Enum;
using AliFitnessAE.Document.Dto;
using AliFitnessAE.Dto;
using AliFitnessAE.StatusCore;
using AliFitnessAE.UserTrackingCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AliFitnessAE.AppService
{
    public class PhotoTrackingAppService : AsyncCrudAppService<PhotoTracking, PhotoTrackingDto, int, PagedResultRequestExtDto, CreatePhotoTrackingDto, PhotoTrackingDto>, IPhotoTrackingAppService
    {
        private readonly IRepository<PhotoTracking> _photoTrackingRepository;
        private readonly IRepository<Status> _statusRepository;
        private readonly IDocumentAppService _documentAppService;
        private readonly ILookupAppService _lookupAppService;
        private readonly UserManager _userManager;

        public PhotoTrackingAppService(IRepository<PhotoTracking> repository,
                         ILookupAppService lookupAppService,
                         UserManager userManager,
                         IDocumentAppService documentAppService,
                         IRepository<Status> statusRepository)
            : base(repository)
        {
            _photoTrackingRepository = repository;
            _lookupAppService = lookupAppService;
            _userManager = userManager;
            _documentAppService = documentAppService;
            _statusRepository = statusRepository;
        }
        public PagedResultDto<PhotoTrackingListDto> GetAllPhotoTrackingPagedResult(PagedResultRequestExtDto input, int? documentTypeId = null)
        {
            var queryable = GetAllPhotoTrackingIQueryable(input);
            ////Server Side Pagging
            ////var count = queryable.Count();
            ////var result = queryable.Skip((input.SkipCount)).Take(input.MaxResultCount);
            var list = queryable.ToList()
                               .OrderByDescending(x => x.CreationTime);
            var photoTrackingList = ObjectMapper.Map<IReadOnlyList<PhotoTrackingListDto>>(list);
            var photoTrackingLKDId = _lookupAppService.GetAllLookDetail(null, LookUpDetailConst.PhotoTracking).Result.Items.First().Id;
            var businessDocumentList = _documentAppService.GetAllBusinessDocuments(null, photoTrackingLKDId, documentTypeId).Result.Items;

            for (int i = 0; i < photoTrackingList.Count; i++)
            {
                var listt = new List<BusinessDocumentDto>();
                foreach (var businessDoc in businessDocumentList)
                {
                    var businessDocument = new BusinessDocumentDto()
                    {
                        AllowMultiple = businessDoc.AllowMultiple,
                        BusinessEntityLKDId = businessDoc.BusinessEntityLKDId,
                        DocumentType = businessDoc.DocumentType,
                        DocumentTypeId = businessDoc.DocumentTypeId,
                        Id = businessDoc.Id,
                        IsRequired = businessDoc.IsRequired
                    };
                    businessDocument.BusinessDocumentAttachmentDto = _documentAppService.GetAllBusinessDocumentAttachments(null, businessDoc.Id, photoTrackingList[i].Id).Result.Items.ToList();
                    listt.Add(businessDocument);
                }
                photoTrackingList[i].DocumentList = listt;
            }
            var data = new PagedResultDto<PhotoTrackingListDto>(photoTrackingList.Count(), photoTrackingList);

            return data;
        }
        public IList<PhotoTrackingDto> GetAllPhotoTrackingList(PagedResultRequestExtDto input)
        {
            var queryable = GetAllPhotoTrackingIQueryable(input);
            var list = queryable.ToList()
                             .OrderByDescending(x => x.CreationTime);
            var PhotoTrackingDtoList = ObjectMapper.Map<IList<PhotoTrackingDto>>(list);
            return PhotoTrackingDtoList;
        }
        private IQueryable<PhotoTracking> GetAllPhotoTrackingIQueryable(PagedResultRequestExtDto input)
        {
            IQueryable<PhotoTracking> queryable = null;
            queryable = _photoTrackingRepository.GetAll().Where(x => x.IsDeleted == false).Include(x => x.User).Include(x => x.Status);
            if (input.UserId.HasValue)
                queryable = queryable.Where(x => x.UserId == input.UserId);
            else
            {
                //If loggin user is not admin => loads only loggedin user data
                if (!_userManager.IsAdminUser(AbpSession.UserId.Value))
                    queryable = queryable.Where(x => x.UserId == AbpSession.UserId.Value);
            }
            if (input.FromDate.HasValue)
                queryable = queryable.Where(x => x.CreationTime.Date >= input.FromDate.Value.Date);
            if (input.ToDate.HasValue)
                queryable = queryable.Where(x => x.CreationTime.Date <= input.ToDate.Value.Date);
            if (input.IsApproved.HasValue)
            {
                if (input.IsApproved.Value)
                    queryable = queryable.Where(x => x.StatusId == _statusRepository.GetAll().Where(x => x.StatusConst == StatusConst.Approved).First().Id);
                else
                    queryable = queryable.Where(x => x.StatusId == _statusRepository.GetAll().Where(x => x.StatusConst == StatusConst.UnApproved).First().Id);
            }
            //var list = queryable.ToList()
            //               .OrderByDescending(x => x.CreationTime);
            //var items = ObjectMapper.Map<IList<PhotoTrackingDto>>(list);
            return queryable;
        }
        public int GetPhotoTrackingCount(bool? isApproved = null)
        {
            IQueryable<PhotoTracking> queryable = null;
            queryable = _photoTrackingRepository.GetAll().Where(x => x.IsDeleted == false && x.User.IsActive == true);
            if (isApproved.HasValue)
            {
                if (isApproved.Value)
                    queryable = queryable.Where(x => x.StatusId == _statusRepository.GetAll().Where(x => x.StatusConst == StatusConst.Approved).First().Id);
                else
                    queryable = queryable.Where(x => x.StatusId == _statusRepository.GetAll().Where(x => x.StatusConst == StatusConst.UnApproved).First().Id);
            }
            var count = queryable.Count();
            return count;
        }
        public async Task<PhotoTrackingDto> CreatePhotoTrackingAsync(CreatePhotoTrackingDto input)
        {
            try
            {
                //if (!input.UserId.HasValue)
                //    input.UserId = AbpSession.UserId;
                if (_userManager.IsAdminUser(AbpSession.UserId.Value))
                    input.StatusId = _lookupAppService.GetAllStatus(null, null, StatusConst.Approved, null).Result.Items.First().Id;
                else
                    input.StatusId = _lookupAppService.GetAllStatus(null, null, StatusConst.UnApproved, null).Result.Items.First().Id;

                var PhotoTracking = ObjectMapper.Map<PhotoTracking>(input);
                PhotoTracking.Id = await _photoTrackingRepository.InsertAndGetIdAsync(PhotoTracking);
                return MapToEntityDto(PhotoTracking);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<PhotoTrackingEditDto> GetPhotoTrackingForEdit(EntityDto input)
        {
            var PhotoTracking = await _photoTrackingRepository.GetAsync(input.Id);
            var PhotoTrackingEditDto = ObjectMapper.Map<PhotoTrackingEditDto>(PhotoTracking);

            return PhotoTrackingEditDto;
        }
        public void Delete(int id)
        {
            bool isDelete = true;

            var photoTrackingLKDId = _lookupAppService.GetAllLookDetail(null, LookUpDetailConst.PhotoTracking).Result.Items.First().Id;
            var businessDocumentList = _documentAppService.GetAllBusinessDocuments(null, photoTrackingLKDId, null).Result.Items;

            var photoTracking = _photoTrackingRepository.GetAsync(id).Result;
            foreach (var businessDoc in businessDocumentList)
                businessDoc.BusinessDocumentAttachmentDto = _documentAppService.GetAllBusinessDocumentAttachments(null, businessDoc.Id, photoTracking.Id).Result.Items.ToList();
            if (businessDocumentList.Count > 0)
            {
                foreach (var doc in businessDocumentList)
                {
                    if (doc.BusinessDocumentAttachmentDto.Count > 0)
                    {
                        isDelete = false;
                        break;
                    }
                }
            }
            if (isDelete)
                _photoTrackingRepository.DeleteAsync(photoTracking.Id);
            // return MapToEntityDto(photoTracking); 
        }
        public async Task<PhotoTrackingDto> UpdatePhotoTrackingStatus(UpdateTrackingStatusRequest model)
        {
            try
            {
                var photoTracking = await _photoTrackingRepository.GetAsync(model.Id);
                var statusConst = model.IsApprove ? StatusConst.Approved : StatusConst.UnApproved;
                photoTracking.StatusId = _lookupAppService.GetAllStatus(null, null, statusConst, null).Result.Items.First().Id;
                await _photoTrackingRepository.UpdateAsync(photoTracking);
                return MapToEntityDto(photoTracking);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

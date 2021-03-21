using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using AliFitnessAE.Common.Dto;
using AliFitnessAE.LookUp;
using AliFitnessAE.UserTypeCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Linq.Extensions;
using AliFitnessAE.Common.Constants;
using AliFitnessAE.Authorization.Users;
using AliFitnessAE.Users;
using AliFitnessAE.Users.Dto;
using AliFitnessAE.Common.Enum;
using AliFitnessAE.StatusCore;

namespace Acme.SimpleTaskApp.Common
{
    public class LookupAppService : LookupAppServiceBase, ILookupAppService
    {
        private readonly IUserAppService _userAppService;
        private readonly IRepository<UserType, int> _userTypeRepository;
        private readonly IRepository<LookUpMaster, int> _lookUpMasterRepository;
        private readonly IRepository<LookUpDetail, int> _lookUpDetailRepository;
        private readonly IRepository<Status, int> _statusRepository;

        public LookupAppService(IUserAppService userAppService,
            IRepository<UserType, int> userTypeRepository,
            IRepository<LookUpMaster, int> lookUpMasterRepository,
            IRepository<LookUpDetail, int> lookUpDetailRepository,
            IRepository<Status, int> statusRepository
            )
        {
            _userAppService = userAppService;
            _userTypeRepository = userTypeRepository;
            _lookUpMasterRepository = lookUpMasterRepository;
            _lookUpDetailRepository = lookUpDetailRepository;
            _statusRepository = statusRepository;
        }

        public async Task<ListResultDto<ComboboxItemDto>> GetUserTypeComboboxItems()
        {
            //var master = await GetAllLookUpMaster();
            //var lookupdetail = await GetAllLookDetail(1);
            //var lookupdetail = await GetLookDetailComboboxItems(1);
            var userTypes = await _userTypeRepository.GetAllListAsync();
            return new ListResultDto<ComboboxItemDto>(
                userTypes.Select(p => new ComboboxItemDto(p.Id.ToString("D"), p.UserTypeName)).ToList()
            );
        }
        public async Task<ListResultDto<LookUpMasterDto>> GetAllLookUpMaster(int? id = null, string masterConst = null)
        {
            var lookUpMasterList = await _lookUpMasterRepository
                .GetAll()
                .WhereIf(id.HasValue, e => e.Id == id)
                .WhereIf(!string.IsNullOrEmpty(masterConst), e => e.LookUpMasterConst == masterConst)
                .OrderByDescending(t => t.CreationTime)
                .ToListAsync();
            return new ListResultDto<LookUpMasterDto>(
                ObjectMapper.Map<List<LookUpMasterDto>>(lookUpMasterList)
            );
        }
        public async Task<ListResultDto<LookUpDetailDto>> GetAllLookDetail(int? lookUpMasterId = null, string lookUpDetailConst = null, int? lookUpDetailId = null)
        {
            var lookUpDetailList = await _lookUpDetailRepository
                .GetAll()
                .Include(x => x.LookUpMaster)
                .WhereIf(lookUpMasterId.HasValue, e => e.LookUpMaster.Id == lookUpMasterId)
                .WhereIf(lookUpDetailId.HasValue, e => e.Id == lookUpDetailId)
                .WhereIf(!string.IsNullOrEmpty(lookUpDetailConst), e => e.LookUpDetailConst == lookUpDetailConst)
                .OrderBy(t => t.LookUpDetailOrder)
                .ToListAsync();
            return new ListResultDto<LookUpDetailDto>(
                ObjectMapper.Map<List<LookUpDetailDto>>(lookUpDetailList)
            );
        }
        public async Task<ListResultDto<StatusDto>> GetAllStatus(int? statusId = null,  int? lookUpDetailId = null, string statusConst = null, string lookUpDetailConst = null)
        {
            var lookUpDetailList = await _statusRepository
                .GetAll()
                .WhereIf(statusId.HasValue, e => e.Id == statusId)
                .WhereIf(!string.IsNullOrEmpty(statusConst), e => e.StatusConst == statusConst)
                .WhereIf(lookUpDetailId.HasValue, e => e.BusinessTypeLKDId == lookUpDetailId) 
                .WhereIf(!string.IsNullOrEmpty(lookUpDetailConst), e => e.BusinessEntityLKD.LookUpDetailConst == lookUpDetailConst)
                .OrderBy(t => t.Id)
                .ToListAsync();
            return new ListResultDto<StatusDto>(
                ObjectMapper.Map<List<StatusDto>>(lookUpDetailList)
            );
        }
        public async Task<ListResultDto<ComboboxItemDto>> GetLookDetailComboboxItems(int? lookUpMasterId = null)
        {
            var lookUpDetailList = await _lookUpDetailRepository
                .GetAll()
                .Include(x => x.LookUpMaster)
                .WhereIf(lookUpMasterId.HasValue, e => e.LookUpMaster.Id == lookUpMasterId)
                .OrderBy(t => t.LookUpDetailOrder)
                .ToListAsync();
            return new ListResultDto<ComboboxItemDto>(
                lookUpDetailList.Select(p => new ComboboxItemDto(p.Id.ToString("D"), p.LookUpDetailName)).ToList()
            );
        }
        public async Task<ListResultDto<LookUpDetailDto>> GetMeasurementScaleList(int? lookUpDetailId = null)
        {
            var measurementScaleMasterId = (await GetAllLookUpMaster(null, LookUpMasterConst.MeasurementScale)).Items.FirstOrDefault().Id;
            var measurementScaleItems = (await GetAllLookDetail(measurementScaleMasterId, null, lookUpDetailId)).Items;
            return new ListResultDto<LookUpDetailDto>(
                 ObjectMapper.Map<List<LookUpDetailDto>>(measurementScaleItems)
             );
        }
        public async Task<ListResultDto<ComboboxItemDto>> GetMeasurementScaleComboboxItems(int? lookUpDetailId = null)
        {
            var measurementScaleMasterId = (await GetAllLookUpMaster(null, LookUpMasterConst.MeasurementScale)).Items.FirstOrDefault().Id;
            var lookUpDetailList = await GetMeasurementScaleList(lookUpDetailId);
            return new ListResultDto<ComboboxItemDto>(
                lookUpDetailList.Items.Select(p => new ComboboxItemDto(p.Id.ToString("D"), p.LookUpDetailName)).ToList()
            );
        }
        public async Task<ListResultDto<ComboboxItemDto>> GetSpecificScaleComboboxItems(EnumScale enumScale)
        {
            var measurementScaleMasterId = (await GetAllLookUpMaster(null, LookUpMasterConst.MeasurementScale)).Items.FirstOrDefault().Id;
            var lookUpDetail = await GetMeasurementScaleList();
            var lookUpDetailList = new List<LookUpDetailDto>();
            switch (enumScale)
            {
                case EnumScale.Weight:
                    var weightConst = new[] { LookUpDetailConst.Kg, LookUpDetailConst.Lb };
                    lookUpDetailList = lookUpDetail.Items.Where(x => weightConst.Contains(x.LookUpDetailConst)).ToList();
                    break;
                case EnumScale.Height:
                    var heightConst = new[] { LookUpDetailConst.Cm, LookUpDetailConst.Inches, LookUpDetailConst.Feet };
                    lookUpDetailList = lookUpDetail.Items.Where(x => heightConst.Contains(x.LookUpDetailConst)).ToList();
                    break;
                case EnumScale.Other:
                    var otherConst = new[] { LookUpDetailConst.Cm, LookUpDetailConst.Inches };
                    lookUpDetailList = lookUpDetail.Items.Where(x => otherConst.Contains(x.LookUpDetailConst)).ToList();
                    break;

            }
            return new ListResultDto<ComboboxItemDto>(
                lookUpDetailList.Select(p => new ComboboxItemDto(p.Id.ToString("D"), p.LookUpDetailName)).ToList()
            );
        }
        public async Task<ListResultDto<ComboboxItemDto>> GetUserComboboxItems(int? userId = null)
        {
            var userList = await _userAppService.GetAllAsync(new PagedUserResultRequestDto());
            var userComboboxItemDto = userList.Items.Select(x => new ComboboxItemDto()
            {
                Value = x.Id.ToString(),
                DisplayText = x.FullName
            }).ToList();
            return new ListResultDto<ComboboxItemDto>(
              userComboboxItemDto
           );
        }
        public async Task<ListResultDto<ComboboxItemDto>> GetStatusComboboxItems(int? statusId = null, int? lookUpDetailId = null, string statusConst = null, string lookUpDetailConst = null)
        {
            var allStatuses = (await GetAllStatus(statusId, lookUpDetailId, statusConst, lookUpDetailConst)).Items;
            var statusComboboxItemDto = allStatuses.Select(x => new ComboboxItemDto()
            {
                Value = x.Id.ToString(),
                DisplayText = x.StatusConst
            }).ToList();
            return new ListResultDto<ComboboxItemDto>(
              statusComboboxItemDto
           ); 
        }
    }
}

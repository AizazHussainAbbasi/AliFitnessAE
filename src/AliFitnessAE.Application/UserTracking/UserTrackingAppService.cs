
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.IdentityFramework;
using Acme.SimpleTaskApp.Common;
using AliFitnessAE.Authorization;
using AliFitnessAE.Authorization.Users;
using AliFitnessAE.Common.Enum;
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
    [AbpAuthorize(PermissionNames.Pages_UserTracking)]
    public class UserTrackingAppService : AsyncCrudAppService<UserTracking, UserTrackingDto, int, PagedResultRequestExtDto, CreateUserTrackingDto, UserTrackingDto>, IUserTrackingAppService
    {
        private readonly IRepository<UserTracking> _userTrackingRepository;
        private readonly IRepository<Status> _statusRepository;
        private readonly ILookupAppService _lookupAppService;
        private readonly UserManager _userManager;

        public UserTrackingAppService(IRepository<UserTracking> repository,
                         IRepository<Status> statusRepository,
                         ILookupAppService lookupAppService,
                         UserManager userManager)
            : base(repository)
        {
            _userTrackingRepository = repository;
            _statusRepository = statusRepository;
            _lookupAppService = lookupAppService;
            _userManager = userManager;
        }
        public PagedResultDto<UserTrackingDto> GetAllUserTrackingPagedResult(PagedResultRequestExtDto input)
        { 
            var queryable = GetAllUserTrackingIQueryable(input);
            ////Server Side Pagging
            ////var count = queryable.Count();
            ////var result = queryable.Skip((input.SkipCount)).Take(input.MaxResultCount);
            var list = queryable.ToList()
                               .OrderByDescending(x => x.CreationTime);
            var items = ObjectMapper.Map<IReadOnlyList<UserTrackingDto>>(list);
            return new PagedResultDto<UserTrackingDto>(items.Count(), items);
        }
        public IList<UserTrackingDto> GetAllUserTrackingList(PagedResultRequestExtDto input)
        {
            var queryable = GetAllUserTrackingIQueryable(input);
            var list = queryable.ToList()
                             .OrderByDescending(x => x.CreationTime);
            var userTrackingDtoList = ObjectMapper.Map<IList<UserTrackingDto>>(list);
            return userTrackingDtoList;
        }
        private IQueryable<UserTracking> GetAllUserTrackingIQueryable(PagedResultRequestExtDto input)
        {
            IQueryable<UserTracking> queryable = null;
            if (PermissionChecker.IsGranted(PermissionNames.Pages_UserTracking_GetAll))
            {
                queryable = _userTrackingRepository.GetAll().Where(x => x.IsDeleted == false).Include(x => x.User).Include(x => x.Status).AsNoTracking();
                if (input.UserId.HasValue)
                    queryable = queryable.Where(x => x.UserId == input.UserId);
            }
            else
            {
                queryable = _userTrackingRepository.GetAll().Include(x => x.User).Where(x => x.UserId == AbpSession.UserId.Value).Include(x => x.Status).AsNoTracking();
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
            //var items = ObjectMapper.Map<IList<UserTrackingDto>>(list);
            return queryable;
        }
        public int GetUserTrackingCount(bool? isApproved = null)
        {
            IQueryable<UserTracking> queryable = null;
            queryable = _userTrackingRepository.GetAll().Where(x => x.IsDeleted == false);
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
        public async Task<UserTrackingDto> CreateUserTrackingAsync(CreateUserTrackingDto input, IFormFile file)
        {
            try
            {
                if (!input.UserId.HasValue)
                    input.UserId = AbpSession.UserId;
                if (_userManager.IsAdminUser(AbpSession.UserId.Value))
                    input.StatusId = _lookupAppService.GetAllStatus(null, null, StatusConst.Approved, null).Result.Items.First().Id;
                else
                    input.StatusId = _lookupAppService.GetAllStatus(null, null, StatusConst.UnApproved, null).Result.Items.First().Id;

                var userTracking = ObjectMapper.Map<UserTracking>(input);
                userTracking.Id = await _userTrackingRepository.InsertAndGetIdAsync(userTracking);
                return MapToEntityDto(userTracking);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<UserTrackingEditDto> GetUserTrackingForEdit(EntityDto input)
        {
            var userTracking = await _userTrackingRepository.GetAsync(input.Id);
            var userTrackingEditDto = ObjectMapper.Map<UserTrackingEditDto>(userTracking);

            return userTrackingEditDto;
        }
        public override async Task<UserTrackingDto> UpdateAsync(UserTrackingDto input)
        {
            try
            {
                var userTracking = await _userTrackingRepository.GetAsync(input.Id);
                //Set Status same as exist
                input.StatusId = userTracking.StatusId;

                //Create Date
                input.CreationTime = userTracking.CreationTime;

                ObjectMapper.Map(input, userTracking);

                await _userTrackingRepository.UpdateAsync(userTracking);
                return MapToEntityDto(userTracking);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<UserTrackingDto> UpdateUserTrackingStatus(UpdateTrackingStatusRequest model)
        {
            try
            {
                var userTracking = await _userTrackingRepository.GetAsync(model.Id);
                var statusConst = model.IsApprove ? StatusConst.Approved : StatusConst.UnApproved;
                userTracking.StatusId = _lookupAppService.GetAllStatus(null, null, statusConst, null).Result.Items.First().Id;
                await _userTrackingRepository.UpdateAsync(userTracking);
                return MapToEntityDto(userTracking);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
        //protected override IQueryable<UserTracking> CreateFilteredQuery(PagedUserTrackingResultRequestDto input)
        //{
        //    return -_userTrackingRepository.GetAll()
        //        //.WhereIf(!input.Keyword.IsNullOrWhiteSpace(), x => x.UserName.Contains(input.Keyword) || x.Name.Contains(input.Keyword) || x.EmailAddress.Contains(input.Keyword))
        //        //.WhereIf(input.IsActive.HasValue, x => x.IsActive == input.IsActive);
        //}
    }
}

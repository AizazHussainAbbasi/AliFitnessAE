using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using AliFitnessAE.AppServiceUserType;
using AliFitnessAE.AppUserTypeDto;
using AliFitnessAE.Authorization;
using AliFitnessAE.UserTypeCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AliFitnessAE.AppServiceUserType
{
    [AbpAuthorize(PermissionNames.Pages_UserType)]
    public class UserTypeAppService : AsyncCrudAppService<UserType, UserTypeDto, int, PagedUserTypeResultRequestDto, CreateUserTypeDto, UserTypeDto>, IUserTypeAppService
    {
        private readonly IRepository<UserType> _UserTypeRepository;

        public UserTypeAppService(IRepository<UserType> repository)
            : base(repository)
        {
            _UserTypeRepository = repository;
        }
        public override async Task<UserTypeDto> CreateAsync(CreateUserTypeDto input)
        {
            try
            {
                var UserType = ObjectMapper.Map<UserType>(input);
                await _UserTypeRepository.InsertAsync(UserType);
                //return new UserTypeDto();
                return MapToEntityDto(UserType);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        } 
        public async Task<GetUserTypeForEditOutput> GetUserTypeForEdit(EntityDto input)
        {
            var UserType = await _UserTypeRepository.GetAsync(input.Id);
            var UserTypeEditDto = ObjectMapper.Map<UserTypeEditDto>(UserType);

            return new GetUserTypeForEditOutput
            {
                UserType = UserTypeEditDto
            };
        }
        public async Task<UserTypeDto> GetUserTypeByUserTypeConst(string UserTypeConst)
        {
            //load by store
            var UserType = await _UserTypeRepository.SingleAsync(x=>x.UserTypeConst == UserTypeConst);
            if (UserType == null)
                return null;

            return MapToEntityDto(UserType);
        }
        //public async Task<List<UserType>> GetAllUserTypes()
        //{
        //    var userTypeList = await  _UserTypeRepository.GetAllListAsync();
        //    return userTypeList;
        //}
        //public UserTypeDto GetUserTypeById(int Id)
        //{ 
        //    var UserType =   _UserTypeRepository.Single(x => x.Id == Id);
        //    if (UserType == null)
        //        return null;

        //    return MapToEntityDto(UserType);
        //}
    }
}

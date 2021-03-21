using Abp.Application.Services;
using Abp.Application.Services.Dto;
using AliFitnessAE.AppUserTypeDto;
using AliFitnessAE.UserTypeCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AliFitnessAE.AppServiceUserType
{
    public interface IUserTypeAppService : IAsyncCrudAppService<UserTypeDto, int, PagedUserTypeResultRequestDto, CreateUserTypeDto, UserTypeDto>
    {
        //Task<List<UserType>> GetAllUserTypes();
        Task<GetUserTypeForEditOutput> GetUserTypeForEdit(EntityDto input); 
        Task<UserTypeDto> GetUserTypeByUserTypeConst(string UserTypeConst);
     }
}

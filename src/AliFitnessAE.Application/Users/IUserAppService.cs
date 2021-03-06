using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using AliFitnessAE.Roles.Dto;
using AliFitnessAE.Users.Dto;

namespace AliFitnessAE.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedUserResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);

        Task<bool> ChangePassword(ChangePasswordDto input);
        Task<bool> UpdatePersonalDetailAsync(ChangePersonalDetailDto input);
        Task<bool> UpdateProfilePhoto(ChangeProfilePhotoDto input); 
        int GetUserCount(string userTypeConst, bool? isActive = null);
    }
}

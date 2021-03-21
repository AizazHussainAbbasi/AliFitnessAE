using System.Threading.Tasks;
using Abp.Application.Services;
using AliFitnessAE.Authorization.Accounts.Dto;
using AliFitnessAE.Users.Dto;

namespace AliFitnessAE.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
        Task<bool> ChangePassword(ChangePasswordDto input);
    }
}

using System.Threading.Tasks;
using Abp.Application.Services;
using AliFitnessAE.Sessions.Dto;

namespace AliFitnessAE.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}

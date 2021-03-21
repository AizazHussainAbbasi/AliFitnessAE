using Abp.Application.Services;
using AliFitnessAE.MultiTenancy.Dto;

namespace AliFitnessAE.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}


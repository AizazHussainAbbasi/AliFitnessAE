using Abp.Application.Services;
using Abp.Application.Services.Dto;
using AliFitnessAE.Dto;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AliFitnessAE.AppService
{
    public interface IUserTrackingAppService : IAsyncCrudAppService<UserTrackingDto, int, PagedResultRequestExtDto, CreateUserTrackingDto, UserTrackingDto>
    {
        PagedResultDto<UserTrackingDto> GetAllUserTrackingPagedResult(PagedResultRequestExtDto input);
        IList<UserTrackingDto> GetAllUserTrackingList(PagedResultRequestExtDto input);
        Task<UserTrackingEditDto> GetUserTrackingForEdit(EntityDto input);
        Task<UserTrackingDto> CreateUserTrackingAsync(CreateUserTrackingDto input, IFormFile file);
        Task<UserTrackingDto> UpdateUserTrackingStatus(UpdateTrackingStatusRequest model);
    }
}

using Abp.Application.Services;
using Abp.Application.Services.Dto;
using AliFitnessAE.Dto;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AliFitnessAE.AppService
{
    public interface IPhotoTrackingAppService : IAsyncCrudAppService<PhotoTrackingDto, int, PagedResultRequestExtDto, CreatePhotoTrackingDto, PhotoTrackingDto>
    {
        PagedResultDto<PhotoTrackingListDto> GetAllPhotoTrackingPagedResult(PagedResultRequestExtDto input, int? documentTypeId = null);
        IList<PhotoTrackingDto> GetAllPhotoTrackingList(PagedResultRequestExtDto input);
        Task<PhotoTrackingEditDto> GetPhotoTrackingForEdit(EntityDto input);
        Task<PhotoTrackingDto> CreatePhotoTrackingAsync(CreatePhotoTrackingDto input);
        void Delete(int id);
        Task<PhotoTrackingDto> UpdatePhotoTrackingStatus(UpdateTrackingStatusRequest model);
    }
}

using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using AliFitnessAE;
using AliFitnessAE.Common.Dto;
using AliFitnessAE.Common.Enum;

namespace Acme.SimpleTaskApp.Common
{
    public interface ILookupAppService : IApplicationService
    {
        Task<ListResultDto<ComboboxItemDto>> GetUserTypeComboboxItems();
        Task<ListResultDto<LookUpMasterDto>> GetAllLookUpMaster(int? id = null, string masterConst = null);
        Task<ListResultDto<LookUpDetailDto>> GetAllLookDetail(int? lookUpMasterId = null, string lookUpDetailConst = null, int? lookUpDetailId = null);
        Task<ListResultDto<ComboboxItemDto>> GetLookDetailComboboxItems(int? lookUpMasterId = null);
        Task<ListResultDto<ComboboxItemDto>> GetMeasurementScaleComboboxItems(int? lookUpDetailId = null);
        Task<ListResultDto<ComboboxItemDto>> GetSpecificScaleComboboxItems(EnumScale enumScale);
        Task<ListResultDto<ComboboxItemDto>> GetUserComboboxItems(int? userId = null);
        Task<ListResultDto<StatusDto>> GetAllStatus(int? statusId = null, int? lookUpDetailId = null, string statusConst = null, string lookUpDetailConst = null);
        Task<ListResultDto<ComboboxItemDto>> GetStatusComboboxItems(int? statusId = null, int? lookUpDetailId = null, string statusConst = null, string lookUpDetailConst = null);
    }
    public abstract class LookupAppServiceBase : ApplicationService
    {
        protected LookupAppServiceBase()
        {
            LocalizationSourceName = AliFitnessAEConsts.LocalizationSourceName;
        }
    }
}
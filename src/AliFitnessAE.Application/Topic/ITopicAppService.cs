using Abp.Application.Services;
using Abp.Application.Services.Dto;
using AliFitnessAE.TopicContent.Dto;
using System.Threading.Tasks;

namespace AliFitnessAE.AppService.TopicContent
{ 
    public interface ITopicAppService : IAsyncCrudAppService<TopicDto, int, PagedTopicResultRequestDto, CreateTopicDto, TopicDto>
    {
        Task<GetTopicForEditOutput> GetTopicForEdit(EntityDto input); 
        Task<TopicDto> GetTopicByTopicConst(string topicConst);
    }
}

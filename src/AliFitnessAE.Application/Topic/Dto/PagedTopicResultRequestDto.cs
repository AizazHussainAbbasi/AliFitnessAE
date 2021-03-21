using Abp.Application.Services.Dto;

namespace AliFitnessAE.TopicContent.Dto
{
    public class PagedTopicResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}


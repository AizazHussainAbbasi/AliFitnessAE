using Abp.Application.Services.Dto;

namespace AliFitnessAE.AppUserTypeDto
{
    public class PagedUserTypeResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}


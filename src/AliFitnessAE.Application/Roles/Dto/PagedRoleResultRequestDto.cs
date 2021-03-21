using Abp.Application.Services.Dto;

namespace AliFitnessAE.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}


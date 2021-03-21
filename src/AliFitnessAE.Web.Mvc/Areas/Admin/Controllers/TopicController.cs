using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using AliFitnessAE.Authorization;
using AliFitnessAE.Controllers;
using AliFitnessAE.Roles;
using AliFitnessAE.Web.Models.Admin.Roles;
using AliFitnessAE.AppService.TopicContent;
using AliFitnessAE.TopicContent.Dto;

namespace AliFitnessAE.Web.Admin.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Topic)]
    [Area("Admin")]
    public class TopicController : AliFitnessAEControllerBase
    {
        private readonly ITopicAppService _topicAppService;

        public TopicController(ITopicAppService topicAppService)
        {
            _topicAppService = topicAppService;
        }

        public ActionResult Index() => View();

        public async Task<ActionResult> EditModal(int topicId)
        {
            var output = await _topicAppService.GetTopicForEdit(new EntityDto(topicId));
            return PartialView("_EditModal", output); 
        }

    }
}

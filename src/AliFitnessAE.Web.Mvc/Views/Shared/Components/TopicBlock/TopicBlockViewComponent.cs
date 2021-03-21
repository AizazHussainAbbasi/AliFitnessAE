using AliFitnessAE.AppService.TopicContent;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AliFitnessAE.Web.Views.Shared.Components.TopicBlock
{
    public class TopicBlockViewComponent : AliFitnessAEViewComponent
    {
        private readonly ITopicAppService _topicAppService;

        public TopicBlockViewComponent(ITopicAppService topicAppService)
        {
            _topicAppService = topicAppService;
        }
        public async Task<IViewComponentResult> InvokeAsync(string systemName)
        {
            var model = await _topicAppService.GetTopicByTopicConst(systemName);

            return View(model);
        } 
    }
}

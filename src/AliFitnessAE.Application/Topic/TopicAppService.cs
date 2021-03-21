using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.IdentityFramework;
using AliFitnessAE.Authorization;
using AliFitnessAE.TopicContent;
using AliFitnessAE.TopicContent.Dto;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AliFitnessAE.AppService.TopicContent
{
    [AbpAuthorize(PermissionNames.Pages_Topic)]
    public class TopicAppService : AsyncCrudAppService<Topic, TopicDto, int, PagedTopicResultRequestDto, CreateTopicDto, TopicDto>, ITopicAppService
    {
        private readonly IRepository<Topic> _topicRepository;

        public TopicAppService(IRepository<Topic> repository)
            : base(repository)
        {
            _topicRepository = repository;
        }
        public override async Task<TopicDto> CreateAsync(CreateTopicDto input)
        {
            try
            {
                var topic = ObjectMapper.Map<Topic>(input);
                await _topicRepository.InsertAsync(topic);
                //return new TopicDto();
                return MapToEntityDto(topic);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        } 
        public async Task<GetTopicForEditOutput> GetTopicForEdit(EntityDto input)
        {
            var Topic = await _topicRepository.GetAsync(input.Id);
            var TopicEditDto = ObjectMapper.Map<TopicEditDto>(Topic);

            return new GetTopicForEditOutput
            {
                Topic = TopicEditDto
            };
        }
        [AbpAllowAnonymous]
        public async Task<TopicDto> GetTopicByTopicConst(string topicConst)
        {
            //load by store
            var topic = await _topicRepository.SingleAsync(x=>x.TopicConst == topicConst);
            if (topic == null)
                return null;

            return MapToEntityDto(topic);
        }
    }
}

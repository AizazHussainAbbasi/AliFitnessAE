using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using AliFitnessAE.Authorization.Users;
using AliFitnessAE.StatusCore;
using AliFitnessAE.UserTrackingCore;

namespace AliFitnessAE.Dto
{
    [AutoMap(typeof(PhotoTracking))]
    public class PhotoTrackingDto : EntityDto<int>
    {
        public long UserId { get; set; }
        public User User { get; set; }
        public long StatusId { get; set; }
        public Status Status  { get; set; } 
    }
}

using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using AliFitnessAE.StatusCore;
using AliFitnessAE.UserTrackingCore;
using System.ComponentModel.DataAnnotations;

namespace AliFitnessAE.Dto
{
    [AutoMap(typeof(PhotoTracking))]
    public class PhotoTrackingEditDto: EntityDto<int>
    {
        public long UserId { get; set; }
        public long StatusId { get; set; }
        public Status Status { get; set; } 
    }
}
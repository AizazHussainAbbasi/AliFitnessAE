using Abp.AutoMapper;
using AliFitnessAE.UserTrackingCore;
using System.ComponentModel.DataAnnotations;

namespace AliFitnessAE.Dto
{
    [AutoMapTo(typeof(PhotoTracking))] 
    public class CreatePhotoTrackingDto
    {
        public long UserId { get; set; }
        public int StatusId { get; set; }
    }
}

using Abp.Domain.Entities.Auditing;
using Abp.Timing;
using AliFitnessAE.Authorization.Users;
using AliFitnessAE.StatusCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace AliFitnessAE.UserTrackingCore
{
    [Table("PhotoTracking")]
    public class PhotoTracking : FullAuditedEntity
    {         
        [ForeignKey("UserId")]
        public User User { get; set; }
        public long UserId { get; set; }
        [ForeignKey("StatusId")]
        public Status Status { get; set; }
        public int StatusId { get; set; } 

        public PhotoTracking()
        {
            CreationTime = Clock.Now;
        } 
    }
}

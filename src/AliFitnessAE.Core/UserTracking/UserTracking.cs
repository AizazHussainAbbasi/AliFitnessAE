using Abp.Domain.Entities.Auditing;
using Abp.Timing;
using AliFitnessAE.Authorization.Users;
using AliFitnessAE.StatusCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace AliFitnessAE.UserTrackingCore
{
    [Table("UserTracking")]
    public class UserTracking : FullAuditedEntity
    {         
        [ForeignKey("UserId")]
        public User User { get; set; }
        public long UserId { get; set; }
        [ForeignKey("StatusId")]
        public Status Status { get; set; }
        public int StatusId { get; set; }
        public decimal Height  { get; set; }
        public int HeightLkdId { get; set; }
        public decimal Weight { get; set; }
        public int WeightLkdId { get; set; }
        public decimal Hip { get; set; }
        public int HipLkdId { get; set; }
        public decimal BellyButtonWaist { get; set; }
        public int BellyButtonWaistLkdId { get; set; }
        public decimal HipBoneWaist { get; set; }
        public int HipBoneWaistLkdId { get; set; }
        public decimal Chest { get; set; }
        public int ChestLkdId { get; set; }
        public decimal RightArm { get; set; }
        public int RightArmLkdId { get; set; }
        public decimal LeftArm { get; set; }
        public int LeftArmLkdId { get; set; }
        public decimal RightThigh { get; set; }
        public int RightThighLkdId { get; set; }
        public decimal LeftThigh { get; set; }
        public int LeftThighLkdId { get; set; }
        public decimal RightCalve { get; set; }
        public int RightCalveLkdId { get; set; }
        public decimal LeftCalve { get; set; }
        public int LeftCalveLkdId { get; set; }
        public decimal RightForeArm { get; set; }
        public int RightForeArmLkdId { get; set; }
        public decimal LeftForeArm { get; set; } 
        public int LeftForeArmLkdId { get; set; } 

        public UserTracking()
        {
            CreationTime = Clock.Now;
        } 
    }
}

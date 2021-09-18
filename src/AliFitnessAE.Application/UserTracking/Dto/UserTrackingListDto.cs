using Abp.Application.Services.Dto;
using Abp.Domain.Entities.Auditing;
using AliFitnessAE.LookUp;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace AliFitnessAE.Dto
{
    public class UserTrackingListDto : AuditedEntity
    {
        public long UserId { get; set; }
        public decimal Height { get; set; }
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
        public DateTime UserTrackingDate { get; set; }
    }
}

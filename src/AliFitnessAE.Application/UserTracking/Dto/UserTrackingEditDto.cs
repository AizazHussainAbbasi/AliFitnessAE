﻿using Abp.Application.Services.Dto;
using Abp.Authorization.Roles;
using Abp.AutoMapper;
using AliFitnessAE.StatusCore;
using AliFitnessAE.UserTrackingCore;
using System.ComponentModel.DataAnnotations;

namespace AliFitnessAE.Dto
{
    [AutoMap(typeof(UserTracking))]
    public class UserTrackingEditDto: EntityDto<int>
    {
        public long UserId { get; set; }
        public long StatusId { get; set; }
        public Status Status { get; set; }
        [Required]
        public decimal Height { get; set; }
        public int HeightLkdId { get; set; }
        [Required]
        public decimal Weight { get; set; }
        public int WeightLkdId { get; set; }
        [Required]
        public decimal Hip { get; set; }
        public int HipLkdId { get; set; }
        [Required]
        public decimal BellyButtonWaist { get; set; }
        public int BellyButtonWaistLkdId { get; set; }
        [Required]
        public decimal HipBoneWaist { get; set; }
        public int HipBoneWaistLkdId { get; set; }
        [Required]
        public decimal Chest { get; set; }
        public int ChestLkdId { get; set; }
        [Required]
        public decimal RightArm { get; set; }
        public int RightArmLkdId { get; set; }
        [Required]
        public decimal LeftArm { get; set; }
        public int LeftArmLkdId { get; set; }
        [Required]
        public decimal RightThigh { get; set; }
        public int RightThighLkdId { get; set; }
        [Required]
        public decimal LeftThigh { get; set; }
        public int LeftThighLkdId { get; set; }
        [Required]
        public decimal RightCalve { get; set; }
        public int RightCalveLkdId { get; set; }
        [Required]
        public decimal LeftCalve { get; set; }
        public int LeftCalveLkdId { get; set; }
        [Required]
        public decimal RightForeArm { get; set; }
        public int RightForeArmLkdId { get; set; }
        [Required]
        public decimal LeftForeArm { get; set; }
        public int LeftForeArmLkdId { get; set; }
    }
}
using Abp.Application.Services.Dto;
using Abp.Authorization.Users;
using Abp.AutoMapper;
using AliFitnessAE.Authorization.Users;
using AliFitnessAE.Common.Constants;
using System;
using System.ComponentModel.DataAnnotations;

namespace AliFitnessAE.Users.Dto
{ 
    public class ChangeProfilePhotoDto
    {
        public long Id { get; set; }  
        public string ProfilePhotoPath { get; set; }
    }
}

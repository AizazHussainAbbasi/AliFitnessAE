using AliFitnessAE.AppUserTypeDto;
using AliFitnessAE.Authorization.Users;
using AliFitnessAE.Roles.Dto;
using AliFitnessAE.Users.Dto;
using AliFitnessAE.Web.Areas.Admin.Views.Shared.Components.DocumentUploader;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace AliFitnessAE.Web.Models.Admin.Users
{
    public class EditPersonalDetailViewModel
    {
        public UserDto User { get; set; } 
        public List<SelectListItem> Gender { get; set; }  
        public DocumentUploaderViewModel ProfilePhoto { get; set; } 
    }
}

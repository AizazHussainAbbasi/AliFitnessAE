using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;
using AliFitnessAE.Authorization.Users;
using AliFitnessAE.Document.Dto;
using AliFitnessAE.LookUp;
using AliFitnessAE.StatusCore;
using AliFitnessAE.UserTrackingCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace AliFitnessAE.Dto
{
    [AutoMap(typeof(PhotoTracking))]
    public class PhotoTrackingListDto : AuditedEntity
    {
        public PhotoTrackingListDto()
        {
            DocumentList = new List<BusinessDocumentDto>();
        }
        public long UserId { get; set; }
        public User User { get; set; }
        public long StatusId { get; set; }
        public Status Status { get; set; }
        public IList<BusinessDocumentDto> DocumentList { get; set; }
    }
}

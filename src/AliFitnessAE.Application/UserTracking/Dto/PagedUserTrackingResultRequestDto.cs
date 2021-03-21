using Abp.Application.Services.Dto;
using Abp.Runtime.Session;
using AliFitnessAE.Common.Enum;
using AliFitnessAE.Crypto;
using System;

namespace AliFitnessAE.Dto
{
    public class PagedResultRequestExtDto : PagedResultRequestDto
    {
        //public PagedResultRequestExtDto()
        //{
        //    //UserId = (!string.IsNullOrWhiteSpace(UserIdEnyc)) ? (int?) Convert.ToInt32(CryptoEngine.DecryptString(UserIdEnyc)) : null;
        //}
        public string Keyword { get; set; }
        public int? UserId { get; set; }
        public string UserIdEnyc { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int MeasurementScaleLKDId { get; set; }
        public EnumUserTrackingBodyPart BodyPart { get; set; }
        public EnumDocumentType DocumentType { get; set; }
    }
}


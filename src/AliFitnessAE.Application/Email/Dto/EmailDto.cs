using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace AliFitnessAE.Document.Dto
{
    public class EmailDto
    {
        public string FromConst { get; set; }
        public string EmailTo { get; set; }
        public string EmailSubject { get; set; }
        public string EmailBody { get; set; }
        public List<string> AttachmentInBodyList { get; set; }
        public IFormFile FormFile { get; set; } 
    }
}

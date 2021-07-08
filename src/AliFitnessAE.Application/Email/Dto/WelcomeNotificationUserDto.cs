using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AliFitnessAE.Document.Dto
{
    public class WelcomeNotificationUserDto : NotificationUserBaseDto
    {
    }
    public class ForgotPasswordNotificationUserDto : NotificationUserBaseDto
    { 
    }
    public class NotificationUserBaseDto
    {
        public string Subject { get; set; }
        public string Date { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Message { get; set; }
        public string FullName { get; set; }
    }
}

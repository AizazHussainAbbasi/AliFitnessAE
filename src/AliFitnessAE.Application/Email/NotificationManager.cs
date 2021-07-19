using Abp.Application.Services;
using AliFitnessAE.Authorization.Users;
using AliFitnessAE.Common.Constants;
using AliFitnessAE.Document.Dto;
using AliFitnessAE.NotificationTemplate;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using MimeKit;
using MimeKit.Utils;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Threading.Tasks;

namespace AliFitnessAE.Email
{
    public class NotificationManager : ApplicationService, INotificationManager
    {
        private readonly IEmailService _emailService;
        private readonly ITemplateManager _templateManager;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public NotificationManager(
            IEmailService emailService,
            ITemplateManager templateManager,
              IWebHostEnvironment webHostEnvironment)
        {
            _emailService = emailService;
            _templateManager = templateManager;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task SendWelcomeEmail(WelcomeNotificationUserDto model)
        {
            var subject = "Verify your email one time to complete registration";
            dynamic expando = new ExpandoObject();
            expando.Subject = subject;
            expando.Date = String.Format("{0:dddd, d MMMM yyyy}", DateTime.Now);
            expando.FullName = model.FullName;
            expando.Email = model.Email;
            expando.UserName = model.UserName;
            expando.Message = model.Message;
            var messageBodyHTML = _templateManager.GetTemplate(NotificationTemplateConst.Welcome_Account_Registration, expando);
             
            string emailTemplateFolder = Path.Combine(_webHostEnvironment.WebRootPath, Path.Combine("images", "email")); 
            List<string> attachmentList = new List<string>();
            attachmentList.Add(Path.Combine(emailTemplateFolder, "logo.png"));
  
            var emailDto = new EmailDto()
            {
                FromConst = NotificationFromConst.Info,
                EmailTo = model.Email,
                EmailSubject = subject,
                EmailBody = messageBodyHTML,
                AttachmentInBodyList = attachmentList,
                //formFile = new FormFile(new StreamReader(,0,120,"akafsf","TestFile")
            };
            await _emailService.SendEmailAsync(emailDto); 
        }
        public async Task SendForgotPasswordEmail(ForgotPasswordNotificationUserDto model)
        { 
            dynamic expando = new ExpandoObject();
            expando.Subject = model.Subject;
            expando.Email = model.Email;
            expando.FullName = model.FullName;
            expando.Message = model.Message;
            var messageBodyHTML = _templateManager.GetTemplate(NotificationTemplateConst.Forgot_Password, expando);

            string emailTemplateFolder = Path.Combine(_webHostEnvironment.WebRootPath, Path.Combine("images", "email"));
            List<string> attachmentList = new List<string>();
            attachmentList.Add(Path.Combine(emailTemplateFolder, "logo.png")); 

            var emailDto = new EmailDto()
            {
                FromConst = NotificationFromConst.Info,
                EmailTo = model.Email,
                EmailSubject = model.Subject,
                EmailBody = messageBodyHTML,
                AttachmentInBodyList = attachmentList,
            };
            await _emailService.SendEmailAsync(emailDto);
        }
    }
}

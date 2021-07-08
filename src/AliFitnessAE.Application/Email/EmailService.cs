using Abp.Application.Services;
using Abp.Configuration;
using AliFitnessAE.Common.Constants;
using AliFitnessAE.Document.Dto;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;
using MimeKit.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AliFitnessAE.Email
{
    public class EmailService : ApplicationService, IEmailService
    {
        private readonly ISettingManager _settingManager;
        private string SmtpHost = null;
        private string SmtpPort = null;
        private string SmtpUser = null;
        private string SmtpPass = null;
        public EmailService(ISettingManager settingManager)
        {
            _settingManager = settingManager;
            SmtpHost = _settingManager.GetSettingValue("SmtpHost");
            SmtpPort = _settingManager.GetSettingValue("SmtpPort");
            SmtpUser = _settingManager.GetSettingValue("SmtpUser");
            SmtpPass = _settingManager.GetSettingValue("SmtpPass");
        }

        public async Task SendEmailAsync(EmailDto emailDto)
        {
            try
            {
                string fromAddress = string.Empty;
                switch (emailDto.FromConst)
                {
                    case NotificationFromConst.Info:
                        fromAddress = _settingManager.GetSettingValue("From_Info");
                        break;
                    default:
                        break;
                }

                var message = new MimeMessage();
                message.From.Add(MailboxAddress.Parse(fromAddress));
                message.To.Add(MailboxAddress.Parse(emailDto.EmailTo));
                message.Subject = emailDto.EmailSubject;
                var builder = new BodyBuilder();
                builder.HtmlBody = emailDto.EmailBody;

                //Attachment Inside Mail Body
                if (emailDto.AttachmentInBodyList != null && emailDto.AttachmentInBodyList.Count > 0)
                {
                    string[] contentIDs = new string[emailDto.AttachmentInBodyList.Count];
                    for (int i = 0; i < emailDto.AttachmentInBodyList.Count; i++)
                    {
                        var source = builder.LinkedResources.Add(emailDto.AttachmentInBodyList[i]);
                        source.ContentId = MimeUtils.GenerateMessageId();
                        contentIDs[i] = source.ContentId;
                    }
                    builder.HtmlBody = string.Format(emailDto.EmailBody, contentIDs);
                }
                //Attchment in Attachment section
                if (emailDto.FormFile != null)
                {
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        await emailDto.FormFile.CopyToAsync(memoryStream);
                        builder.Attachments.Add(emailDto.FormFile.FileName, memoryStream.ToArray());
                    }
                } 

                message.Body = builder.ToMessageBody();

                using (var client = new SmtpClient())
                {
                    //client.LocalDomain = ec.LocalDomain; 
                    await client.ConnectAsync(SmtpHost, Convert.ToInt32(SmtpPort), SecureSocketOptions.Auto).ConfigureAwait(false);
                    await client.AuthenticateAsync(new NetworkCredential(SmtpUser, SmtpPass));
                    await client.SendAsync(message).ConfigureAwait(false);
                    await client.DisconnectAsync(true).ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }


        public async Task SendEmailAsync(string from, String to, String subject, String html)
        {
            try
            {
                string fromAddress = string.Empty;
                switch (from)
                {
                    case NotificationFromConst.Info:
                        fromAddress = _settingManager.GetSettingValue("From_Info");
                        break;
                    default:
                        break;
                }

                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse(fromAddress));
                email.To.Add(MailboxAddress.Parse(to));
                email.Subject = subject;
                email.Body = new TextPart(TextFormat.Html) { Text = html };

                using (var client = new SmtpClient())
                {
                    //client.LocalDomain = ec.LocalDomain;

                    await client.ConnectAsync(SmtpHost, Convert.ToInt32(SmtpPort), SecureSocketOptions.Auto).ConfigureAwait(false);
                    await client.AuthenticateAsync(new NetworkCredential(SmtpUser, SmtpPass));
                    await client.SendAsync(email).ConfigureAwait(false);
                    await client.DisconnectAsync(true).ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
    }
}

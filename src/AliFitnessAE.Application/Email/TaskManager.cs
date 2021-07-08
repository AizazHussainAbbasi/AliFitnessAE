using Abp.Configuration;
using Abp.Domain.Services;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AliFitnessAE.Email
{
    public interface IEmailServiceOld
    {
        void Send(string from, string to, string subject, string html);
    }
    public class EmailServiceOld : IEmailServiceOld
    {
        private readonly ISettingManager _settingManager;
 
        public EmailServiceOld(ISettingManager appSettings)
        {
            _settingManager = appSettings;
        }

        public void Send(string from, string to, string subject, string html)
        {
            var SmtpHost = _settingManager.GetSettingValue("SmtpHost");
            var SmtpPort = _settingManager.GetSettingValue("SmtpPort");
            var SmtpUser = _settingManager.GetSettingValue("SmtpUser");
            var SmtpPass = _settingManager.GetSettingValue("SmtpPass");

            // create message
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(from));
            email.To.Add(MailboxAddress.Parse(to));
            email.Subject = subject;
            email.Body = new TextPart(TextFormat.Html) { Text = html };

            // send email
            using var smtp = new SmtpClient();
            smtp.Connect(SmtpHost, Convert.ToInt32(SmtpPort), SecureSocketOptions.None);
            smtp.Authenticate(SmtpUser, SmtpPass);
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    } 
}

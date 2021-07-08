using AliFitnessAE.Document.Dto;
using Microsoft.AspNetCore.Http;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace AliFitnessAE.Email
{
    public interface IEmailService
    {
        //Task SendEmailAsync(string from, string email, string subject, string html);
       // Task SendEmailAsync(string from, string email, string subject, String html, List<string> attachments = null, MemoryStream memoryStream =null);
        //Task SendEmailAsync(string from, string email, string subject, String html,  MemoryStream memoryStream =null);
        Task SendEmailAsync(EmailDto emailDto);
    }
}

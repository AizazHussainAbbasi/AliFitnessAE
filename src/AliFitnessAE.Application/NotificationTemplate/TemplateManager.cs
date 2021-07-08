using Abp.Application.Services;
using AliFitnessAE.Common.Constants;
using Microsoft.AspNetCore.Hosting;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace AliFitnessAE.NotificationTemplate
{
    public class TemplateManager : ApplicationService, ITemplateManager
    {
        private readonly IHostingEnvironment _env;
        public TemplateManager(IHostingEnvironment env)
        {
            _env = env;
        }
        public string GetTemplate(string templateName, dynamic model)
        {

            string messageBody = string.Empty;
            //var webRoot = _env.WebRootPath; //get wwwroot Folder
            var pathToFile = _env.WebRootPath
                    + Path.DirectorySeparatorChar.ToString()
                    + "Templates"
                    + Path.DirectorySeparatorChar.ToString()
                    + "Email"
                    + Path.DirectorySeparatorChar.ToString()
                    + templateName + ".html";
            var builder = new BodyBuilder();
            using (StreamReader SourceReader = System.IO.File.OpenText(pathToFile))
            {
                builder.HtmlBody = SourceReader.ReadToEnd();
            }

            switch (templateName)
            {
                case NotificationTemplateConst.Welcome_Account_Registration:

                    //{0} : Logo_Img
                    //{1} : FullName
                    //{2} : Message
                    //{3} : Email
                    //{4} : UserName 
                    //{5} : CEO_Img   
                    //{6} : Logo_Img   
                    //{7} : FB_Img
                    //{8} : Twitter_Img   
                    //{9} : Insta_Img
                    //{10} : Linked_Img  
                    //{11} : CopyRight_Year  
                    messageBody = string.Format(builder.HtmlBody,
                        "{0}",
                        model.FullName,
                        model.Message,
                        model.Email,
                        model.UserName,
                        "{1}",
                        "{2}",
                        "{3}",
                        "{4}",
                        "{5}",
                        "{6}",
                        DateTime.Now.Year
                        );
                    break;
                case NotificationTemplateConst.Forgot_Password:
                     
                    //{0} : FullName
                    //{1} : Message 
                    //{2} : Logo_Img   
                    //{3} : FB_Img
                    //{4} : Twitter_Img   
                    //{5} : Insta_Img
                    //{6} : Linked_Img  
                    //{7} : CopyRight_Year  
                    messageBody = string.Format(builder.HtmlBody, 
                        model.FullName,
                        model.Message, 
                        "{0}",
                        "{1}",
                        "{2}",
                        "{3}",
                        "{4}",
                        DateTime.Now.Year
                        );
                    break;
            }

            return messageBody;
        }
    }
}

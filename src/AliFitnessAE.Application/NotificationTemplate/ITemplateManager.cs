using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AliFitnessAE.NotificationTemplate
{
    public interface ITemplateManager
    {
        string GetTemplate(string templateName, dynamic model); 
    }
}

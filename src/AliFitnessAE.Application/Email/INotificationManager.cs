using AliFitnessAE.Authorization.Users;
using AliFitnessAE.Document.Dto;
using System.Threading.Tasks;

namespace AliFitnessAE.Email
{
    public interface INotificationManager
    {
       Task SendWelcomeEmail(WelcomeNotificationUserDto model);
       Task SendForgotPasswordEmail(ForgotPasswordNotificationUserDto model);
    }
}

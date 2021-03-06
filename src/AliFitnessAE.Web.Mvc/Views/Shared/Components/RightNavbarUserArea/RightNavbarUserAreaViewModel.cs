using AliFitnessAE.Crypto;
using AliFitnessAE.Sessions.Dto;

namespace AliFitnessAE.Web.Views.Shared.Components.RightNavbarUserArea
{
    public class RightNavbarUserAreaViewModel
    {
        public GetCurrentLoginInformationsOutput LoginInformations { get; set; }

        public bool IsMultiTenancyEnabled { get; set; }

        public string GetShownLoginName()
        {
            var userName = LoginInformations.User.UserName;

            if (!IsMultiTenancyEnabled)
            {
                return userName;
            }

            return LoginInformations.Tenant == null
                ? ".\\" + userName
                : LoginInformations.Tenant.TenancyName + "\\" + userName;
        }
        public string GetProfilePhotoPath()
        {
            if (LoginInformations.User.ProfilePhotoPath == null)
                return null;
            var profilePhotoPath = CryptoEngine.EncryptString(LoginInformations.User.ProfilePhotoPath);
            return profilePhotoPath;
        }
    }
}


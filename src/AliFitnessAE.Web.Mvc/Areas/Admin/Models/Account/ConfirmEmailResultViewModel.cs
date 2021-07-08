namespace AliFitnessAE.Web.Models.Admin.Account
{
    public class ConfirmEmailResultViewModel
    { 
        public string FullName { get; set; } 
        public string Email { get; set; }
        public bool? IsEmailConfirmed { get; set; } = false;
    }
}

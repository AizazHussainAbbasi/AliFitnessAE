using System.ComponentModel.DataAnnotations;

namespace AliFitnessAE.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}
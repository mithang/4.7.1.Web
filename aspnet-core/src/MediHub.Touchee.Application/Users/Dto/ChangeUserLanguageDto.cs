using System.ComponentModel.DataAnnotations;

namespace MediHub.Touchee.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BlogProject.Entities.Dtos.UserDtos
{
    public class UserPasswordChangeDto
    {
        [DisplayName("Current Password")]
        [Required(ErrorMessage = "{0} Cannot Be Empty")]
        [MaxLength(50, ErrorMessage = "{0} Cannot Be More Than {1} Characters.")]
        [MinLength(5, ErrorMessage = "{0} Cannot Be Less Than {1} Characters.")]
        [DataType(DataType.Password)]

        public string CurrentPassword { get; set; }

        [DisplayName("New Password")]
        [Required(ErrorMessage = "{0} Cannot Be Empty")]
        [MaxLength(50, ErrorMessage = "{0} Cannot Be More Than {1} Characters.")]
        [MinLength(5, ErrorMessage = "{0} Cannot Be Less Than {1} Characters.")]
        [DataType(DataType.Password)]

        public string NewPassword { get; set; }

        [DisplayName("Repeat Password")]
        [Required(ErrorMessage = "{0} Cannot Be Empty")]
        [MaxLength(50, ErrorMessage = "{0} Cannot Be More Than {1} Characters.")]
        [MinLength(5, ErrorMessage = "{0} Cannot Be Less Than {1} Characters.")]
        [DataType(DataType.Password)]
        [Compare("NewPassword",ErrorMessage = "Passwords is Not Match!")]

        public string RepeatPassword { get; set; }
    }
}

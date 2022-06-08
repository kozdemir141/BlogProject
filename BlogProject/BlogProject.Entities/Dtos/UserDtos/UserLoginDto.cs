using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BlogProject.Entities.Dtos.UserDtos
{
    public class UserLoginDto
    {
        [DisplayName("Email")]
        [Required(ErrorMessage = "{0} Cannot Be Empty")]
        [MaxLength(50, ErrorMessage = "{0} Cannot Be More Than {1} Characters.")]
        [MinLength(3, ErrorMessage = "{0} Cannot Be Less Than {1} Characters.")]
        [DataType(DataType.EmailAddress)]

        public string Email { get; set; }

        [DisplayName("Password")]
        [Required(ErrorMessage = "{0} Cannot Be Empty")]
        [MaxLength(50, ErrorMessage = "{0} Cannot Be More Than {1} Characters.")]
        [MinLength(5, ErrorMessage = "{0} Cannot Be Less Than {1} Characters.")]
        [DataType(DataType.Password)]

        public string Password { get; set; }

        [DisplayName("Remember Me")]

        public bool RememberMe { get; set; }
    }
}

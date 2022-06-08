using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace BlogProject.Entities.Dtos.UserDtos
{
    public class UserUpdateDto
    {
        [Required]
        public int Id { get; set; }

        [DisplayName("Username")]
        [Required(ErrorMessage = "{0} Cannot Be Empty")]
        [MaxLength(50, ErrorMessage = "{0} Cannot Be More Than {1} Characters.")]
        [MinLength(3, ErrorMessage = "{0} Cannot Be Less Than {1} Characters.")]
        public string Username { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "{0} Cannot Be Empty")]
        [MaxLength(50, ErrorMessage = "{0} Cannot Be More Than {1} Characters.")]
        [MinLength(3, ErrorMessage = "{0} Cannot Be Less Than {1} Characters.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DisplayName("Phone Number")]
        [Required(ErrorMessage = "{0} Cannot Be Empty")]
        [MaxLength(13, ErrorMessage = "{0} Cannot Be More Than {1} Characters.")]
        [MinLength(13, ErrorMessage = "{0} Cannot Be Less Than {1} Characters.")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [DisplayName("Update Picture")]
        [DataType(DataType.Upload)]
        public IFormFile PictureFile { get; set; }

        [DisplayName("Picture")]
        public string Picture { get; set; }

        [DisplayName("FirstName")]
        [Required(ErrorMessage = "{0} Cannot Be Empty")]
        [MaxLength(30, ErrorMessage = "{0} Cannot Be More Than {1} Characters.")]
        [MinLength(2, ErrorMessage = "{0} Cannot Be Less Than {1} Characters.")]

        public string FirstName { get; set; }

        [DisplayName("LastName")]
        [Required(ErrorMessage = "{0} Cannot Be Empty")]
        [MaxLength(30, ErrorMessage = "{0} Cannot Be More Than {1} Characters.")]
        [MinLength(2, ErrorMessage = "{0} Cannot Be Less Than {1} Characters.")]

        public string LastName { get; set; }

        [DisplayName("About")]
        [Required(ErrorMessage = "{0} Cannot Be Empty")]
        [MaxLength(1000, ErrorMessage = "{0} Cannot Be More Than {1} Characters.")]
        [MinLength(5, ErrorMessage = "{0} Cannot Be More Than {1} Characters.")]

        public string About { get; set; }

        [DisplayName("Twitter")]
        [MaxLength(250, ErrorMessage = "{0} Cannot Be More Than {1} Characters.")]
        [MinLength(20, ErrorMessage = "{0} Cannot Be More Than {1} Characters.")]

        public string TwitterLink { get; set; }

        [DisplayName("Facebook")]
        [MaxLength(250, ErrorMessage = "{0} Cannot Be More Than {1} Characters.")]
        [MinLength(20, ErrorMessage = "{0} Cannot Be More Than {1} Characters.")]

        public string FacebookLink { get; set; }

        [DisplayName("Instagram")]
        [MaxLength(250, ErrorMessage = "{0} Cannot Be More Than {1} Characters.")]
        [MinLength(20, ErrorMessage = "{0} Cannot Be More Than {1} Characters.")]

        public string InstagramLink { get; set; }

        [DisplayName("LinkedIn")]
        [MaxLength(250, ErrorMessage = "{0} Cannot Be More Than {1} Characters.")]
        [MinLength(20, ErrorMessage = "{0} Cannot Be More Than {1} Characters.")]

        public string LinkedInLink { get; set; }

        [DisplayName("Youtube")]
        [MaxLength(250, ErrorMessage = "{0} Cannot Be More Than {1} Characters.")]
        [MinLength(20, ErrorMessage = "{0} Cannot Be More Than {1} Characters.")]

        public string YoutubeLink { get; set; }

        [DisplayName("GitHub")]
        [MaxLength(250, ErrorMessage = "{0} Cannot Be More Than {1} Characters.")]
        [MinLength(20, ErrorMessage = "{0} Cannot Be More Than {1} Characters.")]

        public string GitHubLink { get; set; }

        [DisplayName("Website")]
        [MaxLength(250, ErrorMessage = "{0} Cannot Be More Than {1} Characters.")]
        [MinLength(20, ErrorMessage = "{0} Cannot Be More Than {1} Characters.")]

        public string WebsiteLink { get; set; }
    }
}

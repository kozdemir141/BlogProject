using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BlogProject.Entities.Dtos.CommentDtos
{
	public class CommentAddDto
	{
        [DisplayName("Comment")]
        [Required(ErrorMessage = "{0} Cannot Be Empty")]
        [MaxLength(2000, ErrorMessage = "{0} Cannot Be More Than {1} Characters.")]
        [MinLength(2, ErrorMessage = "{0} Cannot Be Less Than {1} Characters.")]

        public string Text { get; set; }

        [DisplayName("Your Name")]
        [Required(ErrorMessage = "{0} Cannot Be Empty")]
        [MaxLength(50, ErrorMessage = "{0} Cannot Be More Than {1} Characters.")]
        [MinLength(2, ErrorMessage = "{0} Cannot Be Less Than {1} Characters.")]

        public string CreatedByName { get; set; }

        [Required(ErrorMessage = "{0} Cannot Be Empty")]

        public int ArticleId { get; set; }
    }
}


using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BlogProject.Entities.Dtos.CommentDtos
{
	public class CommentUpdateDto
	{
        [Required(ErrorMessage = "{0} Cannot Be Empty")]

        public int Id { get; set; }

        [DisplayName("Comment")]
        [Required(ErrorMessage = "{0} Cannot Be Empty")]
        [MaxLength(1000, ErrorMessage = "{0} Cannot Be More Than {1} Characters.")]
        [MinLength(2, ErrorMessage = "{0} Cannot Be Less Than {1} Characters.")]

        public string Text { get; set; }

        [DisplayName("Is Active?")]
        [Required(ErrorMessage = "{0} Cannot Be Empty")]

        public bool IsActive { get; set; }

        [Required(ErrorMessage = "{0} Cannot Be Empty")]

        public int ArticleId { get; set; }
    }
}


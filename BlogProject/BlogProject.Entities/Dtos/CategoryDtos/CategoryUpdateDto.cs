using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BlogProject.Entities.Dtos.CategoryDtos
{
    public class CategoryUpdateDto
    {
        [Required]

        public int Id { get; set; }

        [DisplayName("The Category Name")]
        [Required(ErrorMessage = "{0} Cannot Be Empty")]
        [MaxLength(70, ErrorMessage = "{0} Cannot Be More Than {1} Characters.")]
        [MinLength(3, ErrorMessage = "{0} Cannot Be Less Than {1} Characters.")]

        public string Name { get; set; }

        [DisplayName("Description")]
        [MaxLength(500, ErrorMessage = "{0} Cannot Be More Than {1} Characters.")]
        [MinLength(3, ErrorMessage = "{0} Cannot Be Less Than {1} Characters.")]

        public string Description { get; set; }

        [DisplayName("Category Special Note Field")]
        [MaxLength(500, ErrorMessage = "{0} Cannot Be More Than {1} Characters.")]
        [MinLength(3, ErrorMessage = "{0} Cannot Be Less Than {1} Characters.")]

        public string Note { get; set; }

        [DisplayName("Is It Active?")]
        [Required(ErrorMessage = "{0} Cannot Be Empty")]

        public bool IsActive { get; set; }

        [DisplayName("Has It Been Deleted?")]
        [Required(ErrorMessage = "{0} Cannot Be Empty")]

        public bool IsDeleted { get; set; }
    }
}

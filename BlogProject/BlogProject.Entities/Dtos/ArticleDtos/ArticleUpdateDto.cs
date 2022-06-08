using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using BlogProject.Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace BlogProject.Entities.Dtos.ArticleDtos
{
    public class ArticleUpdateDto
    {
        [Required]
        public int Id { get; set; }

        [DisplayName("Title")]
        [Required(ErrorMessage = "{0} Cannot Be Empty")]
        [MaxLength(100, ErrorMessage = "{0} Cannot Be More Than {1} Characters.")]
        [MinLength(5, ErrorMessage = "{0} Cannot Be Less Than {1} Characters.")]

        public string Title { get; set; }

        [DisplayName("Content")]
        [Required(ErrorMessage = "{0} Cannot Be Empty")]
        [MaxLength(1000, ErrorMessage = "{0} Cannot Be More Than {1} Characters.")]
        [MinLength(20, ErrorMessage = "{0} Cannot Be Less Than {1} Characters.")]

        public string Content { get; set; }

        [DisplayName("Thumbnail")]

        public string Thumbnail { get; set; }

        [DisplayName("Add Thumbnail")]

        public IFormFile ThumbnailFile { get; set; }

        [DisplayName("Date")]
        [Required(ErrorMessage = "{0} Cannot Be Empty")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]

        public DateTime Date { get; set; }

        [DisplayName("Seo Writer")]
        [Required(ErrorMessage = "{0} Cannot Be Empty")]
        [MaxLength(50, ErrorMessage = "{0} Cannot Be More Than {1} Characters.")]
        [MinLength(0, ErrorMessage = "{0} Cannot Be Less Than {1} Characters.")]

        public string SeoAuthor { get; set; }

        [DisplayName("Seo Description")]
        [Required(ErrorMessage = "{0} Cannot Be Empty")]
        [MaxLength(150, ErrorMessage = "{0} Cannot Be More Than {1} Characters.")]
        [MinLength(0, ErrorMessage = "{0} Cannot Be Less Than {1} Characters.")]

        public string SeoDescription { get; set; }

        [DisplayName("Seo Tags")]
        [Required(ErrorMessage = "{0} Cannot Be Empty")]
        [MaxLength(70, ErrorMessage = "{0} Cannot Be More Than {1} Characters.")]
        [MinLength(5, ErrorMessage = "{0} Cannot Be Less Than {1} Characters.")]

        public string SeoTags { get; set; }

        [DisplayName("Category")]
        [Required(ErrorMessage = "{0} Cannot Be Empty")]

        public int CategoryId { get; set; }

        [DisplayName("Is It Active?")]
        [Required(ErrorMessage = "{0} Cannot Be Empty")]

        public bool IsActive { get; set; }

        [Required]

        public int UserId { get; set; }
    }
}

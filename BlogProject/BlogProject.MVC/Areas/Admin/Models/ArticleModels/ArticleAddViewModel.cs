using System;
using BlogProject.Entities.Dtos.ArticleDtos;
using BlogProject.Entities.Dtos.CategoryDtos;

namespace BlogProject.MVC.Areas.Admin.Models.ArticleModels
{
    public class ArticleAddViewModel
    {
        public ArticleAddDto ArticleAddDto { get; set; }

        public CategoryListDto CategoryListDto { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using BlogProject.Entities.Concrete;
using BlogProject.Entities.Dtos.ArticleDtos;
using BlogProject.Entities.Dtos.CategoryDtos;
using Microsoft.AspNetCore.Http;

namespace BlogProject.MVC.Areas.Admin.Models.ArticleModels
{
    public class ArticleUpdateViewModel
    {
        public ArticleUpdateDto ArticleUpdateDto { get; set; }

        public CategoryListDto CategoryListDto { get; set; }
    }
}

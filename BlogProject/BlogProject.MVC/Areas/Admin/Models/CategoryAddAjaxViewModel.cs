using System;
using BlogProject.Entities.Dtos.CategoryDtos;

namespace BlogProject.MVC.Areas.Admin.Models
{
    public class CategoryAddAjaxViewModel
    {
        public CategoryAddDto CategoryAddDto { get; set; }

        public string CategoryAddPartial { get; set; }

        public CategoryDto CategoryDto { get; set; }
    }
}
    
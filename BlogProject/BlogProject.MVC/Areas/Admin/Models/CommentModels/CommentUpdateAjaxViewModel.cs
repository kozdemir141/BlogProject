using System;
using BlogProject.Entities.Dtos.CommentDtos;

namespace BlogProject.MVC.Areas.Admin.Models.CommentModels
{
    public class CommentUpdateAjaxViewModel
    {
        public CommentUpdateDto CommentUpdateDto { get; set; }
        public string CommentUpdatePartial { get; set; }
        public CommentDto CommentDto { get; set; }
    }
}


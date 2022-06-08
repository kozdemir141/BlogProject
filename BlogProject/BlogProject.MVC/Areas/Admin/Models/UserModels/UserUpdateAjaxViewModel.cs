using System;
using BlogProject.Entities.Dtos.UserDtos;

namespace BlogProject.MVC.Areas.Admin.Models.UserModels
{
    public class UserUpdateAjaxViewModel
    {
        public UserUpdateDto UserUpdateDto { get; set; }

        public string UserUpdatePartial { get; set; }

        public UserDto UserDto { get; set; }
    }
}

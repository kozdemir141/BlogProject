using System;
using BlogProject.Entities.Dtos.UserDtos;

namespace BlogProject.MVC.Areas.Admin.Models.UserModels
{
    public class UserAddAjaxViewModel
    {
        public UserAddDto UserAddDto { get; set; }

        public string UserAddPartial { get; set; }

        public UserDto UserDto { get; set; }
    }
}

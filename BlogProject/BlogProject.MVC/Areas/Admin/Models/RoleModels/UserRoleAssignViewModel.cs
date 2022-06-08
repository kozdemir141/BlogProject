using System;
using BlogProject.Entities.Dtos.RoleDtos;
using BlogProject.Entities.Dtos.UserDtos;

namespace BlogProject.MVC.Areas.Admin.Models.RoleModels
{
    public class UserRoleAssignViewModel
    {
        public UserRoleAssignDto UserRoleAssignDto { get; set; }

        public string RoleAssignPartial { get; set; }

        public UserDto UserDto { get; set; }
    }
}


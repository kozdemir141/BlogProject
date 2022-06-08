using System;
using System.Collections;
using System.Collections.Generic;
using BlogProject.Entities.Concrete;

namespace BlogProject.MVC.Areas.Admin.Models.UserModels
{
    public class UserWithRolesViewModel
    {
        public User User { get; set; }

        public IList<string> Roles { get; set; }
    }
}
    
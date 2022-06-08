using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogProject.Entities.Concrete;
using BlogProject.MVC.Helpers.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.MVC.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        public BaseController(UserManager<User> userManager, IImageHelper ımageHelper)
        {
            UserManager = userManager;
            ImageHelper = ımageHelper;
        }

        protected UserManager<User> UserManager { get; }

        protected IImageHelper ImageHelper { get; }

        protected User LoggedInUser => UserManager.GetUserAsync(HttpContext.User).Result;
    }
}

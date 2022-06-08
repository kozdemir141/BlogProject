using System;
using System.Collections.Generic;
using BlogProject.Entities.Concrete;
using BlogProject.Shared.Entities.Abstract;

namespace BlogProject.Entities.Dtos.UserDtos
{
    public class UserListDto : DtoGetBase
    {
        public IList<User> Users { get; set; }
    }
}
using System;
using BlogProject.Entities.Concrete;
using BlogProject.Shared.Entities.Abstract;

namespace BlogProject.Entities.Dtos.UserDtos
{
    public class UserDto:DtoGetBase
    {
        public User User { get; set; }
    }
}

using System;
using AutoMapper;
using BlogProject.Entities.Concrete;
using BlogProject.Entities.Dtos.UserDtos;

namespace BlogProject.MVC.AutoMapper.Profiles
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<UserAddDto, User>();
            CreateMap<User, UserUpdateDto>();
            CreateMap<UserUpdateDto, User>();
        }
    }
}

﻿using System;
using AutoMapper;
using BlogProject.Entities.Concrete;
using BlogProject.Entities.Dtos.CategoryDtos;

namespace BlogProject.Services.AutoMapper.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryAddDto, Category>().ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(x => DateTime.Now));

            CreateMap<CategoryUpdateDto, Category>().ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(x => DateTime.Now));

            CreateMap<Category, CategoryUpdateDto>();
        }
    }
}

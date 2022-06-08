﻿using System;
using AutoMapper;
using BlogProject.Entities.Concrete;
using BlogProject.Entities.Dtos.ArticleDtos;

namespace BlogProject.Services.AutoMapper.Profiles
{
    public class ArticleProfile : Profile
    {
        public ArticleProfile()
        {
            CreateMap<ArticleAddDto, Article>().ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(x => DateTime.Now));

            CreateMap<ArticleUpdateDto, Article>().ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(x => DateTime.Now));

            CreateMap<Article, ArticleUpdateDto>();
        }
    }
}

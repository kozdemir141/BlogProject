using System;
using BlogProject.Entities.Concrete;
using BlogProject.Shared.Entities.Abstract;

namespace BlogProject.Entities.Dtos.ArticleDtos
{
    public class ArticleDto:DtoGetBase
    {
        public Article Article { get; set; }
    }
}

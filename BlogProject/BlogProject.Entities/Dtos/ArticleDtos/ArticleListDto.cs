using System;
using System.Collections.Generic;
using BlogProject.Entities.Concrete;
using BlogProject.Shared.Entities.Abstract;

namespace BlogProject.Entities.Dtos.ArticleDtos
{
    public class ArticleListDto:DtoGetBase
    {
        public IList<Article> Articles { get; set; }
    }
}

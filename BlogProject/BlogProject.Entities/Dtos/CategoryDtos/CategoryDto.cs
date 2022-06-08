using System;
using BlogProject.Entities.Concrete;
using BlogProject.Shared.Entities.Abstract;

namespace BlogProject.Entities.Dtos.CategoryDtos
{
    public class CategoryDto : DtoGetBase
    {
        public Category Category { get; set; }
    }
}

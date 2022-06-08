using System;
using System.Collections.Generic;
using BlogProject.Shared.Entities.Abstract;

namespace BlogProject.Entities.Concrete
{
    public class Category:EntityBase,IEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<Article> Articles { get; set; }
    }
}

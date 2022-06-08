using System;
using System.Collections.Generic;
using BlogProject.Entities.Concrete;

namespace BlogProject.Entities.Dtos.CommentDtos
{
	public class CommentListDto
	{
        public IList<Comment> Comments { get; set; }
    }
}


using System;
using System.Collections.Generic;
using BlogProject.Entities.Concrete;

namespace BlogProject.Entities.Dtos.RoleDtos
{
	public class RoleListDto
	{
        public IList<Role> Roles { get; set; }
    }
}


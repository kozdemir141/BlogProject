using System;
using System.Collections.Generic;

namespace BlogProject.Entities.Dtos.RoleDtos
{
	public class UserRoleAssignDto
	{
        public UserRoleAssignDto()
        {
            RoleAssignDtos = new List<RoleAssignDto>();
        }
        public int UserId { get; set; }

        public string Username { get; set; }

        public IList<RoleAssignDto> RoleAssignDtos { get; set; }
    }
}


using System.Collections.Generic;
using MediHub.Touchee.Roles.Dto;
using MediHub.Touchee.Users.Dto;

namespace MediHub.Touchee.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<UserDto> Users { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}

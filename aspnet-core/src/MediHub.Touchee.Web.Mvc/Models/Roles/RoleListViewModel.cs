using System.Collections.Generic;
using MediHub.Touchee.Roles.Dto;

namespace MediHub.Touchee.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<RoleListDto> Roles { get; set; }

        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}

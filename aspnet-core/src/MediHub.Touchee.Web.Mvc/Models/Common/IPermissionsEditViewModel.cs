using System.Collections.Generic;
using MediHub.Touchee.Roles.Dto;

namespace MediHub.Touchee.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}
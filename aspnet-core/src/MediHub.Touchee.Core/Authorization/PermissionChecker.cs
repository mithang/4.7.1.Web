using Abp.Authorization;
using MediHub.Touchee.Authorization.Roles;
using MediHub.Touchee.Authorization.Users;

namespace MediHub.Touchee.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}

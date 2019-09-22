using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace MediHub.Touchee.Authorization
{
    public class ToucheeAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);

            //minhtv: 18-09-2019
            var categories = context.CreatePermission(PermissionNames.Pages_Categories, L("Categories"));

            // context.RemovePermission(PermissionNames.Pages_Categories_Add);
            //Tao permission level 2, co the tao nhieu level>2
            categories.CreateChildPermission(PermissionNames.Pages_Categories_Add,L("AddCategory"));
            categories.CreateChildPermission(PermissionNames.Pages_Categories_Delete,L("DeleteCategory"));
            categories.CreateChildPermission(PermissionNames.Pages_Categories_Edit,L("EditCategory"));
        

        

            //minhtv: 19-09-2019
            context.CreatePermission(PermissionNames.Pages_Products, L("Products"));

        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, ToucheeConsts.LocalizationSourceName);
        }
    }
}

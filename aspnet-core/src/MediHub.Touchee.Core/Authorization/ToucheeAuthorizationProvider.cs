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
            context.CreatePermission(PermissionNames.Pages_Categories, L("Categories"));
            context.CreatePermission(PermissionNames.Pages_Categories_Add, L("Add Category"));
            context.CreatePermission(PermissionNames.Pages_Categories_Delete, L("Delete Category"));
            context.CreatePermission(PermissionNames.Pages_Categories_Edit, L("Edit Category"));

            //minhtv: 19-09-2019
            context.CreatePermission(PermissionNames.Pages_Products, L("Products"));

        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, ToucheeConsts.LocalizationSourceName);
        }
    }
}

using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace MediHub.Touchee.Controllers
{
    public abstract class ToucheeControllerBase: AbpController
    {
        protected ToucheeControllerBase()
        {
            LocalizationSourceName = ToucheeConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}

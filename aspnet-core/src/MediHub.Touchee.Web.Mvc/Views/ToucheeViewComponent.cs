using Abp.AspNetCore.Mvc.ViewComponents;

namespace MediHub.Touchee.Web.Views
{
    public abstract class ToucheeViewComponent : AbpViewComponent
    {
        protected ToucheeViewComponent()
        {
            LocalizationSourceName = ToucheeConsts.LocalizationSourceName;
        }
    }
}

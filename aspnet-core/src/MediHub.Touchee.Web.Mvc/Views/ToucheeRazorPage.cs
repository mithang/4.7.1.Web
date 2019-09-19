using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;

namespace MediHub.Touchee.Web.Views
{
    public abstract class ToucheeRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected ToucheeRazorPage()
        {
            LocalizationSourceName = ToucheeConsts.LocalizationSourceName;
        }
    }
}

using Abp.AutoMapper;
using MediHub.Touchee.Sessions.Dto;

namespace MediHub.Touchee.Web.Views.Shared.Components.TenantChange
{
    [AutoMapFrom(typeof(GetCurrentLoginInformationsOutput))]
    public class TenantChangeViewModel
    {
        public TenantLoginInfoDto Tenant { get; set; }
    }
}

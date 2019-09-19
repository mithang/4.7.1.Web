using Abp.MultiTenancy;
using MediHub.Touchee.Authorization.Users;

namespace MediHub.Touchee.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}

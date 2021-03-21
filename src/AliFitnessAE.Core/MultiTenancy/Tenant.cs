using Abp.MultiTenancy;
using AliFitnessAE.Authorization.Users;

namespace AliFitnessAE.MultiTenancy
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

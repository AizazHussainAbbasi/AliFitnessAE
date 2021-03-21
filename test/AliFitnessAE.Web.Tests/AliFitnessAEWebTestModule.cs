using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AliFitnessAE.EntityFrameworkCore;
using AliFitnessAE.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace AliFitnessAE.Web.Tests
{
    [DependsOn(
        typeof(AliFitnessAEWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class AliFitnessAEWebTestModule : AbpModule
    {
        public AliFitnessAEWebTestModule(AliFitnessAEEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AliFitnessAEWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(AliFitnessAEWebMvcModule).Assembly);
        }
    }
}
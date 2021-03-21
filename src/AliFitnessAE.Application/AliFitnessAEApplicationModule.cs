using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AliFitnessAE.Authorization;

namespace AliFitnessAE
{
    [DependsOn(
        typeof(AliFitnessAECoreModule), 
        typeof(AbpAutoMapperModule))]
    public class AliFitnessAEApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<AliFitnessAEAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(AliFitnessAEApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}

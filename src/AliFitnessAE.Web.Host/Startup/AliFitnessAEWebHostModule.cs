using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AliFitnessAE.Configuration;

namespace AliFitnessAE.Web.Host.Startup
{
    [DependsOn(
       typeof(AliFitnessAEWebCoreModule))]
    public class AliFitnessAEWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public AliFitnessAEWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AliFitnessAEWebHostModule).GetAssembly());
        }
    }
}

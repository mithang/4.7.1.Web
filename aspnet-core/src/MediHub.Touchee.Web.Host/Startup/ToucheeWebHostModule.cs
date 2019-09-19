using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MediHub.Touchee.Configuration;

namespace MediHub.Touchee.Web.Host.Startup
{
    [DependsOn(
       typeof(ToucheeWebCoreModule))]
    public class ToucheeWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public ToucheeWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ToucheeWebHostModule).GetAssembly());
        }
    }
}

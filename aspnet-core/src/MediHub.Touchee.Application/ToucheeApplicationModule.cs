using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MediHub.Touchee.Authorization;

namespace MediHub.Touchee
{
    [DependsOn(
        typeof(ToucheeCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class ToucheeApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<ToucheeAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(ToucheeApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );
        }
    }
}

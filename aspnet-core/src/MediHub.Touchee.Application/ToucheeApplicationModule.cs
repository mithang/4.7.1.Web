using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MediHub.Touchee.Authorization;
using MediHub.Touchee.Products;
using MediHub.Touchee.Products.Dto;

namespace MediHub.Touchee
{
    [DependsOn(
        typeof(ToucheeCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class ToucheeApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Modules.AbpAutoMapper().Configurators.Add(config =>
            {
                config.CreateMap<CreateProductDto, Product>()
                        .ForMember(u => u.Name, options => options.MapFrom(input => input.Name))
                      .ForMember(u => u.Quantity, options => options.MapFrom(input => input.Quantity));
            });
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

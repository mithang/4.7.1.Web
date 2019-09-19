using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Runtime.Caching.Redis;
using MediHub.Touchee.Authorization;
using MediHub.Touchee.Configuration;
using MediHub.Touchee.Products;
using MediHub.Touchee.Products.Dto;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace MediHub.Touchee
{
    [DependsOn(
        typeof(ToucheeCoreModule),
        typeof(AbpRedisCacheModule),
        typeof(AbpAutoMapperModule)
        )]
    public class ToucheeApplicationModule : AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public ToucheeApplicationModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = AppConfigurations.Get(env.ContentRootPath, env.EnvironmentName, env.IsDevelopment());
        }

        public override void PreInitialize()
        {
            Configuration.Modules.AbpAutoMapper().Configurators.Add(config =>
            {
                config.CreateMap<CreateProductDto, Product>()
                        .ForMember(u => u.Name, options => options.MapFrom(input => input.Name))
                      .ForMember(u => u.Quantity, options => options.MapFrom(input => input.Quantity));
            });

            
            Configuration.Caching.UseRedis(options =>
            {
                options.ConnectionString = _appConfiguration["RedisCache:ConnectionString"];
                options.DatabaseId = _appConfiguration.GetValue<int>("RedisCache:DatabaseId");
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

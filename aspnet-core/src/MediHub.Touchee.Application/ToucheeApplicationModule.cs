using System;
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
            //Cau hinh dung automapper thay the cho objectmapper, phai co AbpAutoMapperModule
            Configuration.Modules.AbpAutoMapper().Configurators.Add(config =>
            {
                config.CreateMap<CreateProductDto, Product>()
                        .ForMember(u => u.Name, options => options.MapFrom(input => input.Name))
                      .ForMember(u => u.Assignment, options => options.MapFrom(input => input.Assignment)
                        );

                config.CreateMap<ProductDto, Product>()
        .ForMember(u => u.Name, options => options.MapFrom(input => input.Name))
      .ForMember(u => u.Assignment, options => options.MapFrom(input => input.Assignment));


            });

            
            Configuration.Caching.UseRedis(options =>
            {
                options.ConnectionString = _appConfiguration["RedisCache:ConnectionString"];
                options.DatabaseId = _appConfiguration.GetValue<int>("RedisCache:DatabaseId");
            });

            //Configuration for all caches
            Configuration.Caching.ConfigureAll(cache =>
            {
                cache.DefaultSlidingExpireTime = TimeSpan.FromSeconds(2);
            });

            //Configuration for a specific cache
            Configuration.Caching.Configure("MyCache", cache =>
            {
                cache.DefaultSlidingExpireTime = TimeSpan.FromSeconds(2);
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

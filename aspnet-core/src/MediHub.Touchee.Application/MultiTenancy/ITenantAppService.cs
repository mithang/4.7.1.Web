using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MediHub.Touchee.MultiTenancy.Dto;

namespace MediHub.Touchee.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}


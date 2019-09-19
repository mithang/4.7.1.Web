using System.Threading.Tasks;
using Abp.Application.Services;
using MediHub.Touchee.Authorization.Accounts.Dto;

namespace MediHub.Touchee.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}

using System.Threading.Tasks;
using Abp.Application.Services;
using MediHub.Touchee.Sessions.Dto;

namespace MediHub.Touchee.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}

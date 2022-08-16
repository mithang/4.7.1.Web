using System.Threading.Tasks;
using Abp.Application.Services;
using MediHub.Touchee.Sessions.Dto;

namespace MediHub.Touchee.Categories
{
    public interface ICategoryAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}

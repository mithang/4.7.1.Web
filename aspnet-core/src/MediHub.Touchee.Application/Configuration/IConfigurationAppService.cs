using System.Threading.Tasks;
using MediHub.Touchee.Configuration.Dto;

namespace MediHub.Touchee.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}

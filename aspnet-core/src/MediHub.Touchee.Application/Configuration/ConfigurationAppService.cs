using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using MediHub.Touchee.Configuration.Dto;

namespace MediHub.Touchee.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : ToucheeAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}

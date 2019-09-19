using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Auditing;
using Abp.Authorization;
using MediHub.Touchee.Authorization;
using MediHub.Touchee.Sessions.Dto;

namespace MediHub.Touchee.Categories
{
    //[AbpAuthorize(PermissionNames.Pages_Categories)]
    public class CategoryAppService : ToucheeAppServiceBase, ICategoryAppService
    {
        [AbpAuthorize(PermissionNames.Pages_Categories_Add)]
        public string Add()
        {
            return "add";
        }

        public string Edit()
        {
            return "edit";
        }

        public string Delete()
        {
            return "delete";
        }

        [DisableAuditing]
        public async Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations()
        {
            var output = new GetCurrentLoginInformationsOutput
            {
                Application = new ApplicationInfoDto
                {
                    Version = AppVersionHelper.Version,
                    ReleaseDate = AppVersionHelper.ReleaseDate,
                    Features = new Dictionary<string, bool>()
                }
            };

            if (AbpSession.TenantId.HasValue)
            {
                output.Tenant = ObjectMapper.Map<TenantLoginInfoDto>(await GetCurrentTenantAsync());
            }

            if (AbpSession.UserId.HasValue)
            {
                output.User = ObjectMapper.Map<UserLoginInfoDto>(await GetCurrentUserAsync());
            }

            return output;
        }
    }
}

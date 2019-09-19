using Abp.AutoMapper;
using MediHub.Touchee.Authentication.External;

namespace MediHub.Touchee.Models.TokenAuth
{
    [AutoMapFrom(typeof(ExternalLoginProviderInfo))]
    public class ExternalLoginProviderInfoModel
    {
        public string Name { get; set; }

        public string ClientId { get; set; }
    }
}

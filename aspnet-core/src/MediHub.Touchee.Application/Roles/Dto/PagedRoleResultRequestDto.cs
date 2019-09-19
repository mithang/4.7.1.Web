using Abp.Application.Services.Dto;

namespace MediHub.Touchee.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}


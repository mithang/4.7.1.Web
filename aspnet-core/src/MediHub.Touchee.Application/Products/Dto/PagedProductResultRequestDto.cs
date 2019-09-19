using Abp.Application.Services.Dto;

namespace MediHub.Touchee.Products.Dto
{
    public class PagedProductResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}


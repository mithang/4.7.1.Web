using System;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace MediHub.Touchee.Products.Dto
{
    [AutoMapTo(typeof(Product))]
    public class ProductDto:EntityDto<int>
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}

using System;
using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using MediHub.Touchee.Authorization;

namespace MediHub.Touchee.Products
{
    [AbpAuthorize(PermissionNames.Pages_Products)]
    public class ProductsAppService:CrudAppService<Product,ProductDto>
    {
       
        public ProductsAppService(IRepository<Product, int> repository) : base(repository)
        {
        }
    }
}

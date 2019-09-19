using System;
using Abp.Application.Services;
using Abp.Domain.Repositories;

namespace MediHub.Touchee.Products
{
    public class ProductsAppService:CrudAppService<Product,ProductDto>
    {
       
        public ProductsAppService(IRepository<Product, int> repository) : base(repository)
        {
        }
    }
}

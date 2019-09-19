using System;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.ObjectMapping;
using MediHub.Touchee.Authorization;
using MediHub.Touchee.Products.Dto;

namespace MediHub.Touchee.Products
{
    //[AbpAuthorize(PermissionNames.Pages_Products)]
    //public class ProductsAppService : AsyncCrudAppService<Product, ProductDto, int, PagedAndSortedResultRequestDto,CreateProductDto, ProductDto>
    //{

    //    public ProductsAppService(IRepository<Product, int> repository) : base(repository)
    //    {
    //    }
    //}
    [AbpAuthorize(PermissionNames.Pages_Products)]
    public class ProductsAppService : ApplicationService
    {

        // private readonly IRepository<Product> _productRepository;

        // public ProductsAppService(IRepository<Product> productRepository)
        // {
        //     _productRepository = productRepository;
        // }

        // public void CreateUser(CreateProductDto input)
        // {
        //     var product = new Product
        //     {
        //         Name = input.Name,
        //         Quantity = input.Quantity
        //     };

        //     _productRepository.Insert(product);
        // }

        private readonly IRepository<Product> _userRepository;
        private readonly IObjectMapper _objectMapper;

        public ProductsAppService(IRepository<Product> userRepository, IObjectMapper objectMapper)
        {
            _userRepository = userRepository;
            _objectMapper = objectMapper;
        }

        public void CreateProduct(CreateProductDto input)
        {
            var user = _objectMapper.Map<Product>(input);
            _userRepository.Insert(user);
        }

        public void UpdateProduct(ProductDto input)
        {
            var user = _userRepository.Get(input.Id);
            _objectMapper.Map(input, user);
        }
    }
}

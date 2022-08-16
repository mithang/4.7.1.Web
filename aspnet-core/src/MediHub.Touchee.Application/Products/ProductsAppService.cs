using System;
using System.Collections.Generic;
using System.Drawing;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.ObjectMapping;
using LazZiya.ImageResize;
using MediHub.Touchee.Authorization;
using MediHub.Touchee.Products.Dto;
using Microsoft.AspNetCore.Hosting;

namespace MediHub.Touchee.Products
{
    //[AbpAuthorize(PermissionNames.Pages_Products)]
    //public class ProductsAppService : AsyncCrudAppService<Product, ProductDto, int, PagedAndSortedResultRequestDto,CreateProductDto, ProductDto>
    //{

    //    public ProductsAppService(IRepository<Product, int> repository) : base(repository)
    //    {
    //    }
    //}
//    [AbpAuthorize(PermissionNames.Pages_Products)]
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

        private readonly IRepository<Product> _productRepository;
        private readonly IObjectMapper _objectMapper;
        private readonly IHostingEnvironment _env;

        public ProductsAppService(IHostingEnvironment env,IRepository<Product> productRepository, IObjectMapper objectMapper)
        {
            _productRepository = productRepository;
            _objectMapper = objectMapper;
            _env = env;
        }

        public ListResultDto<ProductDto> GetAllProduct()
        {
            var products = _productRepository.GetAllList();
            var productdtos = ObjectMapper.Map<List<ProductDto>>(products);
            return new ListResultDto<ProductDto>(productdtos);
            
        }
        public ProductDto GetProduct(EntityDto<int> input)
        {
             var product = _productRepository.Get(input.Id);
             var productDto = _objectMapper.Map<ProductDto>(product);
             return productDto;
        }
        public void CreateProduct(CreateProductDto input)
        {
            var user = _objectMapper.Map<Product>(input);
            _productRepository.Insert(user);
        }

        public void UpdateProduct(ProductDto input)
        {
            var user = _productRepository.Get(input.Id);
            _objectMapper.Map(input, user);
        }
        
        public void DeleteProduct(EntityDto<int> input)
        {
            _productRepository.Delete(input.Id);
            
        }

        public void ScareImage()
        {
            
            //get image from local path
            //var img = Image.FromFile(@"wwwroot\images\img.jpg");
            var stream = _env.WebRootFileProvider.GetFileInfo("images/img.jpg").CreateReadStream();
            var img = Image.FromStream(stream);
            
            //resize the image to 600x400 
            var newImg = ImageResize.Scale(img, 600, 400);
            
            //save new image
            newImg.SaveAs(_env.ContentRootPath+"\\wwwroot\\images\\600x400-scale.jpg");

            //dispose to free up memory
            img.Dispose();
            newImg.Dispose();
        }
    }
}

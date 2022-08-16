using System;
using Abp.AspNetCore.Mvc.Authorization;
using Abp.AspNetCore.Mvc.Controllers;
using MediHub.Touchee.Authorization;
using MediHub.Touchee.Products;
using MediHub.Touchee.Products.Dto;
using Microsoft.AspNetCore.Mvc;

namespace MediHub.Touchee.Web.Controllers
{
    
    public class ProductsController: AbpController
    {
        ProductsAppService productsAppService;
        public ProductsController(ProductsAppService _productsAppService)
        {
            productsAppService = _productsAppService;

        }
        public ActionResult Index()
        {
            var model = productsAppService.GetAllProduct();
            return View(model);
        }
        [AbpMvcAuthorize(PermissionNames.Pages_Roles)]
        public ActionResult CreateProduct()
        {
            return View();
        }
    }
}

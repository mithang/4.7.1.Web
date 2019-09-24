using System;
using Abp.AspNetCore.Mvc.Authorization;
using Abp.AspNetCore.Mvc.Controllers;
using MediHub.Touchee.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MediHub.Touchee.Web.Controllers
{
    
    public class ProductsController: AbpController
    {
        public ActionResult Index()
        {
            return View();
        }
        [AbpMvcAuthorize(PermissionNames.Pages_Roles)]
        public ActionResult CreateProduct()
        {
            return View();
        }
    }
}

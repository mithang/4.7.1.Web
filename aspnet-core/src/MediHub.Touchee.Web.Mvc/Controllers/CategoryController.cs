using System;
using System.Threading.Tasks;
using MediHub.Touchee.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace MediHub.Touchee.Web.Controllers
{
    public class CategoryController: ToucheeControllerBase
	{
        public CategoryController()
        {
        }
        public IActionResult Index()
        {

            return View("1");
        }
    }
}

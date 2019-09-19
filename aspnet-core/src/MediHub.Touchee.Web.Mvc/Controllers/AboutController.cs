using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using MediHub.Touchee.Controllers;

namespace MediHub.Touchee.Web.Controllers
{
    [AbpMvcAuthorize]
    public class AboutController : ToucheeControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}

using Microsoft.AspNetCore.Antiforgery;
using MediHub.Touchee.Controllers;

namespace MediHub.Touchee.Web.Host.Controllers
{
    public class AntiForgeryController : ToucheeControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}

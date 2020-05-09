using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Web.Controllers
{
    public class HomeController : Controller
    {
        [FilterContext.Log]
        public IActionResult Index()
        {
            return View();
        }
    }
}
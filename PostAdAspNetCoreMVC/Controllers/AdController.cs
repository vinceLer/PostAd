using Microsoft.AspNetCore.Mvc;

namespace PostAdAspNetCoreMVC.Controllers
{
    public class AdController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

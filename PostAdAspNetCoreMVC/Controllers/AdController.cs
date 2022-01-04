using Microsoft.AspNetCore.Mvc;
using PostAdAspNetCoreMVC.Interfaces;
using PostAdAspNetCoreMVC.Models;
using System.Collections.Generic;

namespace PostAdAspNetCoreMVC.Controllers
{
    public class AdController : Controller
    {
        IRepository<Ad> _adRepository;
        public AdController(IRepository<Ad> adRepository)
        {
            _adRepository = adRepository;
        }
        public IActionResult Index()
        {
            List<Ad> adsList = _adRepository.GetAll();

            return View("Index", adsList);
        }
    }
}

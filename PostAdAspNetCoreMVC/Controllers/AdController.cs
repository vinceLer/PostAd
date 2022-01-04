using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostAdAspNetCoreMVC.Interfaces;
using PostAdAspNetCoreMVC.Models;
using PostAdAspNetCoreMVC.Services;
using System.Collections.Generic;

namespace PostAdAspNetCoreMVC.Controllers
{
    public class AdController : Controller
    {
        IRepository<Ad> _adRepository;
        UploadService _uploadService;
        public AdController(IRepository<Ad> adRepository, UploadService uploadService)
        {
            _adRepository = adRepository;
            _uploadService = uploadService; 
        }
        public IActionResult Index()
        {
            List<Ad> adsList = _adRepository.GetAll();

            return View("Index", adsList);
        }
        public IActionResult Form()
        {
            return View();
        }
        public IActionResult SubmitForm(Ad ad, IFormFile image)
        {
            ad.Images.Add(new Image() { Url = _uploadService.Upload(image) });
            _adRepository.Save(ad);
            return RedirectToAction("Index");
        }
        public IActionResult Detail(int id)
        {
            Ad ad = _adRepository.Get(id);
            return View(ad);
        }
    }
}

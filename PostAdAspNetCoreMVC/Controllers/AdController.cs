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
            List<Ad> ads = _adRepository.GetAll();

            return View("Index", ads);
        }
        public IActionResult SubmitSearch(string search)
        {
            List<Ad> ads = _adRepository.GetAll();
            if (search != null)
            {
                ads = _adRepository.Search(a => a.Title.Contains(search) || a.Description.Contains(search));
            }
            return View("Index", ads);
        }
        public IActionResult Form()
        {
            return View();
        }

        public IActionResult SubmitForm(Ad ad, IFormFile[] images)
        {
            foreach (IFormFile image in images)
            {
                ad.Images.Add(new Image() { Url = _uploadService.Upload(image) });
            }
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

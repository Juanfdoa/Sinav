using Microsoft.AspNetCore.Mvc;
using Sinav.DataAcess.Data.Repository.IRepository;
using Sinav.Models;
using Sinav.Models.ViewModels;
using System.Diagnostics;

namespace Sinav.Areas.Client.Controllers
{
    [Area("Client")]
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            HomeVM homeVM = new()
            {
                sliders = _unitOfWork.Slider.GetAll(x => x.Active),
                News = _unitOfWork.News.GetAll(x => x.Active && x.Status)
            };

            ViewBag.IsHome = true;

            return View(homeVM);
        }

        public IActionResult Details(int id)
        {
            var newDb = _unitOfWork.News.Get(id);
            return View(newDb);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Sinav.DataAcess.Data.Repository.IRepository;
using Sinav.Models.Entities;

namespace Sinav.Areas.Client.Controllers
{
    [Area("Client")]
    public class PQRSController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public PQRSController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Success()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PQRS pqrs)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.PQRS.Add(pqrs);
                _unitOfWork.Save();
                return RedirectToAction(nameof(Success));
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }

            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;
using Sinav.Data;
using Sinav.DataAcess.Data.Repository.IRepository;
using Sinav.Models.Entities;
using Sinav.Models.ViewModels;
using System.Data.Entity;

namespace Sinav.Areas.Client.Controllers
{
    [Area("Client")]
    public class SearchController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ApplicationDbContext _context;

        public SearchController(IUnitOfWork unitOfWork, ApplicationDbContext context)
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Details(string DocumentNumber, UserVM userVM)
        {
            if (DocumentNumber == null)
            {
                return RedirectToAction(nameof(Error));
            }

            userVM.User = _unitOfWork.User.GetUserByDocument(DocumentNumber);
            if (userVM.User == null)
            {
                return RedirectToAction(nameof(Error));
            }
            else
            {
                userVM.GetListVaccineUser = _unitOfWork.VaccineUser.GetListVaccineUser(userVM.User.Id);
            }

            return View(userVM);
        }

        [HttpGet]
        public IActionResult Error()
        {
            return View();
        }

        public IActionResult DownloadPdf(int? id, UserVM userVM)
        {
            if (id == null)
            {
                return NotFound();
            }

            userVM.User = _unitOfWork.User.Get(id.Value);
            if (userVM.User == null)
            {
                return RedirectToAction(nameof(Error));
            }
            else
            {
                userVM.GetListVaccineUser = _unitOfWork.VaccineUser.GetListVaccineUser(userVM.User.Id);
            }

            var fileName = $"Carnet-{userVM.User.Name + " " + userVM.User.Surname}.pdf";
            var encodedFileName = Uri.EscapeDataString(fileName);

            return new ViewAsPdf("DownloadPdf", userVM)
            {
                FileName = encodedFileName,
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Portrait,
                PageSize = Rotativa.AspNetCore.Options.Size.A4
            };
        }
    }
}

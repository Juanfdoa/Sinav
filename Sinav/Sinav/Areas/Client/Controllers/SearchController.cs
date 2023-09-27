using Microsoft.AspNetCore.Mvc;
using Sinav.DataAcess.Data.Repository.IRepository;
using Sinav.Models.Entities;
using Sinav.Models.ViewModels;

namespace Sinav.Areas.Client.Controllers
{
    [Area("Client")]
    public class SearchController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public SearchController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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
                return NotFound();
            }

            userVM.User = _unitOfWork.User.GetUserByDocument(DocumentNumber);
            if (userVM.User == null)
            {
                return RedirectToAction(nameof(Error));
            }
            else
            {
                userVM.GetListAllergyUser = _unitOfWork.AllergyUser.GetListAllergyUser(userVM.User.Id);
                userVM.GetListDiseaseUser = _unitOfWork.DiseaseUser.GetListDiseaseUser(userVM.User.Id);
                userVM.GetListVaccineUser = _unitOfWork.VaccineUser.GetListVaccineUser(userVM.User.Id);
            }

            return View(userVM);
        }

        [HttpGet]
        public IActionResult Error()
        {
            return View();
        }

    }
}

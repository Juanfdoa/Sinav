using Microsoft.AspNetCore.Mvc;
using Sinav.DataAcess.Data.Repository.IRepository;
using Sinav.Models.Entities;

namespace Sinav.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AllergyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AllergyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Allergy allergy)
        {
            if (ModelState.IsValid)
            {
                allergy.Active = true;
                allergy.CreatedAt = DateTime.UtcNow;
                allergy.UpdatedAt = DateTime.UtcNow;
                _unitOfWork.Allergy.Add(allergy);
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }

            return View(allergy);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            _ = new Allergy();
            Allergy allergy = _unitOfWork.Allergy.Get(id);
            if (allergy == null)
            {
                return NotFound();
            }

            return View(allergy);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Allergy allergy)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Allergy.Update(allergy);
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }

            return View(allergy);
        }


        #region Llamadas a la api
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _unitOfWork.Allergy.GetAll(x => x.Active) });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objDb = _unitOfWork.Allergy.Get(id);
            if (objDb == null)
            {
                return Json(new { success = false, message = "Error al eliminar la alergia" });
            }

            objDb.Active = false;
            _unitOfWork.Allergy.Remove(objDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "La alergia fue eliminada exitosamente" });

        }

        #endregion
    }
}

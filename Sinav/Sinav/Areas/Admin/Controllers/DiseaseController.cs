using Microsoft.AspNetCore.Mvc;
using Sinav.DataAcess.Data.Repository.IRepository;
using Sinav.Models.Entities;

namespace Sinav.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DiseaseController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public DiseaseController(IUnitOfWork unitOfWork)
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
        public IActionResult Create(Disease disease)
        {
            if (ModelState.IsValid)
            {
                disease.Active = true;
                disease.CreatedAt = DateTime.UtcNow;
                disease.UpdatedAt = DateTime.UtcNow;
                _unitOfWork.Disease.Add(disease);
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }

            return View(disease);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            _ = new Disease();
            Disease disease = _unitOfWork.Disease.Get(id);
            if (disease == null)
            {
                return NotFound();
            }

            return View(disease);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Disease disease)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Disease.Update(disease);
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }

            return View(disease);
        }


        #region Llamadas a la api
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _unitOfWork.Disease.GetAll(x => x.Active) });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objDb = _unitOfWork.Disease.Get(id);
            if (objDb == null)
            {
                return Json(new { success = false, message = "Error al eliminar la enfermedad" });
            }

            objDb.Active = false;
            _unitOfWork.Disease.Remove(objDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "La enfermedad fue eliminada exitosamente" });

        }

        #endregion
    }
}

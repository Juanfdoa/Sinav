using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sinav.DataAcess.Data.Repository.IRepository;
using Sinav.Models.Entities;
using Sinav.Models.ViewModels;

namespace Sinav.Areas.Admin.Controllers
{
    [Authorize(Roles = "SuperAdmin,Admin")]
    [Area("Admin")]
    public class VaccineController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public VaccineController(IUnitOfWork unitOfWork)
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
            VaccineVM vacineVM = new()
            {
                Vaccine = new Vaccine(),
                SupplierList = _unitOfWork.Supplier.GetListSuppliers(),
            };

            return View(vacineVM);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(VaccineVM vaccineVM)
        {
            try
            {
                vaccineVM.Vaccine.Active = true;
                vaccineVM.Vaccine.CreatedAt = DateTime.UtcNow;
                vaccineVM.Vaccine.UpdatedAt = DateTime.UtcNow;
                _unitOfWork.Vaccine.Add(vaccineVM.Vaccine);
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                throw new Exception("Hubo un error al crear la vacuna" + e);
            } 
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            VaccineVM vaccineVM = new()
            {
                Vaccine = new Vaccine(),
                SupplierList = _unitOfWork.Supplier.GetListSuppliers()
            };

            if(id != null)
            {
                vaccineVM.Vaccine = _unitOfWork.Vaccine.Get(id.GetValueOrDefault());
            }

            return View(vaccineVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(VaccineVM vaccineVM)
        {
            try
            {
                _unitOfWork.Vaccine.Update(vaccineVM.Vaccine);
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));  
            }
            catch (Exception)
            {
                throw new Exception("Hubo un error al actualizar la vacuna");
            }
        }



        #region Llamadas a la api
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _unitOfWork.Vaccine.GetAll(x => x.Active ,includeProperties: "Supplier") });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objDb = _unitOfWork.Vaccine.Get(id);
            if (objDb == null)
            {
                return Json(new { success = false, message = "Error al eliminar la vacuna" });
            }

            objDb.Active = false;
            _unitOfWork.Vaccine.Remove(objDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "La vacuna fue eliminada exitosamente" });

        }

        #endregion
    }
}

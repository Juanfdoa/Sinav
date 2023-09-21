using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Sinav.DataAcess.Data.Repository.IRepository;
using Sinav.Models.Entities;

namespace Sinav.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SupplierController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public SupplierController(IUnitOfWork unitOfWork)
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
        public IActionResult Create(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                supplier.Active = true;
                supplier.CreatedAt = DateTime.UtcNow;
                supplier.UpdatedAt = DateTime.UtcNow;
                _unitOfWork.Supplier.Add(supplier);
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }

            return View(supplier);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Supplier supplier = new();
            supplier = _unitOfWork.Supplier.Get(id);
            if (supplier == null)
            {
                return NotFound();
            }

            return View(supplier);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Supplier.Update(supplier);
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }

            return View(supplier);
        }




        #region Llamadas a la api
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _unitOfWork.Supplier.GetAll(x => x.Active) });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objDb = _unitOfWork.Supplier.Get(id);
            if (objDb == null)
            {
                return Json(new { success = false, message = "Error al eliminar el proveedor" });
            }

            objDb.Active = false;
            _unitOfWork.Supplier.Remove(objDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "El proveedor fue eliminado exitosamente" });

        }

        #endregion
    }
}

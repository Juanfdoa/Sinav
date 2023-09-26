using Microsoft.AspNetCore.Mvc;
using Sinav.DataAcess.Data.Repository.IRepository;
using System.Linq;

namespace Sinav.Areas.Admin.Controllers
{
    [Area("Admin")]
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
            var pqrs = _unitOfWork.PQRS.GetAll(x => x.Active, orderBy: o=>o.OrderByDescending(x => x.Id));
            return View(pqrs);
        }







        [HttpPost]
        public IActionResult MarkAsRead(int id)
        {
            var objDb = _unitOfWork.PQRS.Get(id);

            objDb.IsRead = true;
            _unitOfWork.PQRS.Remove(objDb);
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var objDb = _unitOfWork.PQRS.Get(id);

            objDb.Active = false;
            _unitOfWork.PQRS.Remove(objDb);
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));

        }
    }
}

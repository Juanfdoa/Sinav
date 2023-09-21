using Microsoft.AspNetCore.Mvc;
using Sinav.DataAcess.Data.Repository.IRepository;
using Sinav.Models.Entities;
using Sinav.Models.ViewModels;

namespace Sinav.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public UserController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }


        #region Acciones para TblUsuarios
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
        public IActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {   
                user.Active = true;
                user.CreatedAt = DateTime.Now;
                user.UpdatedAt = DateTime.Now;

                _unitOfWork.User.Add(user);
                _unitOfWork.Save();

                return RedirectToAction(nameof(Index)); 
            }
            return View(user);
        }
        

        [HttpGet]
        public IActionResult Edit(int id)
        {
            _ = new User();
            User user = _unitOfWork.User.Get(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.User.Update(user);
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }

            return View(user);
        }

        [HttpGet]
        public IActionResult Details(int? id, UserVM userVM)
        {
            if (id == null)
            {
                return NotFound();
            }

            userVM.User = _unitOfWork.User.Get(id.Value); ;
            userVM.GetListAllergyUser = _unitOfWork.AllergyUser.GetListAllergyUser(id.Value);
            userVM.GetListDiseaseUser = _unitOfWork.DiseaseUser.GetListDiseaseUser(id.Value);
            userVM.GetListVaccineUser = _unitOfWork.VaccineUser.GetListVaccineUser(id.Value);
            if (userVM.User == null)
            {
                return NotFound();
            }

            return View(userVM);
        }

        #endregion

        #region Llamadas a la api para usuarios
        [HttpGet]
        public IActionResult GetAll()
        {
            //opcion 1
            return Json(new { data = _unitOfWork.User.GetAll(x => x.Active) });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objDb = _unitOfWork.User.Get(id);
            if (objDb == null)
            {
                return Json(new { success = false, message = "Error al eliminar el usuario" });
            }

            objDb.Active = false;
            _unitOfWork.User.Remove(objDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "El usuario fue eliminada exitosamente" });

        }
        #endregion

        #region Acciones para TblAllergyUser

        [HttpGet]
        public IActionResult AddAllergy()
        {
            return View();
        }


        #endregion

        #region Acciones para TblDiseaseUser
        [HttpGet]
        public IActionResult AddDisease()
        {
            return View();
        }
        #endregion

        #region Acciones para TblVaccineUser
        [HttpGet]
        public IActionResult AddVaccine()
        {
            return View();
        }
        #endregion
    }
}

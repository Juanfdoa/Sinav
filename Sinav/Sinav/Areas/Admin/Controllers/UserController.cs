using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sinav.DataAcess.Data.Repository.IRepository;
using Sinav.Models.Entities;
using Sinav.Models.ViewModels;

namespace Sinav.Areas.Admin.Controllers
{
    [Authorize(Roles = "SuperAdmin,Admin")]
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
            userVM.GetListVaccines = _unitOfWork.Vaccine.GetListVaccines();
            userVM.GetListAllergies = _unitOfWork.Allergy.GetListAllergies();
            userVM.GetListDiseases = _unitOfWork.Disease.GetListDiseases();
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddAllergy(AllergyUser allergyUser)
        {
            if (allergyUser.AllergyId == 0)
            {
                return RedirectToAction("Details", "User", new { id = allergyUser.UserId });
            }
            else
            {
                if (allergyUser.Observations == null)
                {
                    allergyUser.Observations = "";
                }

                allergyUser.Active = true;
                allergyUser.CreatedAt = DateTime.Now;
                allergyUser.UpdatedAt = DateTime.Now;

                _unitOfWork.AllergyUser.Add(allergyUser);
                _unitOfWork.Save();
            }

            return RedirectToAction("Details", "User", new { id = allergyUser.UserId });

        }

        [HttpPost]
        public IActionResult RemoveAllergy(int id)
        {
            var objDb = _unitOfWork.AllergyUser.Get(id);
            var userId = objDb.UserId;

            objDb.Active = false;
            _unitOfWork.AllergyUser.Remove(objDb);
            _unitOfWork.Save();
            return RedirectToAction("Details", "User", new { id = userId });

        }

        #endregion

        #region Acciones para TblDiseaseUser
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddDisease(DiseaseUser diseaseUser)
        {
            if (diseaseUser.DiseaseId == 0)
            {
                return RedirectToAction("Details", "User", new { id = diseaseUser.UserId });
            }
            else
            {
                if (diseaseUser.Observations == null)
                {
                    diseaseUser.Observations = "";
                }

                diseaseUser.Active = true;
                diseaseUser.CreatedAt = DateTime.Now;
                diseaseUser.UpdatedAt = DateTime.Now;

                _unitOfWork.DiseaseUser.Add(diseaseUser);
                _unitOfWork.Save();
            }

            return RedirectToAction("Details", "User", new { id = diseaseUser.UserId });

        }

        [HttpPost]
        public IActionResult RemoveDisease(int id)
        {
            var objDb = _unitOfWork.DiseaseUser.Get(id);
            var userId = objDb.UserId;

            objDb.Active = false;
            _unitOfWork.DiseaseUser.Remove(objDb);
            _unitOfWork.Save();
            return RedirectToAction("Details", "User", new { id = userId });

        }
        #endregion

        #region Acciones para TblVaccineUser
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddVaccine(VaccineUser vaccineUser)
        {
            if(vaccineUser.VaccineId == 0)
            {
                return RedirectToAction("Details", "User", new { id = vaccineUser.UserId });
            }
            else
            {
                if(vaccineUser.Dose == 0)
                {
                    vaccineUser.Dose = 1;
                }
                if(vaccineUser.Rate == null)
                {
                    vaccineUser.Rate = "";
                }
                vaccineUser.Active = true;
                vaccineUser.CreatedAt = DateTime.Now;
                vaccineUser.UpdatedAt = DateTime.Now;

                _unitOfWork.VaccineUser.Add(vaccineUser);
                _unitOfWork.Save();
            }
            
            return RedirectToAction("Details", "User", new { id = vaccineUser.UserId });

        }

        [HttpPost]
        public IActionResult RemoveVaccine(int id)
        {
            var objDb = _unitOfWork.VaccineUser.Get(id);
            var userId = objDb.UserId;

            objDb.Active = false;
            _unitOfWork.VaccineUser.Remove(objDb);
            _unitOfWork.Save();
            return RedirectToAction("Details", "User", new { id = userId });

        }
        #endregion

    }
}

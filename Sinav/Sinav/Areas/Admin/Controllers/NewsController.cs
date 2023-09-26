using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sinav.DataAcess.Data.Repository.IRepository;
using Sinav.Models.Entities;

namespace Sinav.Areas.Admin.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    [Area("Admin")]
    public class NewsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;

        public NewsController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
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
        public IActionResult Create(News news)
        {
            if (ModelState.IsValid)
            {
                string principalRoute = _hostEnvironment.WebRootPath;
                var files = HttpContext.Request.Form.Files;
                if (news.Id == 0)
                {
                    string fileName = Guid.NewGuid().ToString();
                    var ups = Path.Combine(principalRoute, @"images\news");
                    var extension = Path.GetExtension(files[0].FileName);

                    using (var fileStream = new FileStream(Path.Combine(ups, fileName + extension), FileMode.Create))
                    {
                        files[0].CopyTo(fileStream);
                    }

                    news.ImageUrl = @"\images\news\" + fileName + extension;


                    _unitOfWork.News.Add(news);
                    _unitOfWork.Save();

                    return RedirectToAction(nameof(Index));
                }
            }

            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            _ = new News();
            News news = _unitOfWork.News.Get(id);
            if (news == null)
            {
                return NotFound();
            }

            return View(news);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(News news)
        {

            if (ModelState.IsValid)
            {
                string principalRouet = _hostEnvironment.WebRootPath;
                var files = HttpContext.Request.Form.Files;

                var sliderFromDb = _unitOfWork.News.Get(news.Id);


                if (files.Count() > 0)
                {
                    string fileName = Guid.NewGuid().ToString();
                    var ups = Path.Combine(principalRouet, @"images\news");
                    var extension = Path.GetExtension(files[0].FileName);
                    var newExtension = Path.GetExtension(files[0].FileName);

                    var imageRoute = Path.Combine(principalRouet, sliderFromDb.ImageUrl.TrimStart('\\'));
                    if (System.IO.File.Exists(imageRoute))
                    {
                        System.IO.File.Delete(imageRoute);
                    }

                    using (var fileStream = new FileStream(Path.Combine(ups, fileName + extension), FileMode.Create))
                    {
                        files[0].CopyTo(fileStream);
                    }

                    news.ImageUrl = @"\images\news\" + fileName + extension;

                    _unitOfWork.News.Update(news);
                    _unitOfWork.Save();

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    news.ImageUrl = sliderFromDb.ImageUrl;
                }

                _unitOfWork.News.Update(news);
                _unitOfWork.Save();

                return RedirectToAction(nameof(Index));
            }

            return View(news);
        }


        #region Llamadas a la api
        [HttpGet]
        public IActionResult GetAll()
        {
            //opcion 1
            return Json(new { data = _unitOfWork.News.GetAll(x => x.Active) });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objDb = _unitOfWork.News.Get(id);
            if (objDb == null)
            {
                return Json(new { success = false, message = "Error to delete the new" });
            }

            objDb.Active = false;
            _unitOfWork.News.Remove(objDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "La noticia ha sido eliminada" });

        }

        #endregion
    }
}

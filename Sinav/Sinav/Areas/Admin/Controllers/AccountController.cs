using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sinav.Data;
using Sinav.DataAcess.Data.Repository.IRepository;
using System.Security.Claims;

namespace Sinav.Areas.Admin.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ApplicationDbContext _context;

        public AccountController(IUnitOfWork unitOfWork, ApplicationDbContext context)
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity!;
            var currentUser = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            var users = _context.Account.ToList();
            if (currentUser != null)
            {
                users = users.Where(x => x.Id != currentUser.Value).ToList();
            }
            return View(users);
        }

        public IActionResult Lock(string userId)
        {
            if (userId == null)
            {
                return NotFound();
            }

            _unitOfWork.Account.LockUser(userId);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Unlock(string userId)
        {
            if (userId == null)
            {
                return NotFound();
            }

            _unitOfWork.Account.UnlockUser(userId);
            return RedirectToAction(nameof(Index));
        }
    }
}

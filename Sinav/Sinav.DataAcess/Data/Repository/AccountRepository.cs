using Sinav.Data;
using Sinav.DataAcess.Data.Repository.IRepository;
using Sinav.Models.Entities;

namespace Sinav.DataAcess.Data.Repository
{
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        private readonly ApplicationDbContext _context;

        public AccountRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void LockUser(string userId)
        {
            var user = _context.Account.FirstOrDefault(u => u.Id == userId);
            if (user != null)
            {
                user.LockoutEnd = DateTime.Now.AddYears(100);
                _context.SaveChanges();
            }
        }

        public void UnlockUser(string userId)
        {
            var user = _context.Account.FirstOrDefault(u => u.Id == userId);
            if (user != null)
            {
                user.LockoutEnd = DateTime.Now;
                _context.SaveChanges();
            }
        }
    }
}

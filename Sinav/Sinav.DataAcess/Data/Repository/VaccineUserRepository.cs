using Microsoft.EntityFrameworkCore;
using Sinav.Data;
using Sinav.DataAcess.Data.Repository.IRepository;
using Sinav.Models.Entities;

namespace Sinav.DataAcess.Data.Repository
{
    public class VaccineUserRepository : Repository<VaccineUser>, IVaccineUserRepository
    {
        private readonly ApplicationDbContext _context;

        public VaccineUserRepository(ApplicationDbContext context): base(context)
        {
            _context = context;
        }

        public IEnumerable<VaccineUser> GetListVaccineUser(int userId)
        {
            return _context.TblVaccineUser.Where(x => x.UserId == userId && x.Active).Include(x => x.Vaccine);
        }

        public void Update(VaccineUser vaccineUser)
        {
            var vacciUserDb = _context.TblVaccineUser.FirstOrDefault(x => x.Id == vaccineUser.Id);
            if (vacciUserDb != null)
            {
                vacciUserDb.Dose = vaccineUser.Dose;
                vacciUserDb.Rate = vaccineUser.Rate;
                vacciUserDb.UpdatedAt = DateTime.UtcNow;
            }
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Sinav.Data;
using Sinav.DataAcess.Data.Repository.IRepository;
using Sinav.Models.Entities;

namespace Sinav.DataAcess.Data.Repository
{
    public class AllergyUserRepository : Repository<AllergyUser>, IAllergyUserRepository
    {
        private readonly ApplicationDbContext _context;

        public AllergyUserRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<AllergyUser> GetListAllergyUser(int userId)
        {
            return _context.TblAllergyUser.Where(x => x.UserId == userId).Include(x => x.Allergy);
        }

        public void Update(AllergyUser allergyUser)
        {
            var allerUserDb = _context.TblAllergyUser.FirstOrDefault(x => x.Id == allergyUser.Id);
            if (allerUserDb != null)
            {
                allerUserDb.Observations = allergyUser.Observations;
                allerUserDb.UpdatedAt = DateTime.UtcNow;
            }
        }
    }
}

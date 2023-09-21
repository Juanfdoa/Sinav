using Microsoft.EntityFrameworkCore;
using Sinav.Data;
using Sinav.DataAcess.Data.Repository.IRepository;
using Sinav.Models.Entities;

namespace Sinav.DataAcess.Data.Repository
{
    public class DiseaseUserRepository : Repository<DiseaseUser>, IDiseaseUserRepository
    {
        private readonly ApplicationDbContext _context;

        public DiseaseUserRepository(ApplicationDbContext context): base(context)
        {
            _context = context;
        }

        public IEnumerable<DiseaseUser> GetListDiseaseUser(int userId)
        {
            return _context.TblDiseaseUser.Where(x => x.UserId == userId && x.Active).Include(x => x.Disease);
        }

        public void Update(DiseaseUser diseaseUser)
        {
            var diseaseUserDb = _context.TblAllergyUser.FirstOrDefault(x => x.Id == diseaseUser.Id);
            if (diseaseUserDb != null)
            {
                diseaseUserDb.Observations = diseaseUser.Observations;
                diseaseUserDb.UpdatedAt = DateTime.UtcNow;
            }
        }
    }
}

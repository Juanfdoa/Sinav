using Microsoft.AspNetCore.Mvc.Rendering;
using Sinav.Data;
using Sinav.DataAcess.Data.Repository.IRepository;
using Sinav.Models.Entities;

namespace Sinav.DataAcess.Data.Repository
{
    public class AllergyRepository : Repository<Allergy>, IAllergyRepository
    {
        private readonly ApplicationDbContext _context;

        public AllergyRepository(ApplicationDbContext context): base(context)
        {
            _context = context;
        }

        public IEnumerable<SelectListItem> GetListAllergies()
        {
            return _context.TblAllergy.Where(x => x.Active).Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
        }

        public void Update(Allergy allergy)
        {
            var allergyDb = _context.TblAllergy.FirstOrDefault(a => a.Id == allergy.Id);
            if (allergyDb != null)
            {
                allergyDb.Name = allergy.Name;
                allergyDb.Description = allergy.Description;
                allergyDb.Active = true;
                allergyDb.CreatedAt = allergyDb.CreatedAt;
                allergyDb.UpdatedAt = DateTime.UtcNow;
            }
        }
    }
}

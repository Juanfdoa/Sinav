using Microsoft.AspNetCore.Mvc.Rendering;
using Sinav.Data;
using Sinav.DataAcess.Data.Repository.IRepository;
using Sinav.Models.Entities;

namespace Sinav.DataAcess.Data.Repository
{
    public class VaccineRepository : Repository<Vaccine>, IVaccineRepository
    {
        private readonly ApplicationDbContext _context;

        public VaccineRepository(ApplicationDbContext context): base(context)
        {
            _context = context;
        }

        public IEnumerable<SelectListItem> GetListVaccines()
        {
            return _context.TblVaccine.Where(x => x.Active).Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
        }

        public void Update(Vaccine vaccine)
        {
            var vaccineDb = _context.TblVaccine.FirstOrDefault(x => x.Id == vaccine.Id);
            if (vaccineDb != null)
            {
                vaccineDb.Name = vaccine.Name;
                vaccineDb.Description = vaccine.Description;
                vaccineDb.UpdatedAt = DateTime.UtcNow;
                vaccineDb.SupplierId = vaccine.Supplier.Id;
            }
        }
    }
}

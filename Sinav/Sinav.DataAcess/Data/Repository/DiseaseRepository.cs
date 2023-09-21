using Microsoft.AspNetCore.Mvc.Rendering;
using Sinav.Data;
using Sinav.DataAcess.Data.Repository.IRepository;
using Sinav.Models.Entities;

namespace Sinav.DataAcess.Data.Repository
{
    public class DiseaseRepository : Repository<Disease>, IDiseaseRepository
    {
        private readonly ApplicationDbContext _context;

        public DiseaseRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<SelectListItem> GetListDiseases()
        {
            return _context.TblDisease.Where(x => x.Active).Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
        }

        public void Update(Disease disease)
        {
            var diseaseDb = _context.TblDisease.FirstOrDefault(x => x.Id == disease.Id);
            if (diseaseDb != null)
            {
                diseaseDb.Name = disease.Name;
                diseaseDb.Description = disease.Description;
                diseaseDb.Active = true;
                diseaseDb.CreatedAt = diseaseDb.CreatedAt;
                diseaseDb.UpdatedAt = DateTime.UtcNow;
            }
        }
    }
}
